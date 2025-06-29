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
    /// Single range reading from an active ranger that emits energy and reports
    /// one range reading that is valid along an arc at the distance measured.
    /// This message is  not appropriate for laser scanners. See the LaserScan
    /// message if you are working with a laser scanner.
    /// 
    /// This message also can represent a fixed-distance (binary) ranger.  This
    /// sensor will have min_range===max_range===distance of detection.
    /// These sensors follow REP 117 and will output -Inf if the object is detected
    /// and +Inf if the object is outside of the detection range.
    /// </summary>
    /// <remarks>
    /// Message interface definition for <c>sensor_msgs/msg/Range</c>.
    /// </remarks>
    [global::Rosidl.Runtime.TypeSupportAttribute("sensor_msgs/msg/Range")]
    public unsafe partial class Range : global::Rosidl.Runtime.IMessage
    {
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static string TypeSupportName => "sensor_msgs/msg/Range";
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static global::Rosidl.Runtime.TypeSupportHandle GetTypeSupportHandle()
        {
            return new global::Rosidl.Runtime.TypeSupportHandle(_PInvoke(), global::Rosidl.Runtime.HandleType.Message);
            
            [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
            [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_typesupport_c", EntryPoint = "rosidl_typesupport_c__get_message_type_support_handle__sensor_msgs__msg__Range")]
            static extern nint _PInvoke();
        }
        
        /// <summary>
        /// Create a new instance of <see cref="Range"/> with fields initialized to specified values.
        /// </summary>
        /// <param name='header'>
        /// timestamp in the header is the time the ranger
        /// <para>(originally defined as: <c><![CDATA[std_msgs/msg/Header header]]></c>)</para>
        /// </param>
        /// <param name='radiationType'>
        /// the type of radiation used by the sensor
        /// <para>(originally defined as: <c><![CDATA[uint8 radiation_type]]></c>)</para>
        /// </param>
        /// <param name='fieldOfView'>
        /// the size of the arc that the distance reading is
        /// <para>(originally defined as: <c><![CDATA[float32 field_of_view]]></c>)</para>
        /// </param>
        /// <param name='minRange'>
        /// minimum range value [m]
        /// <para>(originally defined as: <c><![CDATA[float32 min_range]]></c>)</para>
        /// </param>
        /// <param name='maxRange'>
        /// maximum range value [m]
        /// <para>(originally defined as: <c><![CDATA[float32 max_range]]></c>)</para>
        /// </param>
        /// <param name='range'>
        /// range data [m]
        /// <para>(originally defined as: <c><![CDATA[float32 range]]></c>)</para>
        /// </param>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public Range(
            global::Rosidl.Messages.Std.Header? @header = null,
            byte @radiationType = 0,
            float @fieldOfView = 0f,
            float @minRange = 0f,
            float @maxRange = 0f,
            float @range = 0f
        )
        {
            Header = @header ?? new global::Rosidl.Messages.Std.Header();
            RadiationType = @radiationType;
            FieldOfView = @fieldOfView;
            MinRange = @minRange;
            MaxRange = @maxRange;
            Range_ = @range;
        }
        
        
        /// <summary>
        /// Create a new instance of <see cref="Range"/>, and copy its data from the specified <see cref="Priv"/> structure.
        /// </summary>
        /// <param name="priv">The <see cref="Priv"/> structure to be copied from.</param>
        /// <param name="textEncoding">Text encoding of the strings in the <see cref="Priv"/> structure and its containing structures, if any.</param>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public Range(in Priv priv, global::System.Text.Encoding textEncoding)
        {
            this.Header = new global::Rosidl.Messages.Std.Header(in priv.Header, textEncoding);
            this.RadiationType = priv.RadiationType;
            this.FieldOfView = priv.FieldOfView;
            this.MinRange = priv.MinRange;
            this.MaxRange = priv.MaxRange;
            this.Range_ = priv.Range_;
        }
        
        
        /// <summary>
        /// Create a new instance of <see cref="Range"/> with fields initialized to default values.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public Range()
        {
            Header = new global::Rosidl.Messages.Std.Header();
            RadiationType = 0;
            FieldOfView = 0f;
            MinRange = 0f;
            MaxRange = 0f;
            Range_ = 0f;
        }
        
        
        /// <summary>
        /// Radiation type enums
        /// If you want a value added to this list, send an email to the ros-users list
        /// </summary>
        /// <remarks>
        /// Originally defined as: <c><![CDATA[uint8 ULTRASOUND = 0]]></c>
        /// </remarks>
        public const byte ULTRASOUND = 0;
        
        /// <summary>
        /// Originally defined as: <c><![CDATA[uint8 INFRARED = 1]]></c>
        /// </summary>
        public const byte INFRARED = 1;
        
        /// <summary>
        /// timestamp in the header is the time the ranger
        /// </summary>
        /// <remarks>
        /// Originally defined as: <c><![CDATA[std_msgs/msg/Header header]]></c>
        /// </remarks>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public global::Rosidl.Messages.Std.Header Header { get; set; }
        
        /// <summary>
        /// the type of radiation used by the sensor
        /// </summary>
        /// <remarks>
        /// Originally defined as: <c><![CDATA[uint8 radiation_type]]></c>
        /// </remarks>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public byte RadiationType { get; set; }
        
        /// <summary>
        /// the size of the arc that the distance reading is
        /// </summary>
        /// <remarks>
        /// Originally defined as: <c><![CDATA[float32 field_of_view]]></c>
        /// </remarks>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public float FieldOfView { get; set; }
        
        /// <summary>
        /// minimum range value [m]
        /// </summary>
        /// <remarks>
        /// Originally defined as: <c><![CDATA[float32 min_range]]></c>
        /// </remarks>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public float MinRange { get; set; }
        
        /// <summary>
        /// maximum range value [m]
        /// </summary>
        /// <remarks>
        /// Originally defined as: <c><![CDATA[float32 max_range]]></c>
        /// </remarks>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public float MaxRange { get; set; }
        
        /// <summary>
        /// range data [m]
        /// </summary>
        /// <remarks>
        /// Originally defined as: <c><![CDATA[float32 range]]></c>
        /// </remarks>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public float Range_ { get; set; }
        
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
            priv.RadiationType = this.RadiationType;
            priv.FieldOfView = this.FieldOfView;
            priv.MinRange = this.MinRange;
            priv.MaxRange = this.MaxRange;
            priv.Range_ = this.Range_;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
        public static global::Rosidl.Runtime.IMessage CreateFrom(nint data, global::System.Text.Encoding textEncoding)
        {
            return new Range(in global::System.Runtime.CompilerServices.Unsafe.AsRef<Priv>(data.ToPointer()), textEncoding);
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
        /// Single range reading from an active ranger that emits energy and reports
        /// one range reading that is valid along an arc at the distance measured.
        /// This message is  not appropriate for laser scanners. See the LaserScan
        /// message if you are working with a laser scanner.
        /// 
        /// This message also can represent a fixed-distance (binary) ranger.  This
        /// sensor will have min_range===max_range===distance of detection.
        /// These sensors follow REP 117 and will output -Inf if the object is detected
        /// and +Inf if the object is outside of the detection range.
        /// </summary>
        /// <remarks>
        /// Blittable native structure for <c>sensor_msgs/msg/Range</c>.
        /// </remarks>
        [global::System.Runtime.InteropServices.StructLayoutAttribute(global::System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct Priv : global::System.IEquatable<Priv>, global::System.IDisposable
        {
            /// <summary>
            /// timestamp in the header is the time the ranger
            /// </summary>
            /// <remarks>
            /// Originally defined as: <c><![CDATA[std_msgs/msg/Header header]]></c>
            /// </remarks>
            public global::Rosidl.Messages.Std.Header.Priv Header;
            
            /// <summary>
            /// the type of radiation used by the sensor
            /// </summary>
            /// <remarks>
            /// Originally defined as: <c><![CDATA[uint8 radiation_type]]></c>
            /// </remarks>
            public byte RadiationType;
            
            /// <summary>
            /// the size of the arc that the distance reading is
            /// </summary>
            /// <remarks>
            /// Originally defined as: <c><![CDATA[float32 field_of_view]]></c>
            /// </remarks>
            public float FieldOfView;
            
            /// <summary>
            /// minimum range value [m]
            /// </summary>
            /// <remarks>
            /// Originally defined as: <c><![CDATA[float32 min_range]]></c>
            /// </remarks>
            public float MinRange;
            
            /// <summary>
            /// maximum range value [m]
            /// </summary>
            /// <remarks>
            /// Originally defined as: <c><![CDATA[float32 max_range]]></c>
            /// </remarks>
            public float MaxRange;
            
            /// <summary>
            /// range data [m]
            /// </summary>
            /// <remarks>
            /// Originally defined as: <c><![CDATA[float32 range]]></c>
            /// </remarks>
            public float Range_;
            
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
                __hashCode.Add(this.RadiationType);
                __hashCode.Add(this.FieldOfView);
                __hashCode.Add(this.MinRange);
                __hashCode.Add(this.MaxRange);
                __hashCode.Add(this.Range_);
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__create")]
                static extern Priv* _PInvoke();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void Destroy(Priv* msg)
            {
                _PInvoke(msg);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__destroy")]
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__init")]
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__fini")]
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__are_qual")]
                static extern bool _PInvoke(Priv* lhs, Priv* rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool TryCopy(Priv* input, Priv* output)
            {
                return _PInvoke(input, output);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__copy")]
                static extern bool _PInvoke(Priv* input, Priv* output);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void ThrowIfNonSuccess(bool ret, [global::System.Runtime.CompilerServices.CallerMemberNameAttribute]
            string caller = "")
            {
                if (!ret)
                {
                    throw new global::Rosidl.Runtime.RosidlException($"An error occurred when calling 'global::Rosidl.Messages.Sensor.Range.Priv.{caller}'.");
                }
            }
        }
        
        /// <summary>
        /// Single range reading from an active ranger that emits energy and reports
        /// one range reading that is valid along an arc at the distance measured.
        /// This message is  not appropriate for laser scanners. See the LaserScan
        /// message if you are working with a laser scanner.
        /// 
        /// This message also can represent a fixed-distance (binary) ranger.  This
        /// sensor will have min_range===max_range===distance of detection.
        /// These sensors follow REP 117 and will output -Inf if the object is detected
        /// and +Inf if the object is outside of the detection range.
        /// </summary>
        /// <remarks>
        /// Blittable native sequence structure for <c>sensor_msgs/msg/Range</c>.
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__Sequence__create")]
                static extern PrivSequence* _PInvoke();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void Destroy(PrivSequence* msg)
            {
                _PInvoke(msg);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__Sequence__destroy")]
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__Sequence__init")]
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__Sequence__fini")]
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
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__Sequence__are_qual")]
                static extern bool _PInvoke(PrivSequence* lhs, PrivSequence* rhs);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            private static bool TryCopy(PrivSequence* input, PrivSequence* output)
            {
                return _PInvoke(input, output);
                
                [global::System.Runtime.InteropServices.SuppressGCTransitionAttribute]
                [global::System.Runtime.InteropServices.DllImportAttribute("sensor_msgs__rosidl_generator_c", EntryPoint = "sensor_msgs__msg__Range__Sequence__copy")]
                static extern bool _PInvoke(PrivSequence* input, PrivSequence* output);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ros2cs", "1.4.0+866072750999979fa04a21d1d2f84d5346ef2c35")]
            public static void ThrowIfNonSuccess(bool ret, [global::System.Runtime.CompilerServices.CallerMemberNameAttribute]
            string caller = "")
            {
                if (!ret)
                {
                    throw new global::Rosidl.Runtime.RosidlException($"An error occurred when calling 'global::Rosidl.Messages.Sensor.Range.PrivSequence.{caller}'.");
                }
            }
        }
    }
}
