using Prism.Navigation;

namespace TestPrismApp.ViewModels
{
	public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            this.NavigationService.NavigateAsync("/Login");
        }
    }
}
