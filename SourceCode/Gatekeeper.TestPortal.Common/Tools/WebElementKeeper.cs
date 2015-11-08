using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    public class WebElementKeeper
    {
        private static TimeSpan _timeoutInterval;
        static WebElementKeeper()
        {
            _timeoutInterval = TimeSpan.FromSeconds(30);
            int conifgInterval;
            if (int.TryParse(GatekeeperSettingManager.GetAppsetting(SettingName.WAITTIMEOUTINTERVAL), out conifgInterval))
            {
                _timeoutInterval = TimeSpan.FromSeconds(conifgInterval);
            }
        }

        #region Waiting For Element
        public static void WaitingFor_ElementExists(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, _timeoutInterval);
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static void WaitingFor_ElementIsVisible(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, _timeoutInterval);
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        #endregion Waiting For Element

        #region Waiting For Url
        public static bool WaitingFor_UrlContains(IWebDriver driver, string fraction)
        {
            var wait = new WebDriverWait(driver, _timeoutInterval);
            return wait.Until(ExpectedConditions.UrlContains(fraction));
        }

        public static bool WaitingFor_UrlToBe(IWebDriver driver,PageAlias alias )
        {
            var url = RouteMapper.ConvertAliasToUrl(alias);
            var wait = new WebDriverWait(driver, _timeoutInterval);
            return wait.Until(ExpectedConditions.UrlToBe(url));
        }
        public static bool WaitingFor_UrlMatches(IWebDriver driver, string regex)
        {
            var wait = new WebDriverWait(driver, _timeoutInterval);
            return wait.Until(ExpectedConditions.UrlMatches(regex));
        }
        #endregion


        #region Waiting For Text
        public static bool WaitingFor_TextToBePresentInElement(IWebDriver driver, IWebElement element, string text, TimeSpan timeOut)
        {
            var isFound = true;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            }
            catch { isFound = false; }
            return isFound;
        }
        public static bool WaitingFor_TextToBePresentInElement(IWebDriver driver, IWebElement element, string text)
        {
            return WaitingFor_TextToBePresentInElement(driver, element, text, _timeoutInterval);
        }
        #endregion
    }
}
