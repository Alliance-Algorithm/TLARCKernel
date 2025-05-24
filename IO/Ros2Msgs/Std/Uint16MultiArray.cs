using System.Collections.Concurrent;
using Rcl;


using RosType = Rosidl.Messages.Std.UInt16MultiArray;
using CSType = ushort[];

namespace TlarcKernel.IO.ROS2Msgs.Std
{
  class UInt16MultiArray(IOManager io)
  {

    CSType data = [];
    Action<CSType> callback;

    protected static bool publishFlag = false;

    IRclPublisher<RosType> publisher;
    ConcurrentQueue<CSType> receiveData = new();
    Rcl.RosMessageBuffer nativeMsg;
    IOManager _ioManager = io;

    void Subscript()
    {
      if (receiveData.Count == 0)
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

    public void Subscript(string topicName, Action<CSType> callback)
    {
      this.callback = callback;
      _ioManager.TlarcRosMsgs.Input += Subscript;
      _ioManager.RegistrySubscription(
        topicName,
        (RosType msg) =>
        {
          receiveData.Enqueue(msg.Data);
        }
      );
    }

    public void RegistryPublisher(string topicName)
    {
      publisher = Ros2Def.node.CreatePublisher<RosType>(topicName);
      nativeMsg = publisher.CreateBuffer();
      // TlarcMsgs.Output += Publish;

      Task.Run(async () =>
      {
        using var timer = Ros2Def.context.CreateTimer(
          Ros2Def.node.Clock,
          TimeSpan.FromMilliseconds(value: 1)
        );
        while (true)
        {
          await timer.WaitOneAsync(false);
          if (!publishFlag)
            continue;
          nativeMsg.AsRef<RosType.Priv>().Data = new(data.Length);
          for (int i = 0; i < data.Length; i++)
            nativeMsg.AsRef<RosType.Priv>().Data.AsSpan()[i] = data[i];
          publisher.Publish(nativeMsg);
          publishFlag = false;
        }
      });
    }

    public void Publish(CSType data)
    {
      if (publishFlag) return;
      this.data = data;
      Publish();
    }
  }
}
