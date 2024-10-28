using System.Reflection;
using TlarcKernel.IO;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Core.Tokens;

namespace TlarcKernel.Init
{

    struct ProcessProperties()
    {
        public uint? pid { get; set; }
        public int? fps { get; set; }
        public Dictionary<string, ComponentsProperties>? components { get; set; }
    }
    struct ComponentsProperties()
    {
        public Dictionary<string, uint>? InputComponents { get; set; }
        public Dictionary<string, object>? Arguments { get; set; }
    }

    static internal class ProcessInit
    {
        internal static void Init(in IEnumerable<string> configFiles, ref Dictionary<uint, Process> processes, ref Dictionary<uint, ComponentCell> componentCells, ref Dictionary<Type, uint> LastInstance)
        {
            string path = TlarcSystem.ConfigurationPath;
            string[] files = [];
            List<string> filesHelper = [];
            if (!configFiles.Any())
#if DEBUG
                files = Directory.GetFiles(path, "debug.yaml");
#else
                files = Directory.GetFiles(path, "*.yaml");
#endif
            foreach (var file in configFiles)
            {
                if (file.EndsWith(".yaml"))
                    filesHelper.AddRange(Directory.GetFiles(path, file));
                else
                    filesHelper.AddRange(Directory.GetFiles(path, $"{file}.yaml"));
            }
            var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
            uint randomKey = 0x11110000;
            foreach (var i in files)
            {
                Dictionary<uint, ComponentCell> components = new()
                {
                    { 0, new IOManager() }
                };
                // try
                // {
                var yaml = File.ReadAllText(i);

                var processesProperties = deserializer.Deserialize<List<ProcessProperties>>(yaml);
                if (processesProperties == null)
                    continue;
                foreach (var property in processesProperties)
                {
                    uint pid = property.pid ?? randomKey++;
                    foreach (var component in property.components)
                    {
                        var declare = component.Key.Split("->");
                        uint key = 0;
                        if (declare.Length == 1)
                            throw new Exception($"you must declare type in components declare,\n\t in \"{i}\" \n\tprocess:{property.pid?.ToString("X")}:{component.Key}\"");
                        else if (declare.Length == 2)
                            key = randomKey++;
                        else if (declare.Length == 3)
                            key = uint.Parse(declare[2]);
                        if (components.ContainsKey(key))
                            throw new Exception("Multi ID");
                        if (key == 0)
                            throw new Exception("Could not use ID:0");

                        Type? t = Type.GetType(declare[0] + '.' + declare[1]);
                        if (t == null || t.FullName == null)
                            throw new Exception("type error");
                        if (!t.IsSubclassOf(typeof(Component)))
                            throw new Exception("type not a component");

                        dynamic d = t.Assembly.CreateInstance(t.FullName, false, BindingFlags.Default, null, null, null, null)
                         ?? throw new Exception("Could not create instance");
                        (d as Component).InitComponents(key, component.Value.InputComponents ?? [], component.Value.Arguments ?? []);
                        (d as Component).IOManager = components[0].Component as IOManager;
                        (d as Component).ProcessID = pid;

                        LastInstance[d.GetType()] = pid;
                        components.Add(key, d);
                        componentCells.Add(key, d);
                    }
                    processes.Add(pid, new Process() { fps = property.fps ?? 1000, Components = components });
                }

            }
        }

        internal static void Init(ref object components)
        {
            throw new NotImplementedException();
        }
    }
}