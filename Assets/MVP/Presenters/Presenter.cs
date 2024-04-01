using Mvp.Clearing;
using Mvp.Models;
using Mvp.Views;

namespace Mvp.Presenters
{
    public class Presenter<TView, TModel> : IPresenter, IClearable
        where TView : IView
        where TModel : IModel
    {
        protected TView view;
        protected TModel model;

        public Presenter(TView view, TModel model)
        {
            this.view = view;
            this.model = model;
            OnAddEventHandlers();
        }

        public void Clear()
        {
            OnRemoveEventHandlers();
            OnClear();
        }

        protected virtual void OnAddEventHandlers()
        {
        }

        protected virtual void OnRemoveEventHandlers()
        {
        }

        protected virtual void OnClear()
        {
        }
    }
}
