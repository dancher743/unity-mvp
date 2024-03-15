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
        public CubePresenter(CubeView view, CubeModel model) : base(view, model)
        {
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
            MessageDispatcher.SendMessageTo<UIPresenter, CubeClickedMessage>(new CubeClickedMessage("123"));
            //MessageDispatcher.SendMessageToAll(new CubeClickedMessage("123"));
        }
    }
}
