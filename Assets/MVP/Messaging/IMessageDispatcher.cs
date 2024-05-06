namespace Mvp.Messaging
{
    public interface IMessageDispatcher
    {
        public void Subscribe(IMessageSubscriber subscriber);
        public void Unsubscribe(IMessageSubscriber subscriber);
        public void DispatchMessageTo<TSubscriber, TMessage>(TMessage message) where TSubscriber : IMessageSubscriber;
        public void DispatchMessageToAll<TMessage>(TMessage message, bool isInReverseOrder = false);
    }
}
