using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApp.UI.Views
{
    public interface IToolWindowCohort
    {

        string Name { get; }


        ToolWindow GetToolWindow();


        Bitmap Image { get; }


        IViewModel ViewModel { get; }


    }
}
