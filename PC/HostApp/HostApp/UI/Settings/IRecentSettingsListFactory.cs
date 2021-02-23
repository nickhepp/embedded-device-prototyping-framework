using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.UI.Settings
{
    public interface IRecentSettingsListFactory
    {

        IRecentSettingsList GetRecentSettingsResourceStoresList();

    }
}
