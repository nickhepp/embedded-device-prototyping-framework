using Ecs.Edpf.Devices.Devices;
using HostApp.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Views
{
    public class ToolWindowCohortFactory
    {

        private IDeviceProviderRegistry _deviceProviderRegistry;

        public ToolWindowCohortFactory(IDeviceProviderRegistry deviceProviderRegistry)
        {
            _deviceProviderRegistry = deviceProviderRegistry;
        }


        public List<IToolWindowCohort> GetToolWindowCohorts()
        {
            List<IToolWindowCohort> cohorts = new List<IToolWindowCohort>
            {
                new ConsoleToolWindowCohort(),
                new DeviceCommandsToolWindowCohort(),
                new ConnectionsToolWindowCohort()
            };

            foreach (IToolWindowCohort cohort in cohorts)
            {
                if (cohort.ViewModel is IDeviceProviderListener deviceProviderListener)
                {
                    _deviceProviderRegistry.RegisterDeviceProviderListener(deviceProviderListener);
                }

                if (cohort.ViewModel is IGlobalDeviceProvider globalDeviceProvider)
                {
                    _deviceProviderRegistry.RegisterGlobalDeviceProvider(globalDeviceProvider);
                }

            }


            return cohorts;


        }


    }
}
