using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class HomePage : PageObjectBase
    {
        public HomePage(IWebDriver driver) : base(driver) { }


        #region Dom elements xpath
        //DateRange
        protected const string cst_ToolBar = ".//div[@ng-controller='DashboardController']/div[contains(@class,'header')]";
        protected const string cst_ChartSections = ".//div[@ng-controller='DashboardController']/div[contains(@class,'Metric')]";
        #endregion Dom elements xpath

        #region Dom elements object
        //[FindsBy(How = How.XPath, Using = HomePage.cst_ToolBar)]
        protected IWebElement _toolBar;
        #endregion Dom elements object

        #region Property for client
        /// <summary>
        /// get tool bar
        /// </summary>
        public ToolBarControl ToolBar
        {
            get
            {
                if (_toolBar == null)
                {
                    _toolBar = WebElementKeeper.WaitingFor_GetElementWhenExists(this.Driver, By.XPath(cst_ToolBar));
                }
                return GatekeeperFactory.CreatePageControl<ToolBarControl>(this.Driver, cst_ToolBar);                
            }
        }

        protected List<ChartSectionControl> _chartSections;
        /// <summary>
        /// get report sections
        /// </summary>
        public List<ChartSectionControl> ChartSections
        {
            get
            {
                if (this.Driver != null && _chartSections == null)
                {
                    var items = WebElementKeeper.WaitingFor_GetElementsWhenExists(this.Driver, By.XPath(cst_ChartSections));

                    _chartSections = new List<ChartSectionControl>(10);
                    for (var i = 1; i <= items.Count; i++)
                    {
                        _chartSections.Add(new ChartSectionControl(this.Driver, string.Format("({0})[{1}]", cst_ChartSections, i)));
                    }
                }
                return _chartSections;
            }
        }
        #endregion Property for client

        #region Action for client
        #endregion Action for client
    }
}