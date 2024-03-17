using Mvp.Views;
using System;
using UnityEngine;

namespace ExampleProject.Views
{
    public class CubeView : MonoView
    {
        public event Action Clicked;

        [SerializeField]
        private MeshRenderer meshRenderer;

        public Color Color
        {
            set => meshRenderer.material.color = value;
        }

        private void OnMouseDown()
        {
            Clicked?.Invoke();
        }
    }
}
