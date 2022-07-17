using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.ComponentModel;
using Ecs.Edpf.GUI.Settings;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Schema;

namespace Ecs.Edpf.GUI.UI.ViewModels
{

    /// <summary>
    /// This is a settings object that can be plugged into a propertygrid.
    /// </summary>
    public abstract class DeviceConnectionSettingsViewModel : BaseViewModel, IDeviceConnectionSettingsViewModel, ISettingsResource
    {

        private const string ClosedConnection = "Closed";
        private const string OpenConnection = "Open";

        private string _connection = ClosedConnection;
        [Category("Status")]
        public string Connection
        {
            get
            {
                return _connection;
            }
            private set
            {
                _connection = value;
                RaiseNotifyPropertyChanged();
            }
        }

        private bool _isOpen;
        [Browsable(false)]
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                RaiseNotifyPropertyChanged();
                Connection = _isOpen ? OpenConnection : ClosedConnection;
            }
        }

        protected abstract string GetResourceName();

        [Browsable(false)]
        public string ResourceName => GetResourceName();



        protected abstract Dictionary<string, string> InternalGetSettings();
        public Dictionary<string, string> GetSettings()
        {
            return InternalGetSettings();
        }

        protected abstract void InternalApplySettings(Dictionary<string, string> settings);
        public void ApplySettings(Dictionary<string, string> settings)
        {
            InternalApplySettings(settings);
        }

        protected abstract void InternalApplyDefaultSettings();
        public void ApplyDefaultSettings()
        {
            InternalApplyDefaultSettings();
        }

    }
}
