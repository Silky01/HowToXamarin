using Prism;
using Prism.Ioc;
using TestPrismApp.ViewModels;
using TestPrismApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using TestPrismApp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestPrismApp
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            this.InitializeComponent();
            await this.NavigationService.NavigateAsync("/Login");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Nav");
            containerRegistry.RegisterForNavigation<LoginPage>("Login");
            containerRegistry.RegisterForNavigation<Dashboard>("Dashboard");

            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}
