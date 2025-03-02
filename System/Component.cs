
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rcl.Logging;
using TlarcKernel.IO;
using TlarcKernel.IO.ProcessCommunicateInterfaces;

namespace TlarcKernel
{
    public interface IComponent
    {
        /// <summary>
        /// 起始调用
        /// </summary>
        public virtual void Start() { }
        /// <summary>
        /// 状态更新调用
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// 信息传递
        /// </summary>
        public virtual void Echo() { }
    }

    public class Component : IComponent
    {
        protected double DeltaTimeInSecond => Program.GetProcessWithPID(ProcessID).deltaTime;
        uint _uuid;
        Dictionary<string, uint> _revUid = [];
        Dictionary<string, object> _args = [];

        public uint ProcessID { get; set; }
        public uint ID => _uuid;
        public Dictionary<string, uint> ReceiveID => _revUid;
        public Dictionary<string, object> Args => _args;
        public IOManager IOManager { get; set; }


#if DEBUG
        static object? CreateInterfaceInstance(Type interfaceType)
        {
            if (interfaceType.IsInterface)
            {
                var dynamicAssemblyName = new AssemblyName("DynamicAssembly");
                var dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(dynamicAssemblyName, AssemblyBuilderAccess.Run);
                dynamicAssembly.GetReferencedAssemblies().Append(interfaceType.Assembly.GetName());
                var dynamicModule = dynamicAssembly.DefineDynamicModule("DynamicModule");

                var typeBuilder = dynamicModule.DefineType(interfaceType.Name + "Impl");
                typeBuilder.AddInterfaceImplementation(interfaceType);

                // Implement the method
                foreach (var method in interfaceType.GetMethods())
                {
                    var methodBuilder = typeBuilder.DefineMethod(
                        method.Name,
                        MethodAttributes.Public | MethodAttributes.Virtual,
                        method.ReturnType,
                        method.GetParameters().Select(p => p.ParameterType).ToArray());

                    var il = methodBuilder.GetILGenerator();
                    if (method.ReturnType != typeof(void))
                    {
                        if (method.ReturnType.IsValueType)
                        {
                            il.Emit(OpCodes.Ldc_I4_0);
                        }
                        else
                        {
                            il.Emit(OpCodes.Ldnull);
                        }
                    }
                    il.Emit(OpCodes.Ret);
                }

                var dynamicType = typeBuilder.CreateTypeInfo().AsType();

                // Use expression trees to create an instance
                var newExp = Expression.New(dynamicType);
                var lambda = Expression.Lambda<Func<object>>(newExp);
                var compiledLambda = lambda.Compile();

                return compiledLambda();
            }
            else
            {
                return null;
            }
        }
#endif

        public void AutoSetReceiveID()
        {
            try
            {
                foreach (var p in GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (p.FieldType.IsSubclassOf(typeof(Component)) || p.GetCustomAttributes(typeof(ComponentReferenceFiledAttribute), true).Any())
                    {
                        try
                        {
                            typeof(Process).GetMethod("GetComponentWithUID",
                          BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).MakeGenericMethod(p.FieldType).Invoke(Program.GetProcessWithPID(ProcessID), [_revUid[p.Name]]);
                        }
                        catch
                        {
                            if (_revUid.ContainsKey(p.Name))
                            {
                                continue;
                            }
                            try
                            {
                                var tmpId = Program.GetProcessWithPID(ProcessID).GetInstanceWithType(p.FieldType);
                                ReceiveID[p.Name] = tmpId;
                            }
                            catch
                            {
                                var tmpId = Program.GetInstanceWithType(p.FieldType);
                                ReceiveID[p.Name] = tmpId;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                TlarcSystem.LogError(e.Message);
            }
        }

        /// <summary>
        /// 系统调用
        /// </summary>
        public void Awake()
        {
            Debug.WriteLine(GetType().FullName + "\t uuid:" + _uuid.ToString());
            try
            {
                foreach (var p in GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (!p.FieldType.IsSubclassOf(typeof(Component)) && !p.GetCustomAttributes(typeof(ComponentReferenceFiledAttribute), true).Any())
                        continue;
                    if (p.IsPublic)
                        TlarcSystem.LogWarning($"{p.Name} in {GetType().FullName} should be non public");
                    try
                    {
                        p.SetValue(this, Program.GetProcessWithPID(ProcessID).GetComponentWithUID(_revUid[p.Name]));
                    }
                    catch
                    {
                        if (_revUid.ContainsKey(p.Name))
                        {
                            TlarcSystem.LogWarning($"Cannot Find Component: \n\tno any component of uid: {_revUid[p.Name]}\nin process:0x{ProcessID:X}\ntry to use other instance");
                        }
                        try
                        {
                            var tmpId = Program.GetInstanceWithType(p.FieldType);
                            p.SetValue(this, Program.GetProcessWithPID(ProcessID).GetComponentWithUID(tmpId));
                        }
                        catch (System.Exception)
                        {
#if DEBUG
                            TlarcSystem.LogError($"{GetType().FullName} Cannot Find Component: \n\tno any component of type: {p.FieldType.FullName}\nin process:0x{ProcessID:X}");
                            p.SetValue(this, CreateInterfaceInstance(p.FieldType) ?? Activator.CreateInstance(p.FieldType));
#else
                            throw new Exception($"{GetType().FullName} Cannot Find Component: \n\tno any component of type: {p.FieldType.FullName}\nin process:0x{ProcessID:X}");
#endif
                        }

                    }
                }
                foreach (var p in this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!Args.ContainsKey(p.Name))
                        continue;

                    var obj = JsonConvert.DeserializeObject<object>(_args[p.Name] as string) ?? throw new Exception($"Argument must be json style string : {p.Name}");
                    if (obj.GetType().IsSubclassOf(typeof(JContainer)))
                        p.SetValue(this, obj.GetType().GetMethod("ToObject",
                         BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, []).MakeGenericMethod(p.FieldType).Invoke(obj, null));
                    else
                        p.SetValue(this, Convert.ChangeType(obj, p.FieldType));
                }
            }
            catch (Exception e)
            {
                TlarcSystem.LogError(e.Message);
                return;
            }
        }

        internal void BindInterface()
        {

            foreach (var p in GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                if (p.FieldType.GetInterfaces().Any(x => typeof(ISubscriptionFormPublisher).IsAssignableFrom(x)))
                {

                    p.FieldType.GetProperty("Instance").SetValue(p.GetValue(this), Program.GetInterfaceWithName((p.GetValue(this) as ICommunicateInterface).InterfaceName));
                }

        }
        // /// <summary>
        // /// 起始调用
        // /// </summary>
        // public void Start() { }
        // /// <summary>
        // /// 状态更新调用
        // /// </summary>
        // public void Update() { }
        // /// <summary>
        // /// 历史遗留
        // /// </summary>
        // public void Echo() ;
        // /// <summary>
        // /// 信息传递
        // /// </summary>
        public virtual void Echo(string topic, int frameRate) { }


        public void InitComponents(uint uuid, Dictionary<string, uint> revid, Dictionary<string, object> args)
        {
            _uuid = uuid;
            _revUid = revid;
            _args = args;
        }

        public virtual void Start() { }

        public virtual void Update() { }

        public virtual void Echo() { }

    }

    public class ComponentCell(Component component)
    {
        uint _dim = 0;
        uint _early = 0;
        bool _flag = false;



        Component _component = component;

        public Component Component => _component;

        public Dictionary<string, uint> ReceiveID => _component.ReceiveID;
        public uint Dim { get => _dim; set => _dim = value; }
        public uint Early { get => _early; set => _early = value; }
        public bool Flag { get => _flag; set => _flag = value; }
        public bool Image = false;
        List<ComponentCell> _forward = [];
        public List<ComponentCell> Forward { get => Forward = _forward; set => _forward = value; }
        public uint ID => _component.ID;

        public Action Start => _component.Start;

        public Action Update => _component.Update;
        public Action Awake => _component.Awake;

        public Action BindInterface => _component.BindInterface;

        public static implicit operator ComponentCell(Component component)
        {
            return new ComponentCell(component);
        }
        public void InitComponents(uint uuid, Dictionary<string, uint> revid, Dictionary<string, object> args)
        {
            Component.InitComponents(uuid, revid, args);
        }

        public void AutoSetReceiveID() => Component.AutoSetReceiveID();
    }

    /// <summary>
    /// 这个字段的类型并非继承自Component但是它会以Component注册
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ComponentReferenceFiledAttribute : Attribute
    {
        public ComponentReferenceFiledAttribute()
        {
        }
    }
}