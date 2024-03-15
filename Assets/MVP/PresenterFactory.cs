using System;
using System.Linq;
using UnityEngine;

namespace Mvp
{
    public class PresenterFactory : IPresenterFactory
    {
        public TPresenter Create<TPresenter>(params object[] data) where TPresenter : IPresenter
        {
            TPresenter presenter = default;

            var presenterType = typeof(TPresenter);
            var isConstructorExists = presenterType.GetConstructors().Any(ctr => ctr.GetParameters().Length == data.Length);

            if (isConstructorExists)
            {
                presenter = (TPresenter)Activator.CreateInstance(presenterType, data);
            }
            else
            {
                var presenterName = presenterType.Name;
                Debug.LogError($"Presenter Factory: Cannot create {presenterName}. Count of items in data doesn't match with counts of arguments of {presenterName}'s constructor.");
            }

            return presenter;
        }
    }
}
