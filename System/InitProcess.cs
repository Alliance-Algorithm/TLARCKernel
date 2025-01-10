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
        public uint? Pid { get; set; }
        public int? Fps { get; set; }
        public bool? Realtime { get; set; }
        public Dictionary<string, ComponentsProperties>? Components { get; set; }
    }
    struct ComponentsProperties()
    {
        public Dictionary<string, uint>? Relies { get; set; }
        public Dictionary<string, object>? Args { get; set; }
    }

    static internal class ProcessInit
    {
        internal static void Init(in IEnumerable<string> configFiles, ref Dictionary<uint, Process> processes, ref Dictionary<uint, ComponentCell> componentCells, ref Dictionary<Type, uint> lastInstance)
        {
            string path = TlarcSystem.ConfigurationPath;
            string[] files = [];
            List<string> filesHelper = [];
            foreach (var file in configFiles)
            {
                if (file.EndsWith(".yaml"))
                    filesHelper.AddRange(Directory.GetFiles(path, file));
                else
                    filesHelper.AddRange(Directory.GetFiles(path, $"{file}.yaml"));
            }
            files = filesHelper.ToArray();
            if (!configFiles.Any())
#if DEBUG
                files = Directory.GetFiles(path, "debug.yaml");
#else
                files = Directory.GetFiles(path, "*.yaml");
#endif
            var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(NullNamingConvention.Instance)
                        .Build();
            uint randomKey = 0x11110000;
            foreach (var i in files)
            {
                try
                {
                    var yaml = File.ReadAllText(i);

                    var processesProperties = deserializer.Deserialize<List<ProcessProperties>>(yaml);
                    if (processesProperties == null)
                        continue;
                    foreach (var property in processesProperties)
                    {
                        Dictionary<Type, uint> LastInstance = [];
                        Dictionary<uint, ComponentCell> components = new()
                    {
                        { 0, new IOManager() }
                    };
                        uint pid = property.Pid ?? randomKey++;
                        foreach (var component in property.Components)
                        {
                            var declare = component.Key.Split("->");
                            uint key = 0;
                            if (declare.Length == 1)
                                throw new Exception($"you must declare type in components declare,\n\t in \"{i}\" \n\tprocess:{property.Pid?.ToString("X")}:{component.Key}\"");
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
                            (d as Component).InitComponents(key, component.Value.Relies ?? [], component.Value.Args ?? []);
                            (d as Component).IOManager = components[0].Component as IOManager;
                            (d as Component).ProcessID = pid;

                            LastInstance[d.GetType()] = key;
                            lastInstance[d.GetType()] = key;
                            components.Add(key, d);
                            componentCells.Add(key, d);
                        }
                        processes.Add(pid, new Process() { Pid = pid, Fps = property.Fps ?? 1000, Realtime = property.Realtime ?? false, Components = components, LastInstance = LastInstance });
                    }
                }
                catch
                {
                    TlarcSystem.LogError("File not exist:" + i);
                }
            }
        }

        internal static void Init(ref object components)
        {
            throw new NotImplementedException();
        }
    }
}