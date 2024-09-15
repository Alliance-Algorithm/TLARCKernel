using g4;

namespace TlarcKernel.Extensions.Array;

public static class ArrayExtensions
{
    public static bool Indexer(this bool[,,] array, Vector3i index) => array[index.x, index.y, index.z];
    public static void Indexer(this bool[,,] array, Vector3i index, bool value) => array[index.x, index.y, index.z] = value;
}