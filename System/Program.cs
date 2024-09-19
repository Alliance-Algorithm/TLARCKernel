using TlarcKernel.Init;
using Rcl;
using TlarcKernel.IO.TlarcMsgs;

namespace TlarcKernel
{


    static class Program
    {
        static Dictionary<uint, Process> Processes = [];
        static Dictionary<uint, ComponentCell> Components = [];
        static void Main(string[] args)
        {
            Ros2Def.context = new RclContext(args);
            Ros2Def.node = Ros2Def.context.CreateNode("tlarc");

            ProcessInit.Init(ref Processes, ref Components);

            StageConstruct();

            Awake();

            Start();

        }
        static void Awake()
        {
            foreach (var i in Components.Values)
                i.Awake();
        }
        static void Start()
        {

            foreach (var i in Processes.Values)
                i.Start();
        }


        public static void StageConstruct()
        {
            foreach (var c in Components.Values)
            {
                foreach (var id in c.Component.ReceiveID.Values)
                {
                    if (Processes[c.Component.ProcessID].Components.Keys.Contains(id))
                        continue;
                    var componentC = Components[id].Component.GetType().Assembly.CreateInstance(Components[id].Component.GetType().FullName) ?? throw new Exception();
                    var componentI = Components[id].Component.GetType().Assembly.CreateInstance(Components[id].Component.GetType().FullName) ?? throw new Exception();

                    var change1 = new CopyWithExpressions();

                    change1.Copy(componentC, componentI);
                    change1.NewCopy(componentI, componentC);

                    Components[id].Component.IOManager.CopyForOut.Add((Components[id].Component, change1));
                    c.Component.IOManager.CopyForIn.Add((componentI, change1));

                    Processes[c.Component.ProcessID].Components.Add(id, new(componentI as Component) { Image = true });
                }
            }
        }

        //=====================
        public static Process GetProcessWithPID(uint id)
        {
            return Processes[id];
        }
    }
}