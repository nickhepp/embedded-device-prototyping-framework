using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.ManualTest.Business
{
    public class ViewConfigurationFactory
    {

        private List<ViewConfiguration> _viewConfigs = new List<ViewConfiguration>
        {
            new ConsoleViewConfiguration(),
            //new ConnectionsViewConfiguration()
        };

        public List<ViewConfiguration> GetViewConfigurations()
        {
            return _viewConfigs;
        }



    }
}
