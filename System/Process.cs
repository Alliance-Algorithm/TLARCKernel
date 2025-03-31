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

    DateTime _dateTime = DateTime.Now;
    List<List<ComponentCell>> _updateFuncs = new();
    uint _poolDim = 0;
    uint _tasksId = 0;
    readonly object _lock = new();
    bool _lockWasTaken = false;
    List<Task>[] _tasks = [];
    int[] _finalTaskCount;
    CountdownEvent[] _countdownEvents;
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
        _tasks = new List<Task>[_poolDim + 1];
        _finalTaskCount = new int[_poolDim + 1];
        _countdownEvents = new CountdownEvent[_poolDim + 1];
        for (int i = 0; i < _poolDim + 1; i++)
        {
            _tasks[i] = [];
            _finalTaskCount[i] = 0;
        }
        for (int i = 1; i < _poolDim; i++)
        {
            foreach (var a in _updateFuncs[i])
            {
                if (!a.Image)
                {
                    _tasks[a.Dim].Add(Task.Run(a.Start));
                    _finalTaskCount[a.Dim]++;
                    TlarcSystem.LogInfo(a.Component.GetType().FullName + ": Start()");
                }
            }
            _tasksId = (uint)i;

            Task.WaitAll([.. _tasks[i]]);
        }
        for (int i = 0; i < _poolDim + 1; i++)
            _countdownEvents[i] = new CountdownEvent(_finalTaskCount[i]);
    }

    void LifeCycle(object? source, System.Timers.ElapsedEventArgs? e)
    {
        if (_lockWasTaken)
        {
            string warning = "";
            warning += $"did not fix in fps : {Fps} At Tasks : + {_tasksId} In Process:0x{Pid}]\n";
            warning += $"\tIt could be in components:\n";

            foreach (var b in _updateFuncs)
                foreach (var a in b)
                    if (a.Dim == _tasksId)
                        warning += $"\t\t {a.Component.GetType()} with uid:0x{a.ID}\n";

            TlarcSystem.LogWarning(warning);
            return;
        }
        lock (_lock)
        {
            _lockWasTaken = true;
            if (Realtime) GC.TryStartNoGCRegion(20 * 1024 * 1024);
            deltaTime = (DateTime.Now - _dateTime).TotalSeconds;
            _dateTime = DateTime.Now;
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
        for (int i = 0; i < _poolDim + 1; i++)
            _countdownEvents[i].Reset();
        for (int i = 1; i < _poolDim; i++)
        {
            foreach (var a in _updateFuncs[i])
            {
                ThreadPool.UnsafeQueueUserWorkItem(state =>
                {
                    try
                    {
                        a.Update();
                    }
                    catch (Exception ex)
                    {
                        TlarcSystem.LogError(ex.Message + $" at {a.GetType().Name} with id :0x{a.ID} :{a.Component.GetType().FullName} :at {Pid}");
                        TlarcSystem.LogError(ex.StackTrace);
                    }
                    finally
                    {
                        _countdownEvents[a.Dim].Signal();
                    }
                }
                , null);
            }
            _tasksId = (uint)i;

            _countdownEvents[i].Wait();
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
        for (int k = 0; k < l.Length; k++)
        {
            if (l[k].Dim != 0)
                continue;
            Hashtable colored = [];
            FindPath(ref l[k], in colored);
            _poolDim = Math.Max(l[k].Dim, _poolDim);
        }
        foreach (var i in l)
            if (!i.Flag)
                i.Dim = _poolDim;
        _poolDim += 1;
        for (int i = 0; i < _poolDim; i++)
            _updateFuncs.Add([]);
        Components[0].Dim = 0;
        Components[0].Early = 0;
        foreach (var i in l)
            if (!i.Image)
                _updateFuncs[(int)i.Early].Add(i);
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