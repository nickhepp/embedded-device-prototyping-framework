using HostApp.UI.ViewModels;
using System.Windows.Forms;


using WeifenLuo;


namespace HostApp.UI.Views
{
    public partial class ParentMainView : UserControl, IMainView
    {

        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;


        private IParentMainViewModel _parentMainViewModel;

        public ParentMainView()
        {
            InitializeComponent();

            _dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.Controls.Add(_dockPanel);
            _dockPanel.Dock = DockStyle.Fill;

        }

        public void SetMainViewModel(IMainViewModel mainViewModel)
        {
            _parentMainViewModel = (IParentMainViewModel)mainViewModel;

            



        }






    }
}
