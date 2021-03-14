using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class DeviceTextMacroView : UserControl
    {

        public IDeviceTextMacroViewModel DeviceTextMacroViewModel { get; set; }

        public DeviceTextMacroView()
        {
            InitializeComponent();
        }

        private void _oneShotBtn_Click(object sender, EventArgs e)
        {

        }

        private void _loopBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
