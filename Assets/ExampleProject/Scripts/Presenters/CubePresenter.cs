using ExampleProject.Models;
using ExampleProject.Views;
using Mvp.Messaging;
using UnityEngine;
using Mvp.Presenters;

namespace ExampleProject.Presenters
{
    public record CubeClickedMessage(string Text);

    public class CubePresenter : Presenter<CubeView, CubeModel>
    {
        private readonly MessageDispatcher messageDispatcher;

        public CubePresenter(CubeView view, CubeModel model, MessageDispatcher messageDispatcher) : base(view, model)
        {
            this.messageDispatcher = messageDispatcher;
        }

        protected override void OnAddEventHandlers()
        {
            view.Clicked += OnViewClicked;
        }

        protected override void OnRemoveEventHandlers()
        {
            view.Clicked -= OnViewClicked;
        }

        private void OnViewClicked()
        {
            Debug.Log("Clicked!");
            messageDispatcher.SendMessageTo<UIPresenter, CubeClickedMessage>(new CubeClickedMessage("123"));
        }
    }
}
