namespace Mvp
{
    public interface IPresenterFactory
    {
        public TPresenter Create<TPresenter>(params object[] data) where TPresenter : IPresenter;
    }
}
