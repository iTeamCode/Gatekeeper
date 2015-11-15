using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    public class GatekeeperFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDriverManager CreateDriverManager()
        {
            var browser = GatekeeperSettingManager.GetAppsetting(SettingName.BROWSER);
            var driverPath = GatekeeperSettingManager.GetAppsetting(SettingName.DRIVERPATH);
            if (string.IsNullOrEmpty(browser))
            {
                throw new Exception(string.Format("Can not get config '{0}'", SettingName.BROWSER));
            }

            IWebDriver driver;
            switch (browser.ToLower())
            {
                case "*iexplore":
                case "*ie":
                    driver = new InternetExplorerDriver(driverPath);
                    break;
                case "*firefox":
                    driver = new FirefoxDriver();
                    break;
                case "*chrome":
                    driver = new ChromeDriver(driverPath);
                    break;

                default:
                    throw new Exception("Create driver failed!");
            }
            var manager = new WebDriverManager(driver);
            return manager;
        }
        /// <summary>
        /// Create page object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreatePageManager<T>(IWebDriver driver) where T : PageObjectBase
        {
            Type type = typeof(T);
            var pageObject = (T)Activator.CreateInstance(type, driver);
            return pageObject;
        }

        /// <summary>
        /// Create page control
        /// </summary>
        /// <typeparam name="T">page control type</typeparam>
        /// <param name="driver">driver</param>
        /// <param name="rootXPath">rootXPath</param>
        /// <returns>entity</returns>
        public static T CreatePageControl<T>(IWebDriver driver, string rootXPath) where T : PageControlBase
        {
            Type type = typeof(T);
            var pageObject = (T)Activator.CreateInstance(type, driver, rootXPath);
            return pageObject;
        }

        public static T CreateModalDialog<T>(IWebDriver driver, string rootXPath) where T : ModalDialogBase
        {
            Type type = typeof(T);
            var pageObject = (T)Activator.CreateInstance(type, driver, rootXPath);
            return pageObject.VerifyElement() ? pageObject : null;
        }
    }
}
