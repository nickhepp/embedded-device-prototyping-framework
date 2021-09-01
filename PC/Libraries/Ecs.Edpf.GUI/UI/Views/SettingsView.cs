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
    public partial class SettingsView : Form
    {
        
        public object Settings { get; private set; }



        public SettingsView()
        {
            InitializeComponent();
        }

        public SettingsView(string title, ICloneable obj)
        {
            this.Text = title;
            Settings = obj.Clone();
            _settingsPpg.SelectedObject = Settings;
        }

    }
}
