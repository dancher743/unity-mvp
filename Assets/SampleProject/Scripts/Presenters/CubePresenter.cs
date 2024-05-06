using SampleProject.Models;
using SampleProject.Views;
using Mvp.Messaging;
using UnityEngine;
using SampleProject.Messages;
using Mvp;

namespace SampleProject.Presenters
{
    public class CubePresenter : Presenter<CubeView, CubeModel>
    {
        private IMessageDispatcher messageDispatcher;

        public CubePresenter(CubeView view, CubeModel model, IMessageDispatcher messageDispatcher) : base(view, model)
        {
            this.messageDispatcher = messageDispatcher;
            model.Color = Color.white;
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
            messageDispatcher.DispatchMessageTo<UIPresenter, CubeColorMessage>(new CubeColorMessage { Color = color });
        }
    }
}
