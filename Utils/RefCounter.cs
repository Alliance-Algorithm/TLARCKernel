using System;
using System.Threading;
namespace TlarcKernel
{
    public class RefCounted<T>(T instance) : IDisposable where T : IDisposable
    {

        private T value = instance;
        private int refCount = 1;
        private bool disposed = false;

        public ref readonly T Instance => ref value;

        public void AddRef()
        {
            Interlocked.Increment(ref refCount);
        }

        public void Release()
        {
            if (Interlocked.Decrement(ref refCount) == 0)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free managed resources
                }
                value.Dispose();
                disposed = true;
            }
        }

        ~RefCounted()
        {
            Dispose(false);
        }
    }
    public class SharedPtr<T> : IDisposable where T : IDisposable
    {
        private RefCounted<T> _refCountedObj;
        public ref readonly T Instance => ref _refCountedObj.Instance;
        private bool disposed = false;

        public SharedPtr(RefCounted<T> refCountedObj)
        {
            _refCountedObj = refCountedObj;
            _refCountedObj.AddRef();
        }

        public void Dispose()
        {
            _refCountedObj.Release();
            disposed = true;
        }

        ~SharedPtr()
        {
            if (disposed)
                return;
            Dispose();
        }
    }
}