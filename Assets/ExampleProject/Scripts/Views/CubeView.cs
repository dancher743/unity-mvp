using Mvp;
using System;
using UnityEngine;

namespace ExampleProject.Views
{
    public class CubeView : MonoBehaviour, IView
    {
        public event Action Clicked;

        private void OnMouseDown()
        {
            Clicked?.Invoke();
        }
    }
}
