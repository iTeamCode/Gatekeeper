using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Gatekeeper.TestPortal.Common
{
    /// <summary>
    /// Management app setting.
    /// </summary>
    public class GatekeeperSettingManager
    {
        public static string GetAppsetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
    /// <summary>
    /// Setting name
    /// </summary>
    public struct SettingName
    {
        public const string BROWSER = "Tests.Browser";
        public const string HOST = "Tests.Host";
        public const string PORT = "Tests.Port";
        public const string ENVIRONMENT = "Tests.Environment";

        public const string CHURCHCODE = "Tests.ChurchCode";
    }
}
