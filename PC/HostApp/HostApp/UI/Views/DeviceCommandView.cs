using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HostApp.UI.ViewModels;

namespace HostApp.UI.Views
{
    public partial class DeviceCommandView : UserControl
    {
        private IDeviceCommandViewModel _deviceCommandViewModel;
        public IDeviceCommandViewModel DeviceCommandViewModel
        {
            get
            {
                return _deviceCommandViewModel;
            }
            set
            {
                _deviceCommandViewModel = value;
                _commandPpg.SelectedObject = value;
            }
        }

        public DeviceCommandView()
        {
            InitializeComponent();
        }
    }
}
