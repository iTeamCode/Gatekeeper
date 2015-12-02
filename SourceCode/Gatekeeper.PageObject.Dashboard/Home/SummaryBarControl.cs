using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class SummaryBarControl : PageControlBase
    {
        public SummaryBarControl(IWebDriver driver, string rootXPath) : base(driver, rootXPath) { }
        
        #region Dom elements xpath
        protected const string cst_SummaryBar_ImgIcon = "{0}/div[contains(@class,'Metric-name')]/div[@class='Metric-name-wrapper']/img";
        protected const string cst_SummaryBar_Name = "{0}/div[contains(@class,'Metric-name')]/div[@class='Metric-name-wrapper']/div[contains(@class,'Metric-name-text')]";
        protected const string cst_SummaryBar_Value = "{0}/div[contains(@class,'Metric-value')]";
        protected const string cst_SummaryBar_lastWindow = "({0}/div[contains(@class,'Metric-lastWindow')])[1]";
        protected const string cst_SummaryBar_lastWindow_Year = "({0}/div[contains(@class,'Metric-lastWindow')])[2]";
        #endregion Dom elements xpath

        #region Dom elements object
        protected IWebElement _imgIcon;
        protected IWebElement imgIcon
        {
            get
            {
                if (_imgIcon == null)
                {
                    var xPath = string.Format(cst_SummaryBar_ImgIcon, this._rootXPath);
                    _imgIcon = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                }
                return _imgIcon;
            }
        }

        protected IWebElement _txtName;
        protected IWebElement txtName
        {
            get
            {
                if (_txtName == null)
                {
                    var xPath = string.Format(cst_SummaryBar_Name, this._rootXPath);
                    _txtName = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                }
                return _txtName;
            }
        }

        protected IWebElement _txtValue;
        protected IWebElement txtValue
        {
            get
            {
                if (_txtValue == null)
                {
                    var xPath = string.Format(cst_SummaryBar_Value, this._rootXPath);
                    _txtValue = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                }
                return _txtValue;
            }
        }
        #endregion Dom elements object

        #region Property for client
        public string Name { get { return this.txtName.Text; } }
        public decimal Value
        {
            get
            {
                decimal value;
                var isGetData = decimal.TryParse(this.txtValue.Text.Replace("$", ""), out value);
                return isGetData ? value : 0.00m;
            }
        }
        public string CompareWithLast
        {
            get
            {
                var xPath = string.Format(cst_SummaryBar_lastWindow + "/span", this._rootXPath);
                var element = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                if (element == null)
                {
                    throw new Exception("Can not find the lastWindow!");
                }
                return element.Text;
            }
        }
        public string CompareWithLastYear
        {
            get
            {
                var xPath = string.Format(cst_SummaryBar_lastWindow_Year + "/span", this._rootXPath);
                var element = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                if (element == null)
                {
                    throw new Exception("Can not find the lastWindowYear!");
                }
                return element.Text;
            }
        }

        #endregion Property for client
    }
}

