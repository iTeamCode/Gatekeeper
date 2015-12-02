using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class ChartSectionControl : PageControlBase
    {
        public ChartSectionControl(IWebDriver driver, string rootXPath)
            : base(driver, rootXPath)
        {
            //DateRange root:(.//div[@ng-controller='DashboardController']/div[contains(@class,'Metric')])[i]
            cst_SummaryBar = string.Format("{0}/div[contains(@class,'Metric-summary')]", rootXPath);
            cst_DetailBar = string.Format("{0}/div[contains(@class,'metric-result-detail-row')]", rootXPath);
            cst_MetricItems = string.Format("{0}/div[contains(@class,'Metric-detail')]/div[contains(@class,'Metric-items')]/span", rootXPath);
            cst_ChartViewHeader = string.Format("{0}/div[contains(@class,'Metric-chart-heading')]", rootXPath);
            cst_ChartViewDetail = string.Format("{0}/div[contains(@class,'Metric-detail')]", rootXPath);
        }

        #region Dom elements xpath
        
        protected readonly string cst_SummaryBar;
        protected readonly string cst_DetailBar;
        protected readonly string cst_MetricItems;
        protected readonly string cst_ChartViewHeader;
        protected readonly string cst_ChartViewDetail;

        protected const string cst_ProgressBar = ".//div[@role='progressbar']/parent::div";
        #endregion Dom elements xpath

        #region Dom elements object
        //[FindsBy(How = How.XPath, Using = ChartSectionControl.cst_SummaryBar)]
        protected IWebElement _summaryBar;
        protected IWebElement summaryBar
        {
            get
            {
                if (_summaryBar == null)
                {
                    _summaryBar = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_SummaryBar));
                }
                return _summaryBar;
            }
        }
        //[FindsBy(How = How.XPath, Using = ChartSectionControl.cst_DetailBar)]
        protected IWebElement _detailBar;
        protected IWebElement detailBar
        {
            get
            {
                if (_detailBar == null)
                {
                    _detailBar = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_DetailBar));
                }
                return _detailBar;
            }
        }
        //[FindsBy(How = How.XPath, Using = ChartSectionControl.cst_MetricItems)]
        protected IList<IWebElement> _metricItems;
        protected IList<IWebElement> metricItems
        {
            get
            {
                if (_metricItems == null)
                {
                    _metricItems = WebElementKeeper.WaitingFor_GetElementsWhenIsVisible(this._driver, By.XPath(cst_MetricItems));
                }
                return _metricItems;
            }
        }

        //[FindsBy(How = How.XPath, Using = ChartSectionControl.cst_ChartViewDetail)]
        protected IList<IWebElement> _chartViewDetail;
        protected IList<IWebElement> chartViewDetail
        {
            get
            {
                //if (_chartViewDetail == null)
                {
                    _chartViewDetail = WebElementKeeper.WaitingFor_GetElementsWhenIsVisible(this._driver, By.XPath(cst_ChartViewDetail));
                }
                return _chartViewDetail;
            }
        }
        #endregion Dom elements object

        #region Property for client
        /// <summary>
        /// get summary bar.
        /// </summary>
        public SummaryBarControl SummaryBar
        {
            get
            {
                SummaryBarControl control = null;
                if (summaryBar != null)
                {
                    control = GatekeeperFactory.CreatePageControl<SummaryBarControl>(this._driver, cst_SummaryBar);
                }
                return control;
            }
        }
        /// <summary>
        /// get detail bar.
        /// </summary>
        public DetailBarControl DetailBar
        {
            get
            {
                DetailBarControl control = null;
                if (detailBar != null)
                {
                    control = GatekeeperFactory.CreatePageControl<DetailBarControl>(this._driver, cst_DetailBar);
                }
                return control;
            }
        }
        /// <summary>
        /// get metric item list.
        /// </summary>
        public List<MetricItemControl> MetricItems {
            get
            {
                List<MetricItemControl> controls = new List<MetricItemControl>(20); ;
                if (metricItems != null)
                {                    
                    for (var i = 0; i < metricItems.Count; i++)
                    {
                        var xPath = string.Format("({0})[{1}]", cst_MetricItems, i + 1);
                        controls.Add(GatekeeperFactory.CreatePageControl<MetricItemControl>(this._driver, xPath));
                    }
                }
                return controls;
            }
        }
        /// <summary>
        /// get chart view.
        /// </summary>
        public ChartViewControl ChartView
        {
            get
            {
                ChartViewControl control = null;
                if (chartViewDetail != null)
                {
                    control = GatekeeperFactory.CreatePageControl<ChartViewControl>(this._driver, cst_ChartViewDetail);
                }
                return control;
            }
        }


        public bool Expand
        {
            get
            {
                var isExpand = false;
                if (this.detailBar != null && this.detailBar.Displayed) { isExpand = true; }
                return isExpand;
            }
            set
            {
                var isExpand = true;
                if (this.detailBar == null || !this.detailBar.Displayed) { isExpand = false; }

                if (isExpand != value)
                {
                    if (isExpand)
                    {
                        this.detailBar.Click();
                        WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this._driver, By.XPath(cst_DetailBar));
                    }
                    else
                    {
                        this.summaryBar.Click();
                        WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this._driver, By.XPath(cst_SummaryBar));
                    }
                    WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this._driver, By.XPath(cst_ProgressBar));
                    //WebElementKeeper.WaitingFor_WebElementAttributeChangedTo(this._driver, By.XPath(cst_ProgressBar), "class", "ng-hide");
                }
            }
        }
        #endregion Property for client

        #region Action for client
        #endregion Action for client
    }
}
