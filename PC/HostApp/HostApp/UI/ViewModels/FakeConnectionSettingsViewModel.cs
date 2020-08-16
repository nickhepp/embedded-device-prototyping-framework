using Ecs.Edpf.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ChildUI.ViewModels
{
    public class FakeConnectionSettingsViewModel : DeviceConnectionSettingsViewModel
    {

        #region "IO"

        public const string IOCategory = "IO";

        private string _writeBuffer;
        [Category(IOCategory)]
        public string WriteBuffer
        {
            get
            {
                return _writeBuffer;
            }
            set
            {
                _writeBuffer = value;
                RaiseNotifyPropertyChanged();
            }
        }


        private string _readBuffer;
        [Category(IOCategory)]
        public string ReadBuffer
        {
            get
            {
                return _readBuffer;
            }
            set
            {
                _readBuffer = value;
                RaiseNotifyPropertyChanged();
            }
        }

        #endregion


        #region "Action"



        #endregion




    }
}
