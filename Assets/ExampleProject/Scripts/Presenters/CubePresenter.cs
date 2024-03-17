using ExampleProject.Models;
using ExampleProject.Views;
using Mvp.Messaging;
using UnityEngine;
using Mvp.Presenters;
using ExampleProject.Messaging;

namespace ExampleProject.Presenters
{
    public class CubePresenter : Presenter<CubeView, CubeModel>
    {
        private MessageDispatcher messageDispatcher;

        public CubePresenter(CubeView view, CubeModel model, MessageDispatcher messageDispatcher) : base(view, model)
        {
            this.messageDispatcher = messageDispatcher;
        }

        protected override void OnClear()
        {
            messageDispatcher = null;
        }

        protected override void OnAddEventHandlers()
        {
            view.Clicked += OnViewClicked;
            model.ColorChanged += OnModelColorChanged;
        }

        protected override void OnRemoveEventHandlers()
        {
            view.Clicked -= OnViewClicked;
            model.ColorChanged -= OnModelColorChanged;
        }

        private void OnViewClicked()
        {
            model.ChangeColorRandomly();
        }

        private void OnModelColorChanged(Color color)
        {
            view.Color = color;
            messageDispatcher.SendMessageTo<UIPresenter, CubeColorMessage>(new CubeColorMessage(color));
        }
    }
}
