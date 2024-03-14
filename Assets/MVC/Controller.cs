namespace Mvc
{
    public class Controller<TView, TModel> : IController
        where TView : IView
        where TModel : IModel
    {
        protected TView view;
        protected TModel model;

        public Controller()
        {
        }

        public Controller(TView view, TModel model)
        {
            this.view = view;
            this.model = model;
        }
    }
}