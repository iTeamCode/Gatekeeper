using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    /// <summary>
    /// Active widget item control.
    /// </summary>
    public class ActiveWidgetItemControl : PageControlBase
    {
        public ActiveWidgetItemControl(IWebDriver driver, string rootXPath)
            : base(driver, rootXPath)
        {
            InitControl(driver, rootXPath);
        }
        public void InitControl(IWebDriver driver, string rootXPath)
        {
            this._driver = driver;
            this._rootXPath = rootXPath;
        }

        /// <summary>
        /// get 'ActiveWidgetItemControl' selected .
        /// </summary>
        public bool Selected { 
            get { return _checkbox.Selected; }
            set {
                if (_checkbox.Selected != value)
                {
                    this._text.Click();
                }
            }
        }
        /// <summary>
        /// get 'ActiveWidgetItemControl' Text .
        /// </summary>
        public string Text { get { return _text.Text; } }


        #region Web Element
        protected IWebElement _checkbox
        {
            get
            {
                IWebElement element = null;
                if (_driver != null)
                {
                    var xPathTemp = string.Format("{0}/input[@type='checkbox']", _rootXPath);
                    element = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPathTemp));
                }
                return element;
            }
        }
        protected IWebElement _text
        {
            get
            {
                IWebElement element = null;
                if (_driver != null)
                {
                    var headerXPath = string.Format("{0}/label", _rootXPath);
                    element = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(headerXPath));
                }
                return element;
            }
        }
        #endregion

        //public void WaitingForDomElementShow()
        //{
        //    var xPathTemp = string.Format("{0}/input[@type='checkbox']", _rootXPath);
        //    var items = WebElementKeeper.WaitingFor_GetElementsWhenExists(this._driver, By.XPath(xPathTemp));
        //}
    }
}
