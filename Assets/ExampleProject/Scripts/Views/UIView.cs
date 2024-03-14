using Mvp;
using TMPro;
using UnityEngine;

namespace ExampleProject.Views
{
    public class UIView : MonoView
    {
        [SerializeField]
        private TextMeshProUGUI colorText;

        public string ColorText
        {
            set
            {
                colorText.text = value;
            }
        }
    }
}
