using SampleProject.Models;
using SampleProject.Presenters;
using SampleProject.Views;
using Mvp.Instantiating;
using Mvp.Messaging;
using UnityEngine;

namespace SampleProject
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
        private readonly MessageDispatcher messageDispatcher = new();

        private void Start()
        {
            cubePresenter = presenterFactory.Create<CubePresenter>(cubeView, new CubeModel(), messageDispatcher);
            UIPresenter = presenterFactory.Create<UIPresenter>(UIView, new UIModel(), messageDispatcher);
        }

        private void OnDestroy()
        {
            cubePresenter.Clean();
            UIPresenter.Clean();
        }
    }
}
