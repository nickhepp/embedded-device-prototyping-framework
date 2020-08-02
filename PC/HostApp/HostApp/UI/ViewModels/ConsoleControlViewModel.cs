using HostApp.Business;
using HostApp.UI.ChildUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ViewModels.Controls
{
    public class ConsoleControlViewModel : BaseDeviceViewModel, IConsoleControlViewModel
    {


        [Browsable(false)]
        public List<ConsoleTokenHighlight> ConsoleTokenHighlights { get; set; } = new List<ConsoleTokenHighlight>();


        private bool _inputTextEnabled = false;
        public bool InputTextEnabled
        {
            get
            {
                return _inputTextEnabled;
            }
            private set
            {
                _inputTextEnabled = value;
                RaiseNotifyPropertyChanged();
            }
        }






        public ConsoleControlViewModel()
        {
        }

        private void SetInputTextEnabled()
        {
            InputTextEnabled = Device.IsOpen;
        }



        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDevice.IsOpen))
            {
                SetInputTextEnabled();
            }
        }

        protected override void OnDeviceChanged(IDevice device)
        {
            SetInputTextEnabled();
        }

    }
}
