namespace TlarcKernel.IO.ProcessCommunicateInterfaces
{
    public interface IReadOnlySubscription<T> : ISubscription where T : notnull
    {
        public SharedPtr<RentData<T>>? Rent { get; }
    }
    public interface IReadOnlyPublish<T> : IPublisher where T : notnull
    {
        public void LoadInstance(ref T instance);
    }

    public abstract class ReadOnlyInterfaceBase<T>(string InterfaceName) : IReadOnlySubscription<T>, IReadOnlyPublish<T> where T : notnull
    {
        public SharedPtr<RentData<T>>? Rent => rent == null ? null : new SharedPtr<RentData<T>>(rent);
        protected RefCounted<RentData<T>>? rent;
        public string InterfaceName { get => name; }


        public string name = InterfaceName;

        public abstract void LoadInstance(ref T instance);

    }
    class ReadOnlyReferenceInterface<T>(string InterfaceName) : ReadOnlyInterfaceBase<T>(InterfaceName) where T : class
    {
        public override void LoadInstance(ref T instance)
        {
            throw new NotImplementedException();
        }
    }
    class ReadOnlyValueInterface<T>(string InterfaceName) : ReadOnlyInterfaceBase<T>(InterfaceName) where T : struct
    {
        public override void LoadInstance(ref T instance)
        {
            throw new NotImplementedException();
        }
    }
    class ReadOnlyUnmanagedInterfacePublisher<T>(string InterfaceName) : ReadOnlyInterfaceBase<T>(InterfaceName) where T : IDisposable
    {
        public override void LoadInstance(ref T instance)
        {
            var r = rent;
            rent = new(new(instance, true));
            r?.Release();
            instance = default;
        }

    }
    class ReadOnlyUnmanagedSubscription<T>(string InterfaceName) : IReadOnlySubscription<T>, ISubscriptionFormPublisher where T : IDisposable
    {
        public SharedPtr<RentData<T>>? Rent => instance is null ? null : instance.Rent;

        public string InterfaceName => name;

        IReadOnlySubscription<T>? instance => Instance as IReadOnlySubscription<T>;
        public IPublisher Instance { get; set; }

        public string name = InterfaceName;


    }
}