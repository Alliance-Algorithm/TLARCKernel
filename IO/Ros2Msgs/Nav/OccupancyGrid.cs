using System.Collections.Concurrent;
using Rcl;

namespace TlarcKernel.IO.ROS2Msgs.Nav
{
  class OccupancyGrid(IOManager io)
  {
    (sbyte[] Map, float Resolution, uint Height, uint Width) data;
    Action<(sbyte[,] Map, Vector3d Resolution, double angle, uint Height, uint Width)> callback;
    ConcurrentQueue<(
      sbyte[,] Map,
      Vector3d Resolution,
      double angle,
      uint Height,
      uint Width
    )> receiveData = new();

    IOManager _ioManager = io;
    IRclPublisher<Rosidl.Messages.Nav.OccupancyGrid> publisher;
    Rcl.RosMessageBuffer nativeMsg;
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
      Action<(sbyte[,] Map, Vector3d Position, double angle, uint Height, uint Width)> callback
    )
    {
      this.callback = callback;
      _ioManager.TlarcRosMsgs.Input += Subscript;
      _ioManager.RegistrySubscription(
        topicName,
        (Rosidl.Messages.Nav.OccupancyGrid msg) =>
        {
          (sbyte[,] Map, Vector3d Position, double angle, uint Height, uint Width) temp = new();
          var k = msg.Data;
          temp.Map = new sbyte[msg.Info.Height, msg.Info.Width];

          var q = msg.Info.Origin.Orientation;
          double sin_cos = 2 * (q.W * q.Z + q.X * q.Y);
          double cos_cos = 1 - 2 * (q.Y * q.Y + q.Z * q.Z);

          temp.angle = Math.Atan2(sin_cos, cos_cos);
          temp.Position = new(
            msg.Info.Origin.Position.X,
            msg.Info.Origin.Position.Y,
            msg.Info.Origin.Position.Z
          );
          for (int i = 0; i < msg.Info.Height; i++)
          {
            for (int j = 0; j < msg.Info.Width; j++)
            {
              temp.Map[j, i] = msg.Data[j + i * msg.Info.Width];
            }
          }

          receiveData.Enqueue(temp);
        }
      );
    }

    public void RegistryPublisher(string topicName)
    {
      publisher = Ros2Def.node.CreatePublisher<Rosidl.Messages.Nav.OccupancyGrid>(topicName);
      nativeMsg = publisher.CreateBuffer();

      Task.Run(async () =>
      {
        try
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
            var temp_map = new sbyte[data.Height * data.Width];
            for (int j = 0, width = (int)data.Height; j < width; j++)
            {
              for (int i = 0, height = (int)data.Width; i < height; i++)
              {
                temp_map[j + i * width] = data.Map[i + j * height];
              }
            }
            nativeMsg.AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>().Data.CopyFrom(temp_map);
            nativeMsg.AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>().Info.Height =
              data.Width;
            nativeMsg.AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>().Info.Width =
              data.Height;
            nativeMsg.AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>().Info.Resolution =
              data.Resolution;
            nativeMsg
              .AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>()
              .Header.FrameId.CopyFrom("tlarc");
            nativeMsg.AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>().Info.Origin.Position.X = -data.Height * data.Resolution / 2;
            nativeMsg.AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>().Info.Origin.Position.Y = -data.Width * data.Resolution / 2;
            nativeMsg.AsRef<Rosidl.Messages.Nav.OccupancyGrid.Priv>().Info.Origin.Orientation.W = 1;
            publisher.Publish(nativeMsg);
            publishFlag = false;
          }
        }
        catch (Exception e)
        {
          TlarcSystem.LogError(e.Message + '\n' + e.StackTrace);
        }
      });
    }

    public void Publish((sbyte[] Map, float Resolution, uint Height, uint Width) data)
    {
      this.data = data;
      Publish();
    }
  }
}
