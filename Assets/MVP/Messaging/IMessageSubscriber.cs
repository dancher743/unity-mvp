namespace Mvp.Messaging
{
    public interface IMessageSubscriber
    {
        void ReceiveMessage<TMessage>(TMessage message);
    }
}
