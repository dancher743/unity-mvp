using ExampleProject.Models;
using ExampleProject.Views;
using Mvp;

namespace ExampleProject.Presenters
{
    public class UIPresenter : Presenter<UIView, UIModel>
    {
        public UIPresenter(UIView view, UIModel model) : base(view, model)
        {
        }
    }
}
