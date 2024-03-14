namespace Mvp
{
    public class Presenter<TView, TModel> : IPresenter
        where TView : IView
        where TModel : IModel
    {
        protected TView view;
        protected TModel model;

        public Presenter()
        {
        }

        public Presenter(TView view, TModel model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
