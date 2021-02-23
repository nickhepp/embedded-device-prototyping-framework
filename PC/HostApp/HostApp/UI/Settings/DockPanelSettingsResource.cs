using Ecs.Edpf.Devices.IO;
using Ecs.Edpf.GUI.Settings;
using HostApp.UI.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace HostApp.UI.Settings
{
    public class DockPanelSettingsResource : ISettingsResource
    {

        private DeserializeDockContent _deserializeDockContent;

        private Dictionary<string, IToolWindowCohort> _docWindows;

        private DockPanel _dockPanel;

        private IToolWindowCohortFactory _toolWindowCohortFactory;

        private const string DockPanelSettingsName = "DockPanelSettings";

        public DockPanelSettingsResource(DockPanel dockPanel, Dictionary<string, IToolWindowCohort> docWindows, IToolWindowCohortFactory toolWindowCohortFactory)
        {
            _dockPanel = dockPanel;
            _docWindows = docWindows;
            _toolWindowCohortFactory = toolWindowCohortFactory;
            _deserializeDockContent = new DeserializeDockContent((string persistString) => _docWindows[persistString].GetToolWindow());
        }

        public string ResourceName => nameof(DockPanelSettingsResource);

        public void ApplySettings(Dictionary<string, string> settings)
        {
            byte[] dockPnlBytes = Convert.FromBase64String(settings[DockPanelSettingsName]);
            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Write(dockPnlBytes, 0, dockPnlBytes.Length);
                memStream.Position = 0;
                _dockPanel.LoadFromXml(memStream, _deserializeDockContent);
            }
           }

        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            using (MemoryStream memStream = new MemoryStream())
            {
                _dockPanel.SaveAsXml(memStream, Encoding.UTF8);
                byte[] dockPanelSettings = memStream.ToArray();
                settings[DockPanelSettingsName] = Convert.ToBase64String(dockPanelSettings);
            }

            return settings;
        }

        public void ApplyDefaultSettings()
        {
            _toolWindowCohortFactory.ApplyDefaultLayout(_dockPanel);
        }
    }
}
