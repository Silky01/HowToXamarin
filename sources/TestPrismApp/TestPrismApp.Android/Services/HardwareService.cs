using System;
using Android.OS;
using TestPrismApp.Services;

namespace TestPrismApp.Droid.Services
{
    public class HardwareService : IHardwareService
    {
        public string HardwareId
        {
            get
            {
                var id = Build.Serial;
                return string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            }
        }

        public string DeviceName => $"{Build.Manufacturer} - {Build.Model}";

        public string OsType => "Android";

        public string OsVersion => Build.VERSION.Release;

        public string AppVersion
        {
            get
            {
                var ctx = Android. App.Application.Context;
                var info = ctx.PackageManager.GetPackageInfo(ctx.PackageName, 0);

                return $"{info.VersionCode}";
            }
        }
    }
}