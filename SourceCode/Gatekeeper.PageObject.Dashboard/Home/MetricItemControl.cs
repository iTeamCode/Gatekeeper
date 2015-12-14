using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        protected const string cst_ProgressBar = ".//div[@role='progressbar']/parent::div";
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
        //public string Text { get { return lblName.Text; } }
        public string Text
        {
            get
            {
                var element = this.lblName;
                var jsScript = string.Format("return $(\"span > label[for='{0}']\").text()", element.GetAttribute("for"));
                IJavaScriptExecutor jsExecutor = this._driver as IJavaScriptExecutor;
                var eleText = jsExecutor.ExecuteScript(jsScript);
                return (eleText != null) ? eleText.ToString() : string.Empty;
            }
        }

        public bool Selected
        {
            get { return this.chkSelected.Selected; }
            set
            {
                if (this.chkSelected.Selected != value)
                {
                    //Actions action = new Actions(this._driver);
                    //var element = this.lblName;
                    //action.Click(element).Build().Perform();
                    
                    var element = this.lblName;
                    var jsScript = string.Format("$(\"span > label[for='{0}']\").click()", element.GetAttribute("for"));
                    IJavaScriptExecutor jsExecutor = this._driver as IJavaScriptExecutor;
                    jsExecutor.ExecuteScript(jsScript);

                    //this.lblName.Click();
                }
                WebElementKeeper.WaitingFor_WebElementAttributeChangedTo(this._driver, By.XPath(cst_ProgressBar), "class", "ng-hide");
            }
        }

        public int Id
        {
            get
            {
                var element = this.lblName;
                var text = element.GetAttribute("for");
                var index = text.IndexOf('-') + 1;
                return int.Parse(text.Substring(index, text.Length - index));
            }
        }
        #endregion Property for client
    }
}