using Ecs.Edpf.Devices;
using Ecs.Edpf.Devices.ComponentModel;
using Ecs.Edpf.Devices.Devices;
using Ecs.Edpf.GUI.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Ecs.Edpf.GUI.UI.ViewModels.Connections
{
    public class ConnectionViewModelFactoryViewModel : BaseDeviceViewModel, IConnectionViewModelFactoryViewModel
    {

        private List<ISettingsResource> _settingsConnectionViewModels;

        private ICompositeDeviceProvider _compositeDeviceProvider;
        public IDeviceProvider GlobalDeviceProvider => _compositeDeviceProvider;


        public IEnumerable<IConnectionViewModel> ConnectionViewModels { get; private set; }



        public Image ViewImage => throw new NotImplementedException();

        public string Name => "Connections";

        public string ResourceName => nameof(ConnectionViewModelFactoryViewModel);

        public ConnectionViewModelFactoryViewModel(IDeviceStateMachine deviceStateMachine, 
            ICompositeDeviceProvider compositeDeviceProvider,
            IEnumerable<IConnectionViewModel> connectionViewModels) : base(deviceStateMachine)
        {
            _compositeDeviceProvider = compositeDeviceProvider;
            ConnectionViewModels = connectionViewModels;
            _settingsConnectionViewModels = ConnectionViewModels.Where(
                connViewMdl => connViewMdl is ISettingsResource).ToList().ConvertAll(
                connViewMdl => (ISettingsResource)connViewMdl);
        }

        protected override void OnDeviceStateChanged()
        {
            if (DeviceState == DeviceState.OpenedDevice)
            {
                foreach (IConnectionViewModel connViewMdl in ConnectionViewModels)
                {
                    connViewMdl.Enabled = connViewMdl.HasDevice;
                }
            }
            else if (DeviceState == DeviceState.NoDevice)
            {
                foreach (IConnectionViewModel connViewMdl in ConnectionViewModels)
                {
                    connViewMdl.Enabled = true;
                }
            }
        }

        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            foreach (ISettingsResource resource in _settingsConnectionViewModels)
            {
                Dictionary<string, string> rsrcSettings = resource.GetSettings();
                foreach (string resourceKey in rsrcSettings.Keys)
                {
                    settings[resourceKey] = rsrcSettings[resourceKey];
                }
            }
            return settings;
        }

        public void ApplySettings(Dictionary<string, string> settings)
        {
            foreach (ISettingsResource resource in _settingsConnectionViewModels)
            {
                resource.ApplySettings(settings);
            }
        }

        public void ApplyDefaultSettings()
        {
            foreach (ISettingsResource resource in _settingsConnectionViewModels)
            {
                resource.ApplyDefaultSettings();
            }
        }
    }
}
