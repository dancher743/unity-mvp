using ExampleProject.Models;
using ExampleProject.Views;
using Mvp.Messaging;
using Mvp.Presenters;

namespace ExampleProject.Presenters
{
    public class UIPresenter : Presenter<UIView, UIModel>, IMessageSubscriber
    {
        public UIPresenter(UIView view, UIModel model) : base(view, model)
        {
            MessageDispatcher.Subscribe(this);
        }

        protected override void OnClear()
        {
            MessageDispatcher.Unsubscribe(this);
        }

        void IMessageSubscriber.ReceiveMessage<TMessage>(TMessage message)
        {
            switch (message)
            {
                case CubeClickedMessage cubeClickedMessage:
                    view.ColorText = cubeClickedMessage.Text;
                    break;
            }
        }
    }
}
