using TlarcKernel.Init;
using Rcl;
using TlarcKernel.IO.TlarcMsgs;
using System.Diagnostics;
using System.Runtime;
using System.Reflection;
using TlarcKernel.IO;
using TlarcKernel.IO.ProcessCommunicateInterfaces;

namespace TlarcKernel
{


    static class Program
    {
        static Dictionary<uint, Process> Processes = [];
        static Dictionary<uint, ComponentCell> Components = [];
        static Dictionary<string, IPublisher> CommunicatorInterface = [];
        static Dictionary<Type, uint> LastInstance = [];
        static void Main(string[] args)
        {
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
            Ros2Def.context = new RclContext(args);
            Ros2Def.node = Ros2Def.context.CreateNode("tlarc");
#if DEBUG
            Console.WriteLine("[Enter] to use debug.yaml, or input your config files name, split with [Space]:");
            args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
#endif
            ProcessInit.Init(args, ref Processes, ref Components, ref LastInstance);

            StageConstruct();

            Awake();

            BuildInterfaceTable();

            BindInterface();

            Start();

            while (true)
            {
                if (TlarcSystem.TryGetPrint(out var a))
                    a();
                Thread.Sleep(1);
            }
        }
        static void Awake()
        {
            foreach (var i in Components.Values)
                i.Awake();
        }
        static void BindInterface()
        {

            foreach (var i in Components.Values)
                i.BindInterface();
        }
        static void Start()
        {

            foreach (var i in Processes.Values)
                i.Start();
        }
        public static void BuildInterfaceTable()
        {
            foreach (var c in Components.Values)
                foreach (var p in c.Component.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                    if (p.FieldType.GetInterfaces().Any(x => typeof(IPublisher).IsAssignableFrom(x)))
                        CommunicatorInterface[(p.GetValue(c.Component) as ICommunicateInterface).InterfaceName] = p.GetValue(c.Component) as IPublisher;

        }


        public static void StageConstruct()
        {

            foreach (var c in Components.Values)
            {
                c.AutoSetReceiveID();
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

        public static uint GetInstanceWithType(Type type)
        {

            if (!LastInstance.TryGetValue(type, out var publisher))
                LastInstance.TryGetValue(LastInstance.Keys.FirstOrDefault(type.IsAssignableFrom), out publisher);
            return publisher;
        }


        public static IPublisher? GetInterfaceWithName(string name)
        {
            CommunicatorInterface.TryGetValue(name, out var publisher);
            return publisher;
        }
    }
}