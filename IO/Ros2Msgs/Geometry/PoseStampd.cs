using System.Collections.Concurrent;
using System.Numerics;
using Rcl;

namespace TlarcKernel.IO.ROS2Msgs.Geometry
{
  class PoseStampd(IOManager io)
  {
    (Vector2 pos, float Theta) data = new();
    Action<(Vector2 pos, float Theta)> callback;
    ConcurrentQueue<(Vector2 pos, float Theta)> receiveData = new();

    IRclPublisher<Rosidl.Messages.Geometry.PoseStamped> publisher;
    RosMessageBuffer nativeMsg;
    private bool publishFlag;
    IOManager _ioManager = io;

    void Subscript()
    {
      if (receiveData == null || receiveData.IsEmpty)
        return;
      while (receiveData.Count > 1)
        receiveData.TryDequeue(out _);
      callback(receiveData.First());
      receiveData.TryDequeue(out _);
    }

    void Publish()
    {
      if (publisher == null)
        return;
      publishFlag = true;
    }

    public void Subscript(string topicName, Action<(Vector2 pos, float Theta)> callback)
    {
      this.callback = callback;
      _ioManager.TlarcRosMsgs.Input += Subscript;
      _ioManager.RegistrySubscription(
        topicName,
        (Rosidl.Messages.Geometry.PoseStamped msg) =>
        {
          var q = msg.Pose.Orientation;
          double sin_cos = 2 * (q.W * q.Z + q.X * q.Y);
          double cos_cos = 1 - 2 * (q.Y * q.Y + q.Z * q.Z);
          var angle = Math.Atan2(sin_cos, cos_cos);

          receiveData.Enqueue(
            (new((float)msg.Pose.Position.X, (float)msg.Pose.Position.Y), (float)angle)
          );
        }
      );
    }

    public void RegistryPublisher(string topicName)
    {
      publisher = Ros2Def.node.CreatePublisher<Rosidl.Messages.Geometry.PoseStamped>(topicName);
      nativeMsg = publisher.CreateBuffer();

      Task.Run(async () =>
      {
        using var timer = Ros2Def.context.CreateTimer(
          Ros2Def.node.Clock,
          TimeSpan.FromMilliseconds(1)
        );
        while (true)
        {
          await timer.WaitOneAsync(false);
          if (!publishFlag)
            continue;
          nativeMsg.AsRef<Rosidl.Messages.Geometry.PoseStamped.Priv>().Pose.Position.X = data.pos.X;
          nativeMsg.AsRef<Rosidl.Messages.Geometry.PoseStamped.Priv>().Pose.Position.Y = data.pos.Y;

          var orientation = Quaterniond.AxisAngleR(Vector3d.AxisZ, data.Theta);
          nativeMsg.AsRef<Rosidl.Messages.Geometry.PoseStamped.Priv>().Pose.Orientation.X = orientation.x;
          nativeMsg.AsRef<Rosidl.Messages.Geometry.PoseStamped.Priv>().Pose.Orientation.Y = orientation.y;
          nativeMsg.AsRef<Rosidl.Messages.Geometry.PoseStamped.Priv>().Pose.Orientation.Z = orientation.z;
          nativeMsg.AsRef<Rosidl.Messages.Geometry.PoseStamped.Priv>().Pose.Orientation.W = orientation.w;

          nativeMsg.AsRef<Rosidl.Messages.Geometry.PoseStamped.Priv>().Header.FrameId.CopyFrom("tlarc");
          publisher.Publish(nativeMsg);
          publishFlag = false;
        }
      });
    }

    public void Publish((Vector2 pos, float Theta) data)
    {
      this.data = data;
      Publish();
    }
  }
}
