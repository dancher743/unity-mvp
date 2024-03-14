using ExampleProject.Models;
using ExampleProject.Presenters;
using ExampleProject.Views;
using Mvp;
using UnityEngine;

namespace ExampleProject
{
    public class Application : MonoBehaviour
    {
        [SerializeField]
        private CubeView cubeView;

        private CubePresenter cubePresenter;

        public void Start()
        {
            cubePresenter = new CubePresenter(cubeView, new CubeModel());
        }

        public void OnDestroy()
        {
            cubePresenter.Clear();
        }
    }
}