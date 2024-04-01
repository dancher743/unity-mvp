using Mvp.Models;
using System;
using UnityEngine;

namespace SampleProject.Models
{
    public class CubeModel : IModel
    {
        public event Action<Color> ColorChanged;

        private Color color;

        // You can replace this property with a reactive property.
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                ColorChanged?.Invoke(color);
            }
        }

        public void ChangeColorRandomly()
        {
            Color = UnityEngine.Random.ColorHSV();
        }
    }
}
