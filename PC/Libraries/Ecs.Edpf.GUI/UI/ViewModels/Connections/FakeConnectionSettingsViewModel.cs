using Ecs.Edpf.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class FakeConnectionSettingsViewModel : DeviceConnectionSettingsViewModel
    {
        protected override string GetResourceName()
        {
            throw new NotImplementedException();
        }

        protected override void InternalApplyDefaultSettings()
        {
            throw new NotImplementedException();
        }

        protected override void InternalApplySettings(Dictionary<string, string> settings)
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<string, string> InternalGetSettings()
        {
            throw new NotImplementedException();
        }
    }
}
