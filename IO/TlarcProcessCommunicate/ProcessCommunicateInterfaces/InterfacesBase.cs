namespace TlarcKernel.IO.ProcessCommunicateInterfaces
{
    public class RentData<T>(T value, bool disposable = false) : IDisposable where T : notnull
    {
        readonly public bool Disposable = disposable;
        T _value = value;

        public ref readonly T Value => ref _value;

        void IDisposable.Dispose()
        {
            if (Disposable)
                ((IDisposable)_value).Dispose();
        }
    }
    public interface ICommunicateInterface
    {
        public string InterfaceName { get; }
    }
    public interface ISubscription : ICommunicateInterface;
    public interface IPublisher : ISubscription;
    public interface ISubscriptionFormPublisher : ISubscription
    {
        protected IPublisher Instance { get; set; }
    };
}