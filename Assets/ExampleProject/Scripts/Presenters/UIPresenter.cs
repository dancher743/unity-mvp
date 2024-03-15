using ExampleProject.Models;
using ExampleProject.Views;
using Mvp.Messaging;
using Mvp.Presenters;
using UnityEngine;

namespace ExampleProject.Presenters
{
    public class UIPresenter : Presenter<UIView, UIModel>, IMessageSubscriber
    {
        private readonly MessageDispatcher messageDispatcher;

        public UIPresenter(UIView view, UIModel model, MessageDispatcher messageDispatcher) : base(view, model)
        {
            this.messageDispatcher = messageDispatcher;
            messageDispatcher.Subscribe(this);
        }

        protected override void OnClear()
        {
            messageDispatcher.Unsubscribe(this);
        }

        void IMessageSubscriber.ReceiveMessage<TMessage>(TMessage message)
        {
            switch (message)
            {
                case CubeClickedMessage cubeClickedMessage:
                    Debug.Log(cubeClickedMessage.Text);
                    break;
            }
        }
    }
}
