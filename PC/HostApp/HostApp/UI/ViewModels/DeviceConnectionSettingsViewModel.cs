using Ecs.Edpf.Devices;
using HostApp.ComponentModel;
using HostApp.UI.ViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Schema;

namespace HostApp.UI.ChildUI.ViewModels
{

    /// <summary>
    /// This is a settings object that can be plugged into a propertygrid.
    /// </summary>
    public abstract class DeviceConnectionSettingsViewModel : BaseViewModel, IDeviceConnectionSettingsViewModel
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





        
    }
}
