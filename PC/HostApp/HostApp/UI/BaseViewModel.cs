using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HostApp.Business;
using HostApp.ComponentModel;

namespace HostApp.UI
{
    public class BaseViewModel : IViewModel, ICustomTypeDescriptor
    {

        private IDevice _device;

        private Dictionary<string, Func<bool>> _propertyVisibilityHandlers = new Dictionary<string, Func<bool>>();

        [Browsable(false)]
        public List<ConsoleTokenHighlight> ConsoleTokenHighlights { get; set; } = new List<ConsoleTokenHighlight>();


        protected const string NoErrors = "";
        private string _errorMessages = NoErrors;
        [Browsable(false)]
        public string ErrorMessages {
            get
            {
                return _errorMessages;
            }
            set
            {
                _errorMessages = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private bool _openButtonEnabled = true;
        [Browsable(false)]
        public bool OpenButtonEnabled
        {
            get 
            {
                return _openButtonEnabled;
            }
            private set
            {
                _openButtonEnabled = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private bool _closeButtonEnabled = false;
        [Browsable(false)]
        public bool CloseButtonEnabled
        {
            get 
            {
                return _closeButtonEnabled;
            }
            private set
            {
                _closeButtonEnabled = value;
                RaiseNotifyPropertyChanged();
            }
        }

        public virtual List<string> GetCommandNames()
        {
            return new List<string>();
        }

        private ICommand _openCommand;
        [Browsable(false)]
        public System.Windows.Input.ICommand OpenCommand
        {
            get { return _openCommand; }
            private set
            {
                _openCommand = value;
            }
        }

        private ICommand _closeCommand;
        [Browsable(false)]
        public System.Windows.Input.ICommand CloseCommand
        {
            get { return _closeCommand; }
            private set
            {
                _closeCommand = value;
            }
        }

        [Browsable(false)]
        public BindingList<string> DeviceOutputBuffer => _device.DeviceOutputBuffer;


        protected BaseViewModel()
        {

            _device = DeviceFactory.GetDevice();
            _device.PropertyChanged += DevicePropertyChanged;
            OpenCommand = new RelayCommand(param => this.OpenButtonEnabled, OpenCommandHandler);
            CloseCommand = new RelayCommand(param => this.CloseButtonEnabled, CloseCommandHandler);

            this.ConsoleTokenHighlights.Add(new ConsoleTokenHighlight
            {
                BackgroundColor = Color.Red,
                ForegroundColor = Color.White,
                Token = BaseKernelDevice.DeviceOutputBufferErrorPrefix
            });

        }

        private void DevicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDevice.IsOpen))
            {
                OpenButtonEnabled = !_device.IsOpen;
                CloseButtonEnabled = _device.IsOpen;
            }
        }

        private void OpenCommandHandler(object obj)
        {
            _device.Open();
        }

        private void CloseCommandHandler(object obj)
        {
            _device.Close();
        }

        protected IDevice GetDevice()
        {
            return _device;
        }


        protected void RaiseNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        public void WriteTextToDevice(string cmdText)
        {
            _device.Write(cmdText);

        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;



        #region ICustomTypeDescriptor

        protected void RegisterPropertyVisibilityHandlers(IEnumerable<string> propertyNames, Func<bool> visibilityHandler)
        {
            foreach (string propertyName in propertyNames)
            {
                RegisterPropertyVisibilityHandler(propertyName, visibilityHandler);
            }
        }

        protected void RegisterPropertyVisibilityHandler(string propertyName, Func<bool> visibilityHandler)
        {
            _propertyVisibilityHandlers[propertyName] = visibilityHandler;
        }


        // ICustomTypeDescriptor implementation
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pdColl = TypeDescriptor.GetProperties(this, true);
            List<PropertyDescriptor> pdDescs = new List<PropertyDescriptor>();
            for (int idx = 0; idx < pdColl.Count; idx++)
            {
                Func<bool> propVisibilityHandler;
                _propertyVisibilityHandlers.TryGetValue(pdColl[idx].Name, out propVisibilityHandler);
                if (propVisibilityHandler == null || propVisibilityHandler.Invoke())
                {
                    pdDescs.Add(pdColl[idx]);
                }
            }

            pdColl = new PropertyDescriptorCollection(pdDescs.ToArray());

            return pdColl;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            //return TypeDescriptor.GetProperties(this, attributes, true);
            return GetProperties();
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion

    }
}
