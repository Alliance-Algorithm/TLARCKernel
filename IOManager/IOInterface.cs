using System;
using System.Reflection;
using Rcl;
using Rcl.Logging;
using Rcl.Parameters;
using Rosidl.Messages.Geometry;
using Rosidl.Runtime;

namespace AllianceDM.IO
{
    internal sealed class IOManager() : Component(0, [], [])
    {
        struct MessageContainer(IMessage msg, string name)
        {
            internal IMessage Message = msg;
            internal string Name = name;
        }

        bool _update = false;
        public delegate void MessageHandler<T>(T msg) where T : IMessage;
        public static void RegistryMassage<T>(string name, MessageHandler<T> handler) where T : IMessage
        {
            Task t1 = Task.Run(() => RecieveTask(name, handler));
        }

        public IOManager(uint uuid, uint[] recvid, string[] args) : this()
        {
            Ros2Def.node.Logger.LogFatal("IOManager Could Not Build by User");
            Environment.Exit(-1);
        }
        public override void Awake()
        {
        }
        public static async void RecieveTask<T>(string name, MessageHandler<T> handler) where T : IMessage
        {
            using var subscription = Ros2Def.node.CreateSubscription<T>(name);
            bool l = false;
            await foreach (var i in subscription.ReadAllAsync())
            {
                if (l)
                    continue;
                l = true;
                handler(i);
                l = false;
            }
            Console.WriteLine(name + ":Registry");
        }


        public override void Update()
        {
            _update = true;
        }
        public override void Echo()
        {
            _update = false;
        }

    }
}