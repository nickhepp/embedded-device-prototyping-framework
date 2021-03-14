using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class ConsoleViewModel : BaseDeviceViewModel, IConsoleViewModel
    {

        private IDevice _currentDevice = null;

        private const int DefaultMaxPreviousCommandCount = 20;
        private int _maxPreviousCommandCount = DefaultMaxPreviousCommandCount;
        public int MaxPreviousCommandCount 
        { 
            get => _maxPreviousCommandCount;
        }

        private int _previousCommandCount;
        public int PreviousCommandCount { 
            get => _previousCommandCount;
        }

        private string _selectedPreviousCommand;
        public string SelectedPreviousCommand
        {
            get
            {
                return _selectedPreviousCommand;
            }
            private set
            {
                _selectedPreviousCommand = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private void SetPreviousCommandCounts()
        {
            _maxPreviousCommandCount = System.Math.Max(DefaultMaxPreviousCommandCount, _currentDevice.DeviceInputBuffer.Count);
            _previousCommandCount = _currentDevice.DeviceInputBuffer.Count;
            RaiseNotifyPropertyChanged(nameof(MaxPreviousCommandCount));
            RaiseNotifyPropertyChanged(nameof(PreviousCommandCount));
            RaiseNotifyPropertyChanged(nameof(SelectedPreviousCommand));
        }
        public List<ConsoleTokenHighlight> ConsoleTokenHighlights { get; set; } = new List<ConsoleTokenHighlight>
        {
            new ConsoleTokenHighlight
            {
                BackgroundColor = Color.Red,
                ForegroundColor = Color.Black,
                Token = "ERR"
            },
            new ConsoleTokenHighlight
            {
                BackgroundColor = Color.Yellow,
                ForegroundColor = Color.Black,
                Token = "WARN"
            },
            new ConsoleTokenHighlight
            {
                BackgroundColor = Color.Green,
                ForegroundColor = Color.Black,
                Token = "PASS"
            }
        };


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

        public ConsoleViewModel(IDeviceStateMachine deviceStateMachine) : base(deviceStateMachine)
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
            if (_currentDevice != null)
            {
                _currentDevice.DeviceInputBuffer.ListChanged -= DeviceInputBufferListChanged;
            }
            _currentDevice = device;
            _currentDevice.DeviceInputBuffer.ListChanged += DeviceInputBufferListChanged;
            SetInputTextEnabled();
        }

        private void DeviceInputBufferListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                ClearPreviousCommandSettings();
                SetPreviousCommandCounts();
            }
        }

        private void ClearPreviousCommandSettings()
        {
            SelectedPreviousCommand = null;
            SelectedPreviousCommandIndex = null;
            _currentText = null;
        }

        public void WriteTextToDevice(string cmdText)
        {
            Device.Write(cmdText);
        }

        private string _currentText = null;

        private int? _selectedPreviousCommandIndex = null;
        public int? SelectedPreviousCommandIndex
        {
            get => _selectedPreviousCommandIndex;
            private set
            {
                _selectedPreviousCommandIndex = value;
                RaiseNotifyPropertyChanged();
            }
        }


        public void SelectUpPreviousCommand(string currentText)
        {
            // only want to grab the first
            if (_currentText == null)
            {
                _currentText = currentText;
            }

            if (!SelectedPreviousCommandIndex.HasValue && _currentDevice.DeviceInputBuffer.Count > 0)
            {
                SelectedPreviousCommandIndex = _currentDevice.DeviceInputBuffer.Count - 1;
                SelectedPreviousCommand = _currentDevice.DeviceInputBuffer[SelectedPreviousCommandIndex.Value];
            }
            else if (!SelectedPreviousCommandIndex.HasValue && _currentDevice.DeviceInputBuffer.Count == 0)
            {
                // nothing to do here
            }
            else if (SelectedPreviousCommandIndex.HasValue && SelectedPreviousCommandIndex.Value > 0)
            {
                SelectedPreviousCommandIndex--;
                SelectedPreviousCommand = _currentDevice.DeviceInputBuffer[SelectedPreviousCommandIndex.Value];

            }
            else if (SelectedPreviousCommandIndex.HasValue && SelectedPreviousCommandIndex.Value == 0)
            {
                // nothing to do here
            }
        }

        public void SelectDownPreviousCommand()
        {
            if (SelectedPreviousCommandIndex.HasValue && SelectedPreviousCommandIndex.Value < _currentDevice.DeviceInputBuffer.Count - 1)
            {
                SelectedPreviousCommandIndex++;
                SelectedPreviousCommand = _currentDevice.DeviceInputBuffer[SelectedPreviousCommandIndex.Value];
            }
            else if (SelectedPreviousCommandIndex.HasValue && SelectedPreviousCommandIndex.Value == _currentDevice.DeviceInputBuffer.Count - 1)
            {
                SelectedPreviousCommandIndex = null;
                SelectedPreviousCommand = _currentText;
                _currentText = null;
            }
        }
    }
}
