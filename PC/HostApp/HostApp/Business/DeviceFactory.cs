using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Business
{
    public static class DeviceFactory
    {

        private static IDevice _device = null;

        public static IDevice GetDevice()
        {
            return GetDevice(AppInfo.DeviceTypeName);
        }

        private static IDevice GetDevice(string deviceTypeName)
        {
            if (_device == null)
            {
                Type type = Type.GetType(deviceTypeName);
                if (type == null)
                {
                    throw new Exception(string.Format("Could not create device '{0}'.", deviceTypeName));
                }

                IDevice device = (IDevice)Activator.CreateInstance(type);
                _device = device;
            }

            return _device;
        }

    }
}
