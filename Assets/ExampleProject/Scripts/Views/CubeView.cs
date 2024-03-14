using Mvp;
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
