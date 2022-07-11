using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public interface IDeviceConnectionSettingsViewModel: ISettingsResource
    {

        bool IsOpen { get; set; }



    }
}
