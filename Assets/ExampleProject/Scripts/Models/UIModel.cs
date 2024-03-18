using Mvp.Models;
using System;

namespace ExampleProject.Models
{
    public class UIModel : IModel
    {
        public event Action<string> ColorTextChanged;

        private string color;

        // You can replace this property with a reactive property.
        public string ColorText
        {
            set
            {
                color = value;
                ColorTextChanged?.Invoke(color);
            }
        }
    }
}