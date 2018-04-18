using Prism.Navigation;
using TestPrismApp.Services;

namespace TestPrismApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public string HardwareId
        {
            get => this._hardwareId;
            set => this.SetProperty(ref this._hardwareId, value);
        }

        public string DeviceName
        {
            get => this._deviceName;
            set => this.SetProperty(ref this._deviceName, value);
        }

        public string OsType
        {
            get => this._osType;
            set => this.SetProperty(ref this._osType, value);
        }

        public string OsVersion
        {
            get => this._osVersion;
            set => this.SetProperty(ref this._osVersion, value);
        }

        public string AppVersion
        {
            get => this._appVersion;
            set => this.SetProperty(ref this._appVersion, value);
        }

        private string _appVersion;
        private string _osVersion;
        private string _osType;
        private string _deviceName;
        private string _hardwareId;


        private IHardwareService HardwareService { get; }

        public DashboardViewModel(INavigationService navigationService, IHardwareService hardwareService) :
            base(navigationService)
        {
            this.Title = "Dashboard";
            this.HardwareService = hardwareService;

            this.HardwareId = this.HardwareService.HardwareId;
            this.DeviceName = this.HardwareService.DeviceName;
            this.OsType = this.HardwareService.OsType;
            this.OsVersion = this.HardwareService.OsVersion;
            this.AppVersion = this.HardwareService.AppVersion;
        }
    }
}