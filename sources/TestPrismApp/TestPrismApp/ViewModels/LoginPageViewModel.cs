using Prism.Commands;
using Prism.Navigation;
using TestPrismApp.Services;

namespace TestPrismApp.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
	    public string Username
	    {
	        get => this._username;
	        set => this.SetProperty(ref this._username, value);
	    }

	    public bool IsAuthenticating
	    {
	        get => this._isAuthenticating;
	        set => this.SetProperty(ref this._isAuthenticating, value);
	    }

	    public DelegateCommand LoginCommand { get; }

        private IAuthenticationService AuthenticationService { get; }
	    private string _username;
	    private bool _isAuthenticating;


	    public LoginPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        : base (navigationService)
        {
            this.AuthenticationService = authenticationService;
            this.LoginCommand = new DelegateCommand(async () =>
                                                    {
                                                        this.IsAuthenticating = true;
                                                        if (await this.AuthenticationService.LoginAsync(this.Username))
                                                            await this.NavigationService.NavigateAsync("Nav/Dashboard");
                                                        this.IsAuthenticating = false;
                                                    },
                                                    () => !this.IsAuthenticating).ObservesProperty(() => this.IsAuthenticating);
        }

	    public override void OnNavigatedTo(NavigationParameters parameters)
	    {
	        base.OnNavigatedTo(parameters);
	        if (this.AuthenticationService.IsAuthenticated)
	            this.NavigationService.NavigateAsync("Nav/Dashboard");
	    }
	}
}
