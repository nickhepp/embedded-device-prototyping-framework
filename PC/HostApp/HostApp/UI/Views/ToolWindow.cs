using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Views
{
    public class ToolWindow : DockContent
    {

        public ToolWindow()
        {
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CloseButton = true;
            CloseButtonVisible = true;
            HideOnClose = true;
            DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.DockRight;
            AllowEndUserDocking = true;
        }

        public void Initialize(Control ctrl, string text)
        {
            this.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
            this.Text = text;
            this.ToolTipText = text;
        }



    }
}
