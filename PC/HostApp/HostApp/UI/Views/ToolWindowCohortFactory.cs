using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Views
{
    public class ToolWindowCohortFactory
    {

        public List<IToolWindowCohort> GetToolWindowCohorts()
        {
            List<IToolWindowCohort> cohorts = new List<IToolWindowCohort>
            {
                new ConsoleToolWindowCohort(),
                new DeviceCommandsToolWindowCohort(),
                new ConnectionsToolWindowCohort()
            };
            return cohorts;


        }


    }
}
