using Ecs.Edpf.Devices.Devices;
using HostApp.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Views
{
    public class ToolWindowCohortFactory : IToolWindowCohortFactory
    {

        private IDeviceProviderRegistry _deviceProviderRegistry;

        private List<IToolWindowCohort> _cohorts;

        public ToolWindowCohortFactory(IDeviceProviderRegistry deviceProviderRegistry)
        {
            _deviceProviderRegistry = deviceProviderRegistry;
        }


        public void Initialize()
        {
            _cohorts = new List<IToolWindowCohort> {
                    new ConsoleToolWindowCohort(),
                    new DeviceCommandsToolWindowCohort(),
                    new ConnectionsToolWindowCohort(),
                    new ChartingToolWindowCohort()
               };


            ToolBoxWindowCohort toolBoxWindowCohort = new ToolBoxWindowCohort(_cohorts);
            _cohorts.Add(toolBoxWindowCohort);



            foreach (IToolWindowCohort cohort in _cohorts)
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

     
        }


        public List<IToolWindowCohort> GetToolWindowCohorts()
        {
            return _cohorts;
        }

        public void ApplyDefaultLayout(DockPanel dockPanel)
        {
            List<ConsoleToolWindowCohort> consoleCohorts = _cohorts.Where(cohort => cohort.GetType() == typeof(ConsoleToolWindowCohort)).
                Select(cohort => cohort as ConsoleToolWindowCohort).ToList();

            List<ChartingToolWindowCohort> chartingCohorts = _cohorts.Where(cohort => cohort.GetType() == typeof(ChartingToolWindowCohort)).
                Select(cohort => cohort as ChartingToolWindowCohort).ToList();
            foreach (ChartingToolWindowCohort chartingCohort in chartingCohorts)
            {
                //chartingCohort.GetToolWindow().Show(prevConsoleCohort.GetToolWindow().Pane);
                chartingCohort.GetToolWindow().Show(dockPanel, DockState.Document);
            }

            // console windows start off as documents
            ConsoleToolWindowCohort prevConsoleCohort = null;
            foreach (ConsoleToolWindowCohort consoleCohort in consoleCohorts)
            {
                //if (prevConsoleCohort == null)
                //{
                    consoleCohort.GetToolWindow().Show(dockPanel, DockState.Document);
                //}
                //else
                //{
                //    consoleCohort.GetToolWindow().Show(prevConsoleCohort.GetToolWindow().Pane);
                //}
                prevConsoleCohort = consoleCohort;
            }



            // tool box is top right
            List<ToolBoxWindowCohort> toolBoxWindowCohorts = _cohorts.Where(cohort => cohort.GetType() == typeof(ToolBoxWindowCohort)).
                Select(cohort => cohort as ToolBoxWindowCohort).ToList();
            foreach (ToolBoxWindowCohort toolBoxWindowCohort in toolBoxWindowCohorts)
            {
                toolBoxWindowCohort.GetToolWindow().Show(dockPanel, DockState.DockRight);
            }

            // device commands are bottom right
            List<DeviceCommandsToolWindowCohort> deviceCommandsToolWindowCohorts = _cohorts.Where(cohort => cohort.GetType() == typeof(DeviceCommandsToolWindowCohort)).
                Select(cohort => cohort as DeviceCommandsToolWindowCohort).ToList();
            foreach (DeviceCommandsToolWindowCohort deviceCommandsToolWindowCohort in deviceCommandsToolWindowCohorts)
            {
                deviceCommandsToolWindowCohort.GetToolWindow().Show(toolBoxWindowCohorts.Last().GetToolWindow().Pane, DockAlignment.Bottom, 0.67);
            }

            // device connections are bottom right
            List<ConnectionsToolWindowCohort> connectionsToolWindowCohorts = _cohorts.Where(cohort => cohort.GetType() == typeof(ConnectionsToolWindowCohort)).
                Select(cohort => cohort as ConnectionsToolWindowCohort).ToList();
            foreach (ConnectionsToolWindowCohort connectionsToolWindowCohort in connectionsToolWindowCohorts)
            {
                connectionsToolWindowCohort.GetToolWindow().Show(deviceCommandsToolWindowCohorts.Last().GetToolWindow().Pane, DockAlignment.Bottom, 0.5);
            }



        }

    }
}
