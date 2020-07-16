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
    public class ConsoleControlViewModel : BaseDeviceViewModel
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

        }



        protected override void InternalDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnDeviceChanged(IDevice device)
        {
            SetInputTextEnabled()
            throw new NotImplementedException();
        }
    }
}
