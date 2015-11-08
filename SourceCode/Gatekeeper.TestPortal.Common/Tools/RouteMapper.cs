using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    public static class RouteMapper
    {
        private static Dictionary<PageAlias, string> _dicMap;

        static RouteMapper()
        {
            InitializationDicMap();
        }
        /// <summary>
        /// Convert page alias to url.
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public static string ConvertAliasToUrl(PageAlias alias)
        {
            if (!_dicMap.Keys.Contains(alias))
            {
                throw new Exception(string.Format("Can not convert the alias [{0}]", alias));
            }
            return _dicMap[alias].ToLower();
        }
        /// <summary>
        /// Convert url to page alias.
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>page alias</returns>
        public static PageAlias ConvertUrlToAlias(string url)
        {
            if (!_dicMap.Values.Contains(url))
            {
                throw new Exception(string.Format("Can not convert the url [{0}]", url));
            }

            var pageAlias = PageAlias.Empty_Page;
            foreach(var item in _dicMap)
            {
                if(item.Value == url)
                {
                    pageAlias = item.Key;
                }
            }
            return pageAlias;
        }

        private static void InitializationDicMap()
        {
            _dicMap = new Dictionary<PageAlias, string>(100);

            var baseUrl = string.Empty;

            #region Dashboard
            baseUrl = BuildBaseUrl(AppAlias.Dashboard);
            _dicMap.Add(PageAlias.Dashboard_SignIn, string.Format("{0}/#/Login", baseUrl));
            _dicMap.Add(PageAlias.Dashboard_Home, string.Format("{0}/#/", baseUrl));
            _dicMap.Add(PageAlias.Dashboard_Configuration, string.Format("{0}/#/configurator", baseUrl));
            #endregion Dashboard

            #region Coordinator
            baseUrl = BuildBaseUrl(AppAlias.Coordinator);
            _dicMap.Add(PageAlias.Coordinator_SignIn, string.Format("{0}/#/Login", baseUrl));
            #endregion Coordinator
        }

        private static string BuildBaseUrl(AppAlias app)
        {
            var appName = app.GetDescription();
            var environment = GatekeeperSettingManager.GetAppsetting(SettingName.ENVIRONMENT);
            var churchCode = GatekeeperSettingManager.GetAppsetting(SettingName.CHURCHCODE);
            
            var baseUrl = string.Empty;
            if (app == AppAlias.Infellowship)
            {
                baseUrl = string.Format("https://{0}.{1}.{2}.com", churchCode, environment, appName);
            }
            else if (app != AppAlias.Unkonw)
            {
                baseUrl = string.Format("https://{0}.{1}.fellowshipone.com", appName, environment);
            }
            
            return baseUrl.ToLower();
        }
    }
}
