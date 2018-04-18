
using System;
using Foundation;
using TestPrismApp.Services;
using UIKit;

namespace TestPrismApp.iOS.Services
{
    public class HardwareService : IHardwareService
    {
        public string HardwareId
        {
            get
            {
                var id = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
                return string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            }
        }

        public string DeviceName => UIDevice.CurrentDevice.Name;
        public string OsType => "Apple";
        public string OsVersion => UIDevice.CurrentDevice.SystemVersion;

        public string AppVersion => NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleShortVersionString")].ToString();
    }
}