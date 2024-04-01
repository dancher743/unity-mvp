using SampleProject.Messaging;
using SampleProject.Models;
using SampleProject.Views;
using Mvp.Messaging;
using Mvp;

namespace SampleProject.Presenters
{
    public class UIPresenter : Presenter<UIView, UIModel>, IMessageSubscriber
    {
        private MessageDispatcher messageDispatcher;

        public UIPresenter(UIView view, UIModel model, MessageDispatcher messageDispatcher) : base(view, model)
        {
            this.messageDispatcher = messageDispatcher;
            messageDispatcher.Subscribe(this);
        }

        protected override void OnClear()
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
