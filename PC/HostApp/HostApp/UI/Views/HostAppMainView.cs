using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.Views;
using HostApp.UI.ViewModels;
using System.Windows.Forms;


using WeifenLuo;


namespace HostApp.UI.Views
{
    public partial class HostAppMainView : UserControl, IMainView
    {

        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;


        private IHostAppMainViewModel _hostAppMainViewModel;

        public HostAppMainView()
        {
            InitializeComponent();

            _dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.Controls.Add(_dockPanel);
            _dockPanel.Dock = DockStyle.Fill;

        }

        public void SetMainViewModel(IMainViewModel mainViewModel)
        {
            _hostAppMainViewModel = (IHostAppMainViewModel)mainViewModel;
        }

        private void _exitTsm_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
