namespace Mvp
{
    public interface IMessageSubscriber
    {
        void ReceiveMessage<TMessage>(TMessage message);
    }
}
