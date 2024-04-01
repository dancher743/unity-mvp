using SampleProject.Models;
using SampleProject.Views;
using Mvp.Messaging;
using UnityEngine;
using Mvp.Presenters;
using SampleProject.Messaging;

namespace SampleProject.Presenters
{
    public class CubePresenter : Presenter<CubeView, CubeModel>
    {
        private MessageDispatcher messageDispatcher;

        public CubePresenter(CubeView view, CubeModel model, MessageDispatcher messageDispatcher) : base(view, model)
        {
            this.messageDispatcher = messageDispatcher;
            model.Color = Color.white;
        }

        protected override void OnClean()
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
            messageDispatcher.SendMessageTo<UIPresenter, CubeColorMessage>(new CubeColorMessage { Color = color });
        }
    }
}
