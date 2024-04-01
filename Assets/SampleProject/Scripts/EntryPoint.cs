using SampleProject.Models;
using SampleProject.Presenters;
using SampleProject.Views;
using Mvp.PresenterFactory;
using Mvp.Messaging;
using UnityEngine;

namespace SampleProject
{
    /// <summary>
    /// <see cref="EntryPoint"/> class is like Composition Root where modules are composed together.
    /// </summary>
    public class EntryPoint : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField]
        private CubeView cubeView;

        [SerializeField]
        private UIView uiView;

        private CubePresenter cubePresenter;
        private UIPresenter uiPresenter;

        private readonly IPresenterFactory presenterFactory = new PresenterFactory();
        private readonly MessageDispatcher messageDispatcher = new();

        private void Start()
        {
            cubePresenter = presenterFactory.Create<CubePresenter>(cubeView, new CubeModel(), messageDispatcher);
            uiPresenter = presenterFactory.Create<UIPresenter>(uiView, new UIModel(), messageDispatcher);
        }

        private void OnDestroy()
        {
            cubePresenter.Clear();
            uiPresenter.Clear();
        }
    }
}
