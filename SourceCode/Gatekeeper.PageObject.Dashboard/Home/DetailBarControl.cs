using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class DetailBarControl : PageControlBase
    {
        public DetailBarControl(IWebDriver driver, string rootXPath)
            : base(driver, rootXPath)
        {
            cst_DetailBar_MainArea = string.Format("{0}/div[1]", rootXPath);
            cst_DetailBar_LastYearArea = string.Format("{0}/div[2]", rootXPath);
            cst_DetailBar_BeforeLastYearArea = string.Format("{0}/div[3]", rootXPath);
        }

        #region Dom elements xpath
        protected readonly string cst_DetailBar_MainArea;
        protected readonly string cst_DetailBar_LastYearArea;
        protected readonly string cst_DetailBar_BeforeLastYearArea;
        #endregion Dom elements xpath

        #region Dom elements object
        protected IWebElement _imgIcon;
        protected IWebElement imgIcon
        {
            get
            {
                if (_imgIcon == null)
                {
                    var xPath = cst_DetailBar_MainArea + "/div[contains(@class,'Metric-name')]/div/img";
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
                    var xPath = cst_DetailBar_MainArea + "/div[contains(@class,'Metric-name')]/div/div[contains(@class,'Metric-name-text')]";
                    _txtName = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                }
                return _txtName;
            }
        }

        protected IWebElement _eleMainArea;
        protected IWebElement eleMainArea
        {
            get
            {
                if (_eleMainArea == null)
                {
                    var xPath = cst_DetailBar_MainArea;
                    _eleMainArea = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                }
                return _eleMainArea;
            }
        }

        protected IWebElement _eleLastYearArea;
        protected IWebElement eleLastYearArea
        {
            get
            {
                if (_eleLastYearArea == null)
                {
                    var xPath = cst_DetailBar_LastYearArea;
                    _eleLastYearArea = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                }
                return _eleLastYearArea;
            }
        }

        protected IWebElement _eleBeforeLastYearArea;
        protected IWebElement eleBeforeLastYearArea
        {
            get
            {
                if (_eleBeforeLastYearArea == null)
                {
                    var xPath = cst_DetailBar_BeforeLastYearArea;
                    _eleBeforeLastYearArea = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(xPath));
                }
                return _eleBeforeLastYearArea;
            }
        }

        #endregion Dom elements object

        #region Property for client
        public string Name { get { return this.txtName.Text; } }

        public string MainAreaTitle
        {
            get
            {
                var element = this.eleMainArea.FindElement(By.XPath("./div[@class='metric-detail-value']/div[contains(@class,'year')]"));
                return element.Text;
            }
        }
        public decimal MainAreaValue
        {
            get
            {
                decimal value;
                var element = this.eleMainArea.FindElement(By.XPath("./div[@class='metric-detail-value']/div[contains(@class,'metric-detail-value-number')]"));
                var isGetData = decimal.TryParse(element.Text.Replace("$", ""), out value);
                return isGetData ? value : 0.00m;
            }
        }

        public string LastYearAreaTitle
        {
            get
            {
                var element = this.eleLastYearArea.FindElement(By.XPath("./div[contains(@class,'year')]"));
                return element.Text;
            }
        }
        public decimal LastYearAreaValue
        {
            get
            {
                decimal value;
                var element = this.eleLastYearArea.FindElement(By.XPath("./div[contains(@class,'metric-detail-value-number--last')]"));
                var isGetData = decimal.TryParse(element.Text.Replace("$", ""), out value);
                return isGetData ? value : 0.00m;
            }
        }

        public string BeforeLastYearAreaTitle
        {
            get
            {
                var element = this.eleBeforeLastYearArea.FindElement(By.XPath("./div[contains(@class,'year')]"));
                return element.Text;
            }
        }
        public decimal BeforeLastYearAreaValue
        {
            get
            {
                decimal value;
                var element = this.eleBeforeLastYearArea.FindElement(By.XPath("./div[contains(@class,'metric-detail-value-number--last2last')]"));
                var isGetData = decimal.TryParse(element.Text.Replace("$", ""), out value);
                return isGetData ? value : 0.00m;
            }
        }
        
        #endregion Property for client
    }
}
