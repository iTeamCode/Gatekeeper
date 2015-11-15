using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{    
    public class MetricItemControl : PageControlBase
    {
        public MetricItemControl(IWebDriver driver, string rootXPath)
            : base(driver, rootXPath)
        {
            cst_MetricItem_CheckBox = string.Format("{0}/input[@type='checkbox']", rootXPath);
            cst_MetricItem_Label = string.Format("{0}/label", rootXPath);
        }

        #region Dom elements xpath
        //DateRange root:(.//div[@ng-controller='DashboardController']/div[contains(@class,'Metric')])[i]/div[contains(@class,'Metric-detail')]/div[contains(@class,'Metric-items')]/span
        protected readonly string cst_MetricItem_CheckBox;
        protected readonly string cst_MetricItem_Label;

        protected const string cst_ProgressBar = ".//div[@role='progressbar']";
        #endregion Dom elements xpath

        #region Dom elements object
        //[FindsBy(How = How.XPath, Using = MetricItemControl.cst_MetricItem_CheckBox)]
        protected IWebElement _chkSelected;
        protected IWebElement chkSelected
        {
            get
            {
                //if (_chkSelected == null)
                {
                    _chkSelected = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_MetricItem_CheckBox));
                }
                return _chkSelected;
            }
        }
        //[FindsBy(How = How.XPath, Using = MetricItemControl.cst_MetricItem_Label)]
        protected IWebElement _lblName;
        protected IWebElement lblName
        {
            get
            {
                //if (_lblName == null)
                {
                    _lblName = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_MetricItem_Label));
                }
                return _lblName;
            }
        }
        #endregion Dom elements object

        #region Property for client
        public string Text { get { return lblName.Text; } }

        public bool Selected
        {
            get { return this.chkSelected.Selected; }
            set
            {
                if (this.chkSelected.Selected != value)
                {
                    this.lblName.Click();
                }
                WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this._driver, By.XPath(cst_ProgressBar));
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
        #endregion Property for client
    }
}
