using System.Collections.Concurrent;
using Rcl;

namespace TlarcKernel.IO.ROS2Msgs.Std
{
  class UInt8(IOManager io)
  {
    byte data = 0;
    Action<byte> callback;

    protected static bool publishFlag = false;

    IRclPublisher<Rosidl.Messages.Std.UInt8> publisher;
    ConcurrentQueue<byte> receiveData = new();
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
      nativeMsg.AsRef<Rosidl.Messages.Std.UInt8.Priv>().Data = data;
      publishFlag = true;
    }

    public void Subscript(string topicName, Action<byte> callback)
    {
      this.callback = callback;
      _ioManager.TlarcRosMsgs.Input += Subscript;
      _ioManager.RegistrySubscription(
        topicName,
        (Rosidl.Messages.Std.UInt8 msg) =>
        {
          receiveData.Enqueue(msg.Data);
        }
      );
    }

    public void RegistryPublisher(string topicName)
    {
      publisher = Ros2Def.node.CreatePublisher<Rosidl.Messages.Std.UInt8>(topicName);
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
          nativeMsg.AsRef<Rosidl.Messages.Std.UInt8.Priv>().Data = data;
          publisher.Publish(nativeMsg);
          publishFlag = false;
        }
      });
    }

    public void Publish(byte data)
    {
      this.data = data;
      Publish();
    }
  }
}
