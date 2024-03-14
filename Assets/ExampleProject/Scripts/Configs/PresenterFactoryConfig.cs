using ExampleProject.Views;
using Mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExampleProject.Configs
{
    [CreateAssetMenu(menuName = "Configs/Presenter Factory Config", fileName = "PresenterFactoryConfig")]
    public class PresenterFactoryConfig : ScriptableObject
    {
        [SerializeField]
        private MonoView[] viewPrefabs;

        private Dictionary<Type, IView> viewPrefabsCached;

        public void Cache()
        {
            viewPrefabsCached = new Dictionary<Type, IView>(viewPrefabs.Length);
            
            foreach (var view in viewPrefabs)
            {
                viewPrefabsCached[view.GetType()] = view;
            }
        }

        public TView GetViewPrefab<TView>() where TView : IView
        {
            IView viewPrefab = null;

            if (viewPrefabsCached is not null)
            {
                viewPrefab = viewPrefabs.FirstOrDefault(viewPrefab => viewPrefab.GetType() == typeof(TView));
            }

            return (TView)viewPrefab;
        }
    }
}
