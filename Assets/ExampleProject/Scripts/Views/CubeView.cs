using Mvp.Views;
using System;

namespace ExampleProject.Views
{
    public class CubeView : MonoView
    {
        public event Action Clicked;

        private void OnMouseDown()
        {
            Clicked?.Invoke();
        }
    }
}
