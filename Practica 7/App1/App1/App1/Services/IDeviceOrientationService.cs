using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace App1.Services
{
    public interface IDeviceOrientationService
    {
        DeviceOrientation GetOrientation();
    }
}
