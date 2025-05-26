using System.Collections.Concurrent;
using Rcl;

namespace TlarcKernel.IO.ROS2Msgs.TF
{
  static class TransformBoardcaster
  {
    static IRclPublisher<Rosidl.Messages.Tf2.TFMessage>? publisher;
    static event Action Publishers;

    public static void Publish(string parent, string child, Vector3d translation, Quaterniond rotation)
    {
      if (publisher == null)
      {
        publisher = Ros2Def.node.CreatePublisher<Rosidl.Messages.Tf2.TFMessage>("Tlarc");
        Task.Run(async () =>
        {

          using var timer = Ros2Def.context.CreateTimer(
            Ros2Def.node.Clock,
            TimeSpan.FromSeconds(1)
          );
          while (true)
          {
            await timer.WaitOneAsync(false);
            Publishers();
          }
        }
        );
      }

      Publishers += () =>
      {
        RosMessageBuffer nativeMsg = publisher.CreateBuffer();
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms = new(1);

        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Header.FrameId.CopyFrom(parent);
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].ChildFrameId.CopyFrom(child);
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Transform.Rotation.X = rotation.x;
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Transform.Rotation.Y = rotation.y;
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Transform.Rotation.Z = rotation.z;
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Transform.Rotation.W = rotation.w;
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Transform.Translation.X = translation.x;
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Transform.Translation.Y = translation.y;
        nativeMsg.AsRef<Rosidl.Messages.Tf2.TFMessage.Priv>().Transforms.AsSpan()[0].Transform.Translation.Z = translation.z;
        publisher.Publish(nativeMsg);
        nativeMsg.Dispose();
      };

    }
  }
}
