using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Views
{
    public interface IToolWindowCohortFactory
    {
        void ApplyDefaultLayout(DockPanel dockPanel);
        List<IToolWindowCohort> GetToolWindowCohorts();
    }
}