namespace Mvp
{
    public interface IPresenterFactory
    {
        public TPresenter Create<TPresenter, TView, TModel>(object data = null)
            where TPresenter : IPresenter
            where TView : IView
            where TModel : IModel;
    }
}
