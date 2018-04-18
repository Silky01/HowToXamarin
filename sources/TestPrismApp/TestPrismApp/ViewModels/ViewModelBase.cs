using Prism.Mvvm;
using Prism.Navigation;

namespace TestPrismApp.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; }

        private string _title;

        public string Title
        {
            get => this._title;
            set => this.SetProperty(ref this._title, value);
        }

        protected ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}