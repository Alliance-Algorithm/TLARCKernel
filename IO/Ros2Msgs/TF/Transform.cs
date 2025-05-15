using System.Collections.Concurrent;
using Rcl;

namespace TlarcKernel.IO.ROS2Msgs.TF
{
  static class TransformBoardcaster
  {
    static IRclPublisher<Rosidl.Messages.Tf2.TFMessage>? publisher;
    public static void Publish(string parent, string child, Vector3d translation, Quaterniond rotation)
    {
      publisher = publisher ?? Ros2Def.node.CreatePublisher<Rosidl.Messages.Tf2.TFMessage>("Tlarc");
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
    }
  }
}
