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
        #region Element is exist
        public static IWebElement WaitingFor_GetElementWhenExists(IWebDriver driver, By by, TimeSpan timeOut)
        {
            IWebElement element;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                element = wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch { element = null; }
            return element;
        }
        public static IWebElement WaitingFor_GetElementWhenExists(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementWhenExists(driver, by, _timeoutInterval);
        }
        public static bool WaitingFor_ElementExists(IWebDriver driver, By by, TimeSpan timeOut)
        {
            return (WaitingFor_GetElementWhenExists(driver, by, timeOut) != null) ? true : false;
        }
        public static bool WaitingFor_ElementExists(IWebDriver driver, By by)
        {
            return WaitingFor_ElementExists(driver, by, _timeoutInterval);
        }
        #endregion Element is exist

        #region Element is visible
        public static IWebElement WaitingFor_GetElementWhenIsVisible(IWebDriver driver, By by, TimeSpan timeOut)
        {
            IWebElement element;
            var wait = new WebDriverWait(driver, timeOut);
            try
            {
                element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch { element = null; }
            return element;
        }
        public static IWebElement WaitingFor_GetElementWhenIsVisible(IWebDriver driver, By by)
        {
            return WaitingFor_GetElementWhenIsVisible(driver, by, _timeoutInterval);
        }
        public static bool WaitingFor_ElementIsVisible(IWebDriver driver, By by, TimeSpan timeOut)
        {
            return (WaitingFor_GetElementWhenExists(driver, by, timeOut) != null) ? true : false;
        }
        public static bool WaitingFor_ElementIsVisible(IWebDriver driver, By by)
        {
            return WaitingFor_ElementIsVisible(driver, by, _timeoutInterval);
        }
        #endregion Element is visible
        #endregion Waiting For Element

        #region Waiting For Url
        public static bool WaitingFor_UrlContains(IWebDriver driver, string fraction, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.UrlContains(fraction));
        }
        public static bool WaitingFor_UrlContains(IWebDriver driver, string fraction)
        {
            return WaitingFor_UrlContains(driver, fraction, _timeoutInterval);
        }

        public static bool WaitingFor_UrlToBe(IWebDriver driver, PageAlias alias, TimeSpan timeOut)
        {
            var url = RouteMapper.ConvertAliasToUrl(alias);
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.UrlToBe(url));
        }
        public static bool WaitingFor_UrlToBe(IWebDriver driver, PageAlias alias)
        {
            return WaitingFor_UrlToBe(driver, alias, _timeoutInterval);
        }

        public static bool WaitingFor_UrlMatches(IWebDriver driver, string regex, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.UrlMatches(regex));
        }
        public static bool WaitingFor_UrlMatches(IWebDriver driver, string regex)
        {
            return WaitingFor_UrlMatches(driver, regex, _timeoutInterval);
        }
        #endregion

        #region Waiting For Text
        public static bool WaitingFor_TextToBePresentInElement(IWebDriver driver, IWebElement element, string text, TimeSpan timeOut)
        {
            var wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
        public static bool WaitingFor_TextToBePresentInElement(IWebDriver driver, IWebElement element, string text)
        {
            return WaitingFor_TextToBePresentInElement(driver, element, text, _timeoutInterval);
        }
        #endregion
    }
}
