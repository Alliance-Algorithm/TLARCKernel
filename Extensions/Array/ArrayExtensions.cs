namespace TlarcKernel.Extensions.Array;

public static class ArrayExtensions
{
  public static bool Indexer(this bool[,,] array, Vector3i index) =>
    array[index.x, index.y, index.z];

  public static void Indexer(this bool[,,] array, Vector3i index, bool value) =>
    array[index.x, index.y, index.z] = value;

  public static double[] ToArray(this Vector2d vector2D) => [vector2D.x, vector2D.y];
}
