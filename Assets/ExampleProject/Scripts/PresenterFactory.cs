using ExampleProject.Configs;
using ExampleProject.Views;
using Mvp;
using System;
using UnityEngine;

namespace ExampleProject
{
    public class PresenterFactory : IPresenterFactory
    {
        private const string PathToConfig = "Configs\\PresenterFactoryConfig";

        private readonly PresenterFactoryConfig config;
        private readonly Transform viewParent;

        public PresenterFactory(Transform viewParent)
        {
            this.config = Resources.Load<PresenterFactoryConfig>(PathToConfig);
            this.viewParent = viewParent;

            config.Cache();
        }

        public TPresenter Create<TPresenter, TView, TModel>(object data = default)
            where TPresenter : IPresenter
            where TView : IView
            where TModel : IModel
        {
            var viewPrefab = config.GetViewPrefab<TView>();

            if (viewPrefab is null)
            {
                return default;
            }

            var view = UnityEngine.Object.Instantiate(viewPrefab as MonoView, viewParent);
            var model = Activator.CreateInstance<TModel>();
            var args = data is not null ? new object[3] { view, model, data } : new object[2] { view, model };
            var presenter = Activator.CreateInstance(typeof(TPresenter), args);

            return (TPresenter)presenter;
        }
    }
}
