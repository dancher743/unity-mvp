using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvp.Messaging
{
    public static class MessageDispatcher
    {
        private static readonly Dictionary<Type, IMessageSubscriber> subscribers = new();

        public static void Subscribe(IMessageSubscriber subscriber)
        {
            var key = GenerateKeyFor(subscriber);

            subscribers.TryAdd(key, subscriber);
        }

        public static void Unsubscribe(IMessageSubscriber subscriber)
        {
            var key = GenerateKeyFor(subscriber);

            subscribers.Remove(key);
        }

        public static void SendMessageTo<TSubscriber, TMessage>(TMessage message) where TSubscriber : IMessageSubscriber
        {
            var key = GenerateKeyFor<TSubscriber>();

            if (subscribers.TryGetValue(key, out IMessageSubscriber subscriber))
            {
                subscriber.ReceiveMessage(message);
            }
        }

        public static void SendMessageToAll<TMessage>(TMessage message, bool isInReverseOrder = false)
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

        private static Type GenerateKeyFor(IMessageSubscriber subscriber)
        {
            return subscriber.GetType();
        }

        private static Type GenerateKeyFor<TSubscriber>()
        {
            return typeof(TSubscriber);
        }
    }
}
