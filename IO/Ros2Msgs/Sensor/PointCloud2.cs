using System.Collections.Concurrent;
using Accord;
using Rcl;
using Rosidl.Messages.Sensor;

namespace TlarcKernel.IO.ROS2Msgs.Sensor
{
    class PointCloud2(IOManager io)
    {
        Vector4f[] data;
        Action<Vector4f[]> callback;
        ConcurrentQueue<Vector4f[]> receiveData = new();

        IOManager _ioManager = io;
        IRclPublisher<Rosidl.Messages.Sensor.PointCloud2> publisher;
        RosMessageBuffer nativeMsg;
        private bool publishFlag;

        void Subscript()
        {
            if (receiveData.IsEmpty)
                return;
            while (receiveData.Count > 1)
                receiveData.TryDequeue(out _);

            callback(receiveData.Last());
            receiveData.TryDequeue(out _);
        }

        void Publish()
        {
            if (publisher == null)
                return;
            publishFlag = true;
        }

        public void Subscript(
          string topicName,
           Action<Vector4f[]> callback
        )
        {
            this.callback = callback;
            _ioManager.TlarcRosMsgs.Input += Subscript;
            _ioManager.RegistrySubscription(
              topicName,
              (Rosidl.Messages.Sensor.PointCloud2 msg) =>
              {
                  Vector4f[] temp = new Vector4f[msg.Width];
                  unsafe
                  {
                      fixed (void* dest = &temp[0])
                      fixed (void* src = &msg.Data[0])
                          Buffer.MemoryCopy(src, dest, (int)msg.RowStep, (int)msg.RowStep);
                  }

                  receiveData.Enqueue(temp);
              }
            );
        }

        public void RegistryPublisher(string topicName) => throw new NotImplementedException();

        public void Publish((sbyte[] Map, float Resolution, uint Height, uint Width) data) => throw new NotImplementedException();
    }
}
