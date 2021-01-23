using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecs.Edpf.GUI.UI.ViewModels.Connections;
using Ecs.Edpf.GUI.UI.ViewModels;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class ConnectionsView : UserControl, IChildView
    {

        private IConnectionViewModelFactoryViewModel _connectionFactoryViewModel;
        public IChildViewModel ViewModel
        {
            get
            {
                return _connectionFactoryViewModel;

            }
            set
            {
                _connectionFactoryViewModel = value as IConnectionViewModelFactoryViewModel;
                this._connectionsTbctrl.TabPages.Clear();

                if (_connectionFactoryViewModel != null)
                {
                    foreach (IConnectionViewModel connVwMdl in _connectionFactoryViewModel.ConnectionViewModels)
                    {
                        ConnectionView connectionView = new ConnectionView();
                        connectionView.ViewModel = connVwMdl;
                        TabPage tabPage = new TabPage(connVwMdl.Name);
                        tabPage.Controls.Add(connectionView);
                        connectionView.Dock = DockStyle.Fill;
                        _connectionsTbctrl.TabPages.Add(tabPage);
                    }
                }
            }
        }

        public ConnectionsView()
        {
            InitializeComponent();

            this._connectionsTbctrl.TabPages.Clear();

        }
    }
}
