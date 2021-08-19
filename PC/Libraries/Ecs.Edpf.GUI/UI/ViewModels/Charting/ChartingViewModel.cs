using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public class ChartingViewModel : BaseDeviceViewModel, IChartingViewModel
    {

        public IChartingViewSettingsViewModel SettingsViewModel { get; set; } = new ChartingViewSettingsViewModel();

        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Charting";


        private bool _showSettings = true;
        public bool ShowSettings 
        { 
            get
            {
                return _showSettings;
            }
            set
            {
                _showSettings = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public ChartingViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
        {
        }


    }
}
