using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.ChildUI
{
    public class DeviceConnectionSettingsViewModel : BaseChildViewModel
    {
        public override string Name => "Device Connection";

        protected override void InternalDevice_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
