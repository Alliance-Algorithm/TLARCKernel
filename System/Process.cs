using System.Collections;
using System.Timers;
using Rcl.Logging;
using TlarcKernel.IO;

namespace TlarcKernel;

class Process
{
    public required int Fps { get; init; }
    public required bool Realtime { get; init; }

    public double deltaTime { get; private set; }
    public required uint Pid { get; init; }
    public required Dictionary<uint, ComponentCell> Components { get; init; }
    public required Dictionary<Type, uint> LastInstance { get; init; }

    DateTime dateTime = DateTime.Now;
    List<List<ComponentCell>> UpdateFuncs = new();
    uint PoolDim = 0;
    uint TasksId = 0;
    readonly object _lock = new();
    bool _lockWasTaken = false;
    List<Task>[] tasks = [];
    System.Timers.Timer tmr;
    public void Start()
    {
        double delay_time = 1000.0 / Fps;

        StageConstruct();

        Awake();
        tmr = new System.Timers.Timer(delay_time);
        tmr.Elapsed += new System.Timers.ElapsedEventHandler(LifeCycle);//到达时间的时候执行事件；
        tmr.AutoReset = true;
        tmr.Enabled = true;
        tmr.Start();
    }
    void Awake()
    {
        tasks = new List<Task>[PoolDim + 1];
        for (int i = 0; i < PoolDim + 1; i++)
            tasks[i] = [];
        for (int i = 1; i < PoolDim; i++)
        {
            foreach (var a in UpdateFuncs[i])
            {
                if (!a.Image)
                {
                    tasks[a.Early].Add(Task.Run(a.Start));
                    TlarcSystem.LogInfo(a.Component.GetType().FullName + ": Start()");
                }
            }
            TasksId = (uint)i;

            Task.WaitAll([.. tasks[i]]);
        }
    }

    void LifeCycle(object? source, System.Timers.ElapsedEventArgs? e)
    {
        if (_lockWasTaken)
        {
            string warning = "";
            warning += $"did not fix in fps : {Fps} At Tasks : + {TasksId} In Process:0x{Pid}]\n";
            warning += $"\tIt could be in components:\n";

            foreach (var a in UpdateFuncs[(int)TasksId])
                warning += $"\t\t {a.Component.GetType()} with uid:0x{a.ID}\n";

            TlarcSystem.LogWarning(warning);

        }
        lock (_lock)
        {
            _lockWasTaken = true;
            if (Realtime) GC.TryStartNoGCRegion(20 * 1024 * 1024);
            deltaTime = (DateTime.Now - dateTime).TotalSeconds;
            dateTime = DateTime.Now;
            InputUpdate();
            Update();
            OutputUpdate();
            if (Realtime) GC.EndNoGCRegion();
            _lockWasTaken = false;
        }
    }

    void InputUpdate()
    {
        ((IOManager)Components[0].Component).Input();
    }

    void Update()
    {
        for (int i = 0; i < PoolDim + 1; i++)
            tasks[i] = [];
        for (int i = 1; i < PoolDim; i++)
        {
            foreach (var a in UpdateFuncs[i])
            {
                tasks[a.Early].Add(Task.Run(a.Update));
            }
            TasksId = (uint)i;

            Task.WaitAll([.. tasks[i]]);
        }
    }
    void OutputUpdate()
    {
        ((IOManager)Components[0].Component).Output();
    }

    void FindPath(ref ComponentCell cell, in Hashtable colored)
    {
        try
        {
            if (colored.ContainsKey(cell.ID))
                throw new Exception("There is a loop,path is:");
            colored.Add(cell.ID, null);
            uint max = 0;
            for (var i = 0; i < cell.Forward.Count; i++)
            {
                ComponentCell c = cell.Forward[i];
                if (c.Dim == 0)
                    FindPath(ref c, in colored);
                max = Math.Max(c.Dim, max);
            }
            cell.Dim = max + 1;
            cell.Early = max + 1;
            if (max == 0)
                return;
            for (var i = 0; i < cell.Forward.Count; i++)
            {
                if (cell.Forward[i].Flag)
                    cell.Forward[i].Dim = Math.Min(max, cell.Forward[i].Dim);
                else
                {
                    cell.Forward[i].Dim = max;
                    cell.Forward[i].Flag = true;
                }
            }
            return;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message + "<-" + cell.ID.ToString());
        }
    }
    public void StageConstruct()
    {
        var l = Components.Values.ToArray();

        for (int k = 0; k < l.Length; k++)
        {
            // try
            {
                foreach (var i in l[k].ReceiveID)
                {
                    if (i.Value == 0)
                    {
                        Ros2Def.node.Logger.LogWarning("0 should not be inputID" + "@:" + l[k].ID.ToString());
                        continue;
                    }
                    if (!Components[i.Value].Image)
                        l[k].Forward.Add(Components[i.Value]);
                }
            }
            // catch (Exception e)
            // {
            //     Ros2Def.node.Logger.LogFatal(e.Message + "\twhen:Set ID:" + l[k].ID + " Forward node At Program.cs");
            //     Environment.Exit(-1);
            // }
        }
        for (int k = 0; k < l.Length; k++)
        {
            if (l[k].Dim != 0)
                continue;
            Hashtable colored = [];
            FindPath(ref l[k], in colored);
            PoolDim = Math.Max(l[k].Dim, PoolDim);
        }
        foreach (var i in l)
            if (!i.Flag)
                i.Dim = PoolDim;
        PoolDim += 1;
        for (int i = 0; i < PoolDim; i++)
            UpdateFuncs.Add([]);
        Components[0].Dim = 0;
        foreach (var i in l)
            if (!i.Image)
                UpdateFuncs[(int)i.Dim].Add(i);
    }

    //=====================
    public Object GetComponentWithUID(uint id)
    {
        return Components[id].Component ?? throw new Exception("uuid:" + id.ToString());
    }
    //=====================
    public uint GetInstanceWithType(Type type)
    {
        if (!LastInstance.TryGetValue(type, out var publisher))
            LastInstance.TryGetValue(LastInstance.Keys.FirstOrDefault(type.IsAssignableFrom), out publisher);
        return publisher;
    }


}