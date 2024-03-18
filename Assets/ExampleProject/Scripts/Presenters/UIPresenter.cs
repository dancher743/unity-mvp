using ExampleProject.Messaging;
using ExampleProject.Models;
using ExampleProject.Views;
using Mvp.Messaging;
using Mvp.Presenters;

namespace ExampleProject.Presenters
{
    public class UIPresenter : Presenter<UIView, UIModel>, IMessageSubscriber
    {
        private MessageDispatcher messageDispatcher;

        public UIPresenter(UIView view, UIModel model, MessageDispatcher messageDispatcher) : base(view, model)
        {
            this.messageDispatcher = messageDispatcher;
            messageDispatcher.Subscribe(this);
        }

        protected override void OnClean()
        {
            messageDispatcher.Unsubscribe(this);
            messageDispatcher = null;
        }

        protected override void OnAddEventHandlers()
        {
            model.ColorTextChanged += OnModelColorTextChanged;
        }

        protected override void OnRemoveEventHandlers()
        {
            model.ColorTextChanged -= OnModelColorTextChanged;
        }

        void IMessageSubscriber.ReceiveMessage<TMessage>(TMessage message)
        {
            switch (message)
            {
                case CubeColorMessage cubeColorMessage:
                    model.ColorText = cubeColorMessage.Color.ToString();
                    break;
            }
        }

        private void OnModelColorTextChanged(string color)
        {
            view.ColorText = color;
        }
    }
}
