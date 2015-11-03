using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Gatekeeper.TestPortal.Common
{
    /// <summary>
    /// Management
    /// </summary>
    public class GatekeeperSettingManager
    {
        public static string GetAppsetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
