using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class ActiveWidgetControl
    {
        protected IWebDriver _driver;
        protected string _rootXPath;
        public ActiveWidgetControl(IWebDriver driver, string rootXPath)
        {
            InitControl(driver, rootXPath);
        }
        public void InitControl(IWebDriver driver, string rootXPath)
        {
            this._driver = driver;
            this._rootXPath = rootXPath;
        }

        #region Web Element

        protected IWebElement _headBar
        {
            get
            {
                IWebElement element = null;
                if (_driver != null)
                {
                    var headerXPath = string.Format(cst_HeaderXPathTemp, _rootXPath);
                    element = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(headerXPath));
                }
                return element;
            }
        }
        protected const string cst_HeaderXPathTemp = "{0}/div[contains(@class,'Configurator')]/div[contains(@class,'Configurator-header')]";
        protected const string cst_ItemPanelXPathTemp = "{0}/div[contains(@class,'Configurator')]/div[contains(@class,'Configurator-items')]";
        protected IWebElement _itemPanel
        {
            get
            {
                IWebElement element = null;
                if (_driver != null)
                {
                    var headerXPath = string.Format(cst_ItemPanelXPathTemp, _rootXPath);
                    element = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(headerXPath));
                }
                return element;
            }
        }
        protected void WaitingForItemPanelStateChange()
        {
            var headerXPath = string.Format(cst_ItemPanelXPathTemp, _rootXPath);
            WebElementKeeper.WaitingFor_ElementExists(this._driver, By.XPath(headerXPath));
        }

        #endregion

        public string Title
        {
            get
            {
                var eleName = _headBar.FindElement(By.XPath("./div[contains(@class,'Configurator-header-name')]"));
                return eleName.Text;
            }
        }
        public int SelectCount
        {
            get {
                var count = 0;
                if (_items != null)
                {
                    _items.ForEach(x => { if (x.Selected) count++; });
                }
                return count;
            }
        }
        public bool Enabled
        {
            get
            {
                var chkSwitch = _headBar.FindElement(By.XPath("./span[contains(@class,'Configurator-header-switch')]/input[@type='checkbox']"));
                return chkSwitch.Selected;
            }
            set
            {
                var btnSwitch = _headBar.FindElement(By.XPath("./span[contains(@class,'Configurator-header-switch')]"));
                var chkSwitch = btnSwitch.FindElement(By.XPath("./input[@type='checkbox']"));
                if (chkSwitch.Selected != value) { 
                    btnSwitch.Click();
                    if (value)
                    {
                        WaitingForItemPanelStateChange();
                    }
                }
            }
        }
        public bool Expand
        {
            get
            {
                var iExpand = _headBar.FindElement(By.XPath("./div[@class='Configurator-header-control']/i[contains(@class,'fa-chevron-up')]"));
                return iExpand.Displayed;
            }
            set
            {
                var btnSwitch = _headBar.FindElement(By.XPath("./div[@class='Configurator-header-control']"));
                var iExpand = btnSwitch.FindElement(By.XPath("./i[contains(@class,'fa-chevron-up')]"));
                if (iExpand.Displayed != value) { btnSwitch.Click(); }
            }
        }

        protected List<ActiveWidgetItemControl> _items;
        public List<ActiveWidgetItemControl> Items
        {
            get
            {
                if (_items == null)
                {
                    var xPathTemp = string.Format(cst_ItemPanelXPathTemp + "/ul/li", _rootXPath);
                    var items = WebElementKeeper.WaitingFor_GetElementsWhenExists(this._driver, By.XPath(xPathTemp));

                    _items = new List<ActiveWidgetItemControl>(50);
                    for (var i = 1; i <= items.Count; i++)
                    {
                        var element = new ActiveWidgetItemControl(this._driver, string.Format("({0})[{1}]", xPathTemp, i));
                        //element.WaitingForDomElementShow();
                        _items.Add(element);
                    }
                }
                return _items;
            }
        }


        //public void WaitingForDomElementShow()
        //{
        //    var xPathTemp = string.Format(cst_ItemPanelXPathTemp + "/ul/li", _rootXPath);
        //    var items = WebElementKeeper.WaitingFor_GetElementsWhenExists(this._driver, By.XPath(xPathTemp));
        //}
    }
}
