using Mvp.Views;
using UnityEngine;
using UnityEngine.UI;

namespace SampleProject.Views
{
    public class UIView : MonoView
    {
        [SerializeField]
        private Text colorText;

        public string ColorText
        {
            set => colorText.text = value;
        }
    }
}
