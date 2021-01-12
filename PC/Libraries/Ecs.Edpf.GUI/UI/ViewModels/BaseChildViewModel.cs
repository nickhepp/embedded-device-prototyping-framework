using Ecs.Edpf.Devices;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public abstract class BaseChildViewModel : BaseDeviceViewModel, IChildViewModel
    {

        public abstract string Name { get; }

        public virtual Image ViewImage => null;





    }
}
