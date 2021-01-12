using Ecs.Edpf.Devices;
using System.Collections.Generic;
using System.ComponentModel;


namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class ConsoleControlViewModel : BaseDeviceViewModel, IConsoleControlViewModel
    {

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

        private string _errorMessages;
        public string ErrorMessages
        {
            get
            {
                return _errorMessages;
            }
            set
            {
                _errorMessages = value;
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

        public void WriteTextToDevice(string cmdText)
        {
            Device.Write(cmdText);
        }



    }
}
