using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mvp.Messaging
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly Dictionary<int, IMessageSubscriber> subscribers = new();

        public void Subscribe(IMessageSubscriber subscriber)
        {
            var key = GetKeyForSubscriber(subscriber.GetType());

            if (subscribers.ContainsKey(key))
            {
                Debug.LogError($"Message Dispatcher: Cannot add {subscriber} because it's already subscribed.");
                return;
            }

            subscribers.Add(key, subscriber);
        }

        public void Unsubscribe(IMessageSubscriber subscriber)
        {
            var key = GetKeyForSubscriber(subscriber.GetType());

            subscribers.Remove(key);
        }

        public void DispatchMessageTo<TSubscriber, TMessage>(TMessage message) where TSubscriber : IMessageSubscriber
        {
            var key = GetKeyForSubscriber(typeof(TSubscriber));

            if (subscribers.TryGetValue(key, out IMessageSubscriber subscriber))
            {
                subscriber.ReceiveMessage(message);
            }
        }

        public void DispatchMessageToAll<TMessage>(TMessage message, bool isInReverseOrder = false)
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

        private int GetKeyForSubscriber(Type type)
        {
            return type.GetHashCode();
        }
    }
}
