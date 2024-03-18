using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvp.Messaging
{
    public class MessageDispatcher
    {
        private readonly Dictionary<string, IMessageSubscriber> subscribers = new();

        public void Subscribe(IMessageSubscriber subscriber)
        {
            var key = GetKeyForSubscriber(subscriber.GetType());

            subscribers.TryAdd(key, subscriber);
        }

        public void Unsubscribe(IMessageSubscriber subscriber)
        {
            var key = GetKeyForSubscriber(subscriber.GetType());

            subscribers.Remove(key);
        }

        public void SendMessageTo<TSubscriber, TMessage>(TMessage message) where TSubscriber : IMessageSubscriber
        {
            var key = GetKeyForSubscriber(typeof(TSubscriber));

            if (subscribers.TryGetValue(key, out IMessageSubscriber subscriber))
            {
                subscriber.ReceiveMessage(message);
            }
        }

        public void SendMessageToAll<TMessage>(TMessage message, bool isInReverseOrder = false)
        {
            var allSubscribers = subscribers.Values;

            if (isInReverseOrder)
            {
                allSubscribers.Reverse();
            }

            foreach (var subscriber in allSubscribers)
            {
                subscriber.ReceiveMessage(message);
            }
        }

        private string GetKeyForSubscriber(Type type)
        {
            return type.GUID.ToString();
        }
    }
}
