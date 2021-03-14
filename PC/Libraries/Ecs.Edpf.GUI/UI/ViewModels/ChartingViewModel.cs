using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class ChartingViewModel : BaseDeviceViewModel, IChartingViewModel
    {

        public ChartingViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
        }


        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        protected override void OnDeviceChanged(IDevice device)
        {

        }
    }
}
