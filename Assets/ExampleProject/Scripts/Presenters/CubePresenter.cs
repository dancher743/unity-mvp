using ExampleProject.Models;
using ExampleProject.Views;
using Mvp;
using System;
using UnityEngine;

namespace ExampleProject.Presenters
{
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
        }
    }
}
