using Mvp;
using UnityEngine;
using UnityEngine.UI;

namespace ExampleProject.Views
{
    public class UIView : MonoView
    {
        [SerializeField]
        private Text colorText;

        public string ColorText
        {
            set
            {
                colorText.text = value;
            }
        }
    }
}
