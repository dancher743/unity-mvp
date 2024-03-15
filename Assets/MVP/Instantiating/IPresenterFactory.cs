using Mvp.Presenters;

namespace Mvp.Instantiating
{
    public interface IPresenterFactory
    {
        public TPresenter Create<TPresenter>(params object[] data) where TPresenter : IPresenter;
    }
}
