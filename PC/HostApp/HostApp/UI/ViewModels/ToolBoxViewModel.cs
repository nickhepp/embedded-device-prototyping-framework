using HostApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ViewModels
{
    public class ToolBoxViewModel
    {

        private List<IToolWindowCohort> _cohorts;


        public ToolBoxViewModel(List<IToolWindowCohort> cohorts)
        {
            _cohorts = cohorts;
        }


    }
}
