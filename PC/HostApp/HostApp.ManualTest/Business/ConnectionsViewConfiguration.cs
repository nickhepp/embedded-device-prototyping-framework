//using Ecs.Edpf.GUI.UI.ViewModels;
//using Ecs.Edpf.GUI.UI.ViewModels.Connections;
//using Ecs.Edpf.GUI.UI.Views;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace HostApp.ManualTest.Business
//{
//    public class ConnectionsViewConfiguration : ViewConfiguration
//    {
//        public override string ViewName => "Connections";

//        ConnectionsView _connView;
//        ConnectionViewModelFactoryViewModel _vwMdl;

//        public ConnectionsViewConfiguration()
//        {
//            _connView = new ConnectionsView();
//            _vwMdl = new ConnectionViewModelFactoryViewModel();
//        }


//        public override Control GetControl()
//        {
            
//            return _connView;
//        }

//        public override IViewModel GetViewModel()
//        {
//            return _vwMdl;
//        }

//    }
//}
