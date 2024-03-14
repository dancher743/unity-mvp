using ExampleProject.Models;
using ExampleProject.Presenters;
using ExampleProject.Views;
using UnityEngine;

namespace ExampleProject
{
    public class EntryPoint : MonoBehaviour
    {
        private CubePresenter cubePresenter;
        private PresenterFactory presenterFactory;

        [SerializeField] 
        private Transform viewParent;

        public void Awake()
        {
            presenterFactory = new PresenterFactory(viewParent);
        }

        public void Start()
        {
            cubePresenter = presenterFactory.Create<CubePresenter, CubeView, CubeModel>();
        }

        public void OnDestroy()
        {
            cubePresenter.Clear();
        }
    }
}