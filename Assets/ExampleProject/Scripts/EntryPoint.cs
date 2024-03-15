using ExampleProject.Models;
using ExampleProject.Presenters;
using ExampleProject.Views;
using Mvp;
using UnityEngine;

namespace ExampleProject
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField]
        private CubeView cubeView;

        [SerializeField]
        private UIView UIView;

        private CubePresenter cubePresenter;
        private UIPresenter UIPresenter;

        private readonly IPresenterFactory presenterFactory = new PresenterFactory();

        private void Start()
        {
            cubePresenter = presenterFactory.Create<CubePresenter>(cubeView, new CubeModel());
            UIPresenter = presenterFactory.Create<UIPresenter>(UIView, new UIModel());
        }

        private void OnDestroy()
        {
            cubePresenter.Clear();
            UIPresenter.Clear();
        }
    }
}
