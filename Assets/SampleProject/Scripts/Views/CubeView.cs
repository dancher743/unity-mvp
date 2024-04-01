using Mvp; 
using System;
using UnityEngine;

namespace SampleProject.Views
{
    public class CubeView : MonoView
    {
        public event Action Clicked;

        [SerializeField]
        private MeshRenderer meshRenderer;

        // Active View contains some view-related logic.
        /// If you want a Passive View just remove this property and make <<see cref="meshRenderer"/> as a public property.
        /// Now <<see cref="SampleProject.Presenters.CubePresenter"/> can change color of the view by itself.
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
