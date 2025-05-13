using System.Buffers;
using System.Runtime.InteropServices;
using Accord;

namespace TlarcKernel;

class TlarcArray<T> : IDisposable where T : unmanaged
{

    unsafe T* _data;
    T? _init;
    nint pointer;
    readonly int[] DimensionHelper;
    readonly int[] Dimension;
    readonly int dimensionLength;
    readonly int totalLength;
    public TlarcArray(T? init = null, params int[] dimension)
    {
        _init = init;
        Dimension = dimension.Copy();
        DimensionHelper = dimension.Copy();
        dimensionLength = dimension.Length;
        totalLength = 1;
        foreach (var i in dimension)
            totalLength *= i;
        DimensionHelper[^1] = 1;
        for (int i = DimensionHelper.Length - 2; i >= 0; i--)
            DimensionHelper[i] = dimension[i + 1] * DimensionHelper[i + 1];

        unsafe
        {
            pointer = Marshal.AllocHGlobal(sizeof(T) * totalLength);
            _data = (T*)pointer.ToPointer();
            if (init is not null)
                for (int i = 0; i < totalLength; i++)
                    _data[i] = (T)init;
        }

    }
    public T[] ToArray
    {
        get
        {
            unsafe
            {
                T[] tmp = new T[totalLength];
                fixed (void* ptr = tmp)
                {
                    Buffer.MemoryCopy(pointer.ToPointer(), ptr, totalLength * sizeof(T), totalLength * sizeof(T));
                }
                return tmp;
            }
        }
    }

    public TlarcArray<T> Clone()
    {
        TlarcArray<T> tmp = new(_init, Dimension);
        unsafe
        {
            Buffer.MemoryCopy(_data, tmp._data, sizeof(T) * totalLength, sizeof(T) * totalLength);
        }
        return tmp;
    }

    public T this[params int[] indexes]
    {
        get
        {
            if (indexes.Length == 1)
            {
                unsafe
                {
                    return _data[indexes[0]];
                }
            }
            else if (indexes.Length == dimensionLength)
            {
                int index = 0;
                for (int i = 0; i < dimensionLength; i++)
                    index += DimensionHelper[i] * indexes[i];
                unsafe
                {
                    return _data[index];
                }
            }
            else
                throw new Exception();
        }
        set
        {

            if (indexes.Length == 1)
                unsafe
                {
                    _data[indexes[0]] = value;
                }
            else if (indexes.Length == dimensionLength)
            {
                int index = 0;
                for (int i = 0; i < dimensionLength; i++)
                    index += DimensionHelper[i] * indexes[i];

                unsafe
                {
                    _data[index] = value;
                }
            }
            else
                throw new Exception();
        }
    }


    private bool disposed = false;

    public void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing) { }
            unsafe
            {
                _data = null;
            }
            Marshal.FreeHGlobal(pointer);
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~TlarcArray()
    {
        Dispose(false);
    }
}
