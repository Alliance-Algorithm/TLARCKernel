using System.Buffers;

namespace TlarcKernel;

class TlarcArray<T> : IDisposable where T : struct
{
    T[] _data;
    readonly int[] Dimension;
    readonly int _length;
    public TlarcArray(params int[] dimension)
    {
        Dimension = dimension.Copy();
        var length = 1;
        foreach (var i in dimension)
            length *= i;
        Dimension[^1] = 1;
        for (int i = length - 2; i >= 0; i--)
            Dimension[i] = dimension[i] * Dimension[i + 1];

        _data = ArrayPool<T>.Shared.Rent(length);

    }
    public T this[params int[] indexes]
    {
        get
        {
            if (indexes.Length == 1)
                return _data[indexes[0]];
            else if (indexes.Length == _length)
            {
                int index = 0;
                for (int i = 0; i < _length; i++)
                    index += Dimension[i] * indexes[i];

                return _data[index];
            }
            else
                throw new Exception();
        }
        set
        {

            if (indexes.Length == 1)
                _data[indexes[0]] = value;
            else if (indexes.Length == _length)
            {
                int index = 0;
                for (int i = 0; i < _length; i++)
                    index += Dimension[i] * indexes[i];

                _data[index] = value;
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
            ArrayPool<T>.Shared.Return(_data);
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(false);
        GC.SuppressFinalize(this);
    }

    ~TlarcArray()
    {
        Dispose(true);
    }
}
