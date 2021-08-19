using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public class ChartingViewSettingsViewModel : IChartingViewSettingsViewModel
    {

        private const string ChartsCategoryName = "Charts";



        [DisplayName(ChartsCategoryName)]
        public List<ChartSettingsViewModel> Charts { get; set; } = new List<ChartSettingsViewModel>();


        public ChartingViewSettingsViewModel()
        {
        }


        //protected override void OnDeviceStateChanged()
        //{
        //    if (DeviceState == DeviceState.OpenedDevice)
        //    {
        //        if (Device != null)
        //        {
        //            Device.DeviceInputBuffer.ListChanged += DeviceInputBufferListChanged;
        //        }

        //    }
  
        //}

        //private void DeviceInputBufferListChanged(object sender, ListChangedEventArgs e)
        //{
        //    if (e.ListChangedType == ListChangedType.ItemAdded)
        //    {
        //        string lineToInspect = Device.DeviceInputBuffer[e.NewIndex];
        //    }
        //}





    }
}
