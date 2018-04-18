using System;
using System.Collections.Generic;
using System.Text;

namespace TestPrismApp.Services
{
    public interface IHardwareService
    {
        string HardwareId { get; }
        string DeviceName { get; }
        string OsType { get; }
        string OsVersion { get; }
        string AppVersion { get; }
    }
}
