//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by ros2cs.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

#nullable enable

namespace Rosidl.Messages.Sensor
{
    /// <summary>
    /// This is a message that holds data to describe the state of a set of torque controlled joints.
    /// 
    /// The state of each joint (revolute or prismatic) is defined by:
    /// * the position of the joint (rad or m),
    /// * the velocity of the joint (rad/s or m/s) and
    /// * the effort that is applied in the joint (Nm or N).
    /// 
    /// Each joint is uniquely identified by its name
    /// The header specifies the time at which the joint states were recorded. All the joint states
    /// in one message have to be recorded at the same time.
    /// 
    /// This message consists of a multiple arrays, one for each part of the joint state.
    /// The goal is to make each of the fields optional. When e.g. your joints have no
    /// effort associated with them, you can leave the effort array empty.
    /// 
    /// All arrays in this message should have the same size, or be empty.
    /// This is the only way to uniquely associate the joint name with the correct
    /// states.
    /// </summary>
    /// <remarks>
    /// Message interface definition for <c>sensor_msgs/msg/JointState</c>.
    /// </remarks>
    [global::Rosidl.Runtime.TypeSupportAttribute("sensor_msgs/msg/JointState")]
    public unsafe partial class JointState : global::Rosidl.Runtime.IMessage
    {
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static string TypeSupportName => "sensor_msgs/msg/JointState";
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static global::Rosidl.Runtime.TypeSupportHandle GetTypeSupportHandle()
        {
            return new global::Rosidl.Runtime.TypeSupportHandle(_PInvoke(), global::Rosidl.Runtime.HandleType.Message);
            
            [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
            [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_typesupport_c", EntryPoint = "rosidl_typesupport_c__get_message_type_support_handle__sensor_msgs__msg__JointState")]
            static extern nint _PInvoke();
        }
        
        /// <summary>
        /// Create a new instance of <see cref="JointState"/> with fields initialized to specified values.
        /// </summary>
        /// <param name='header'>
        /// Originally defined as: <c><![CDATA[std_msgs/msg/Header header]]></c>
        /// </param>
        /// <param name='name'>
        /// Originally defined as: <c><![CDATA[string[] name]]></c>
        /// </param>
        /// <param name='position'>
        /// Originally defined as: <c><![CDATA[float64[] position]]></c>
        /// </param>
        /// <param name='velocity'>
        /// Originally defined as: <c><![CDATA[float64[] velocity]]></c>
        /// </param>
        /// <param name='effort'>
        /// Originally defined as: <c><![CDATA[float64[] effort]]></c>
        /// </param>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public JointState(
            global::Rosidl.Messages.Std.Header? @header = null,
            string[]? @name = null,
            double[]? @position = null,
            double[]? @velocity = null,
            double[]? @effort = null
        )
        {
            Header = @header ?? new global::Rosidl.Messages.Std.Header();
            Name = @name ?? global::System.Array.Empty<string>();
            Position = @position ?? global::System.Array.Empty<double>();
            Velocity = @velocity ?? global::System.Array.Empty<double>();
            Effort = @effort ?? global::System.Array.Empty<double>();
        }
        
        
        /// <summary>
        /// Create a new instance of <see cref="JointState"/>, and copy its data from the specified <see cref="Priv"/> structure.
        /// </summary>
        /// <param name="priv">The <see cref="Priv"/> structure to be copied from.</param>
        /// <param name="textEncoding">Text encoding of the strings in the <see cref="Priv"/> structure and its containing structures, if any.</param>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public JointState(in Priv priv, global::System.Text.Encoding textEncoding)
        {
            this.Header = new global::Rosidl.Messages.Std.Header(in priv.Header, textEncoding);
        
            this.Name = new string[priv.Name.Size];
            var Name_span = priv.Name.AsSpan();
            for (int __i = 0; __i < this.Name.Length; __i++)
            {
                this.Name[__i] = global::Rosidl.Runtime.Interop.StringMarshal.CreatePooledString(Name_span[__i].AsSpan(), textEncoding);
            }
        
            this.Position = priv.Position.AsSpan().ToArray();
            this.Velocity = priv.Velocity.AsSpan().ToArray();
            this.Effort = priv.Effort.AsSpan().ToArray();
        }
        
        
        /// <summary>
        /// Create a new instance of <see cref="JointState"/> with fields initialized to default values.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public JointState()
        {
            Header = new global::Rosidl.Messages.Std.Header();
            Name = global::System.Array.Empty<string>();
            Position = global::System.Array.Empty<double>();
            Velocity = global::System.Array.Empty<double>();
            Effort = global::System.Array.Empty<double>();
        }
        
        
        /// <summary>
        /// Originally defined as: <c><![CDATA[std_msgs/msg/Header header]]></c>
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public global::Rosidl.Messages.Std.Header Header { get; set; }
        
        /// <summary>
        /// Originally defined as: <c><![CDATA[string[] name]]></c>
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public string[] Name { get; set; }
        
        /// <summary>
        /// Originally defined as: <c><![CDATA[float64[] position]]></c>
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public double[] Position { get; set; }
        
        /// <summary>
        /// Originally defined as: <c><![CDATA[float64[] velocity]]></c>
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public double[] Velocity { get; set; }
        
        /// <summary>
        /// Originally defined as: <c><![CDATA[float64[] effort]]></c>
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public double[] Effort { get; set; }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public void WriteTo(nint data, global::System.Text.Encoding textEncoding)
        {
            WriteTo(ref global::System.Runtime.CompilerServices.Unsafe.AsRef<Priv>(data.ToPointer()), textEncoding);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public void WriteTo(ref Priv priv, global::System.Text.Encoding textEncoding)
        {
            this.Header.WriteTo(ref priv.Header, textEncoding);
            
            priv.Name = new global::Rosidl.Runtime.Interop.CStringSequence(this.Name.Length);
            var Name_span = priv.Name.AsSpan();
            for (int __i = 0; __i < this.Name.Length; __i++)
            {
                Name_span[__i].CopyFrom(this.Name[__i], textEncoding);
            }
            
            priv.Position.CopyFrom(this.Position);
            priv.Velocity.CopyFrom(this.Velocity);
            priv.Effort.CopyFrom(this.Effort);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static global::Rosidl.Runtime.IMessage CreateFrom(nint data, global::System.Text.Encoding textEncoding)
        {
            return new JointState(in global::System.Runtime.CompilerServices.Unsafe.AsRef<Priv>(data.ToPointer()), textEncoding);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static nint UnsafeCreate()
        {
            return new(Priv.Create());
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static void UnsafeDestroy(nint data)
        {
            Priv.Destroy((Priv*)data);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static bool UnsafeInitialize(nint data)
        {
            return Priv.TryInitialize(out System.Runtime.CompilerServices.Unsafe.AsRef<Priv>(data.ToPointer()));
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static void UnsafeFinalize(nint data)
        {
            Priv.Finalize(ref System.Runtime.CompilerServices.Unsafe.AsRef<Priv>(data.ToPointer()));
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static bool UnsafeInitializeSequence(int size, nint data)
        {
            return PrivSequence.TryInitialize(size, out System.Runtime.CompilerServices.Unsafe.AsRef<PrivSequence>(data.ToPointer()));
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static void UnsafeFinalizeSequence(nint data)
        {
            PrivSequence.Finalize(ref System.Runtime.CompilerServices.Unsafe.AsRef<PrivSequence>(data.ToPointer()));
        }
        
        /// <summary>
        /// This is a message that holds data to describe the state of a set of torque controlled joints.
        /// 
        /// The state of each joint (revolute or prismatic) is defined by:
        /// * the position of the joint (rad or m),
        /// * the velocity of the joint (rad/s or m/s) and
        /// * the effort that is applied in the joint (Nm or N).
        /// 
        /// Each joint is uniquely identified by its name
        /// The header specifies the time at which the joint states were recorded. All the joint states
        /// in one message have to be recorded at the same time.
        /// 
        /// This message consists of a multiple arrays, one for each part of the joint state.
        /// The goal is to make each of the fields optional. When e.g. your joints have no
        /// effort associated with them, you can leave the effort array empty.
        /// 
        /// All arrays in this message should have the same size, or be empty.
        /// This is the only way to uniquely associate the joint name with the correct
        /// states.
        /// </summary>
        /// <remarks>
        /// Blittable native structure for <c>sensor_msgs/msg/JointState</c>.
        /// </remarks>
        [global::System.Runtime.InteropServices.StructLayoutAttribute(global::System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct Priv : global::System.IEquatable<Priv>, global::System.IDisposable
        {
            /// <summary>
            /// Originally defined as: <c><![CDATA[std_msgs/msg/Header header]]></c>
            /// </summary>
            public global::Rosidl.Messages.Std.Header.Priv Header;
            
            /// <summary>
            /// Originally defined as: <c><![CDATA[string[] name]]></c>
            /// </summary>
            public global::Rosidl.Runtime.Interop.CStringSequence Name;
            
            /// <summary>
            /// Originally defined as: <c><![CDATA[float64[] position]]></c>
            /// </summary>
            public global::Rosidl.Runtime.Interop.DoubleSequence Position;
            
            /// <summary>
            /// Originally defined as: <c><![CDATA[float64[] velocity]]></c>
            /// </summary>
            public global::Rosidl.Runtime.Interop.DoubleSequence Velocity;
            
            /// <summary>
            /// Originally defined as: <c><![CDATA[float64[] effort]]></c>
            /// </summary>
            public global::Rosidl.Runtime.Interop.DoubleSequence Effort;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public Priv()
            {
                ThrowIfNonSuccess(TryInitialize(out this));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public Priv(Priv src)
                : this(in src)
            {
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public Priv(in Priv src)
                : this()
            {
                CopyFrom(in src); 
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public Priv(Priv* src)
                : this()
            {
                CopyFrom(src); 
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void Dispose()
            {
                Finalize(ref this);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void CopyFrom(Priv src)
            {
                ThrowIfNonSuccess(TryCopy(in src, out this));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void CopyFrom(in Priv src)
            {
                ThrowIfNonSuccess(TryCopy(in src, out this));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void CopyFrom(Priv* src)
            {
                fixed (Priv* pThis = &this)
                {
                    ThrowIfNonSuccess(TryCopy(src, pThis));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool TryCopy(in Priv input, out Priv output)
            {
                fixed (Priv* pInput = &input, pOutput = &output)
                {
                    return TryCopy(pInput, pOutput);
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public bool Equals(Priv other)
            {
                return Priv.AreEqual(in other, in this);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public override bool Equals(object? obj) => obj is Priv s ? this.Equals(s) : false;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public override int GetHashCode()
            {
                var __hashCode = new global::System.HashCode();
                __hashCode.Add(this.Header);
                __hashCode.Add(this.Name);
                __hashCode.Add(this.Position);
                __hashCode.Add(this.Velocity);
                __hashCode.Add(this.Effort);
                return __hashCode.ToHashCode();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static bool operator ==(Priv lhs, Priv rhs)
            {
                return lhs.Equals(rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static bool operator !=(Priv lhs, Priv rhs)
            {
                return !(lhs == rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static Priv* Create()
            {
                return _PInvoke();
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__create")]
                static extern Priv* _PInvoke();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void Destroy(Priv* msg)
            {
                _PInvoke(msg);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__destroy")]
                static extern void _PInvoke(Priv* msg);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static bool TryInitialize(out Priv msg)
            {
                fixed (Priv* pMsg = &msg)
                {
                    return _PInvoke(pMsg);
                }
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__init")]
                static extern bool _PInvoke(Priv* msg);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void Finalize(ref Priv msg)
            {
                fixed (Priv* pMsg = &msg)
                {
                    _PInvoke(pMsg);
                }
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__fini")]
                static extern void _PInvoke(Priv* msg);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool AreEqual(in Priv lhs, in Priv rhs)
            {
                fixed (Priv* plhs = &lhs, prhs = &rhs)
                {
                    return _PInvoke(plhs, prhs);
                }
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__are_qual")]
                static extern bool _PInvoke(Priv* lhs, Priv* rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool TryCopy(Priv* input, Priv* output)
            {
                return _PInvoke(input, output);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__copy")]
                static extern bool _PInvoke(Priv* input, Priv* output);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void ThrowIfNonSuccess(bool ret, [global::System.Runtime.CompilerServices.CallerMemberNameAttribute]
            string caller = "")
            {
                if (!ret)
                {
                    throw new global::Rosidl.Runtime.RosidlException($"An error occurred when calling 'global::Rosidl.Messages.Sensor.JointState.Priv.{caller}'.");
                }
            }
        }
        
        /// <summary>
        /// This is a message that holds data to describe the state of a set of torque controlled joints.
        /// 
        /// The state of each joint (revolute or prismatic) is defined by:
        /// * the position of the joint (rad or m),
        /// * the velocity of the joint (rad/s or m/s) and
        /// * the effort that is applied in the joint (Nm or N).
        /// 
        /// Each joint is uniquely identified by its name
        /// The header specifies the time at which the joint states were recorded. All the joint states
        /// in one message have to be recorded at the same time.
        /// 
        /// This message consists of a multiple arrays, one for each part of the joint state.
        /// The goal is to make each of the fields optional. When e.g. your joints have no
        /// effort associated with them, you can leave the effort array empty.
        /// 
        /// All arrays in this message should have the same size, or be empty.
        /// This is the only way to uniquely associate the joint name with the correct
        /// states.
        /// </summary>
        /// <remarks>
        /// Blittable native sequence structure for <c>sensor_msgs/msg/JointState</c>.
        /// </remarks>
        [global::System.Runtime.InteropServices.StructLayoutAttribute(global::System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct PrivSequence : global::System.IEquatable<PrivSequence>, global::System.IDisposable
        {
            private Priv* __data;
            
            private nuint __size;
            
            private nuint __capacity;
            
            public int Size => (int)__size;
            
            public int Capcacity => (int)__capacity;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public PrivSequence()
                : this(0)
            {
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public PrivSequence(int size)
            {
                ThrowIfNonSuccess(TryInitialize(size, out this));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public PrivSequence(PrivSequence src)
                : this(in src)
            {
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public PrivSequence(in PrivSequence src)
                : this()
            {
                CopyFrom(in src); 
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public PrivSequence(PrivSequence* src)
                : this()
            {
                CopyFrom(src); 
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public PrivSequence(System.ReadOnlySpan<Priv> src)
                : this(src.Length)
            {
                src.CopyTo(AsSpan());
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void Dispose()
            {
                Finalize(ref this);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public System.Span<Priv> AsSpan()
            {
                return new(__data, Size);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void CopyFrom(System.ReadOnlySpan<Priv> src)
            {
                Finalize(ref this);
                ThrowIfNonSuccess(TryInitialize(src.Length, out this));
                src.CopyTo(AsSpan());
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void CopyFrom(PrivSequence src)
            {
                ThrowIfNonSuccess(TryCopy(in src, out this));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void CopyFrom(in PrivSequence src)
            {
                ThrowIfNonSuccess(TryCopy(in src, out this));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public void CopyFrom(PrivSequence* src)
            {
                fixed (PrivSequence* pThis = &this)
                {
                    ThrowIfNonSuccess(TryCopy(src, pThis));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool TryCopy(in PrivSequence input, out PrivSequence output)
            {
                fixed (PrivSequence* pInput = &input, pOutput = &output)
                {
                    return TryCopy(pInput, pOutput);
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public bool Equals(PrivSequence other)
            {
                return PrivSequence.AreEqual(in other, in this);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public override bool Equals(object? obj) => obj is PrivSequence s ? this.Equals(s) : false;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public override int GetHashCode()
            {
                return global::System.HashCode.Combine((nint)__data, __size, __capacity);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static bool operator ==(PrivSequence lhs, PrivSequence rhs)
            {
                return lhs.Equals(rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static bool operator !=(PrivSequence lhs, PrivSequence rhs)
            {
                return !(lhs == rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static PrivSequence* Create()
            {
                return _PInvoke();
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__Sequence__create")]
                static extern PrivSequence* _PInvoke();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void Destroy(PrivSequence* msg)
            {
                _PInvoke(msg);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__Sequence__destroy")]
                static extern void _PInvoke(PrivSequence* msg);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static bool TryInitialize(int size, out PrivSequence msg)
            {
                fixed (PrivSequence* pMsg = &msg)
                {
                    return _PInvoke(pMsg, (uint)size);
                }
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__Sequence__init")]
                static extern bool _PInvoke(PrivSequence* msg, nuint size);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void Finalize(ref PrivSequence msg)
            {
                fixed (PrivSequence* pMsg = &msg)
                {
                    _PInvoke(pMsg);
                }
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__Sequence__fini")]
                static extern void _PInvoke(PrivSequence* msg);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool AreEqual(in PrivSequence lhs, in PrivSequence rhs)
            {
                fixed (PrivSequence* plhs = &lhs, prhs = &rhs)
                {
                    return _PInvoke(plhs, prhs);
                }
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__Sequence__are_qual")]
                static extern bool _PInvoke(PrivSequence* lhs, PrivSequence* rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool TryCopy(PrivSequence* input, PrivSequence* output)
            {
                return _PInvoke(input, output);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__JointState__Sequence__copy")]
                static extern bool _PInvoke(PrivSequence* input, PrivSequence* output);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void ThrowIfNonSuccess(bool ret, [global::System.Runtime.CompilerServices.CallerMemberNameAttribute]
            string caller = "")
            {
                if (!ret)
                {
                    throw new global::Rosidl.Runtime.RosidlException($"An error occurred when calling 'global::Rosidl.Messages.Sensor.JointState.PrivSequence.{caller}'.");
                }
            }
        }
    }
}
