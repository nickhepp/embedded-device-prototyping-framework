using HostApp.ManualTest.Business;
using HostApp.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.ManualTest.UI.ViewModels
{
    public class MainTestViewModel
    {

        public ViewConfigurationFactory ViewConfigurationFactory { get; } = new ViewConfigurationFactory();


        public IConnectionViewModel ConnectionViewModel { get; set; }


        public MainTestViewModel()
        {

        }



    }
}
