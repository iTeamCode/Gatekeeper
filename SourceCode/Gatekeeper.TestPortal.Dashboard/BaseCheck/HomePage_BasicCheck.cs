using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Dashboard;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Dashboard
{
    [Trait("Dashboard", "HomePageBasicCheck")]
    public class HomePage_BasicCheck : IClassFixture<DashboardAuthorizedUserFixture>
    {
        
        #region Init & check data
        private const string cst_DisplayName = "BaseCheck.SignIn";
        private IDriverManager _driverManager;
        public HomePage_BasicCheck(DashboardAuthorizedUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //check data here;
        }
        #endregion

        [Fact(DisplayName = cst_DisplayName + ".DemoTest00", Skip = "Test Demo")]
        public void DemoTest()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Home);
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);

            homePage.ToolBar.Action_SelectView(ChartView.Year);

            var chartSection = homePage.ChartSections.FirstOrDefault();
            //summary
            var summaryBar = chartSection.SummaryBar;
            var name = summaryBar.Name;
            var value = summaryBar.Value;
            var compareWithLast = summaryBar.CompareWithLast;

            chartSection.Expand = true;
            var detailBar = chartSection.DetailBar;
            var detailBar_Name = detailBar.Name;
            var mainAreaTitle = detailBar.MainAreaTitle;
            var mainAreaValue = detailBar.MainAreaValue;
            var lastYearAreaTitle = detailBar.LastYearAreaTitle;
            var lastYearAreaValue = detailBar.LastYearAreaValue;
            var beforeLastYearAreaTitle= detailBar.BeforeLastYearAreaTitle;
            var beforeLastYearAreaValue = detailBar.BeforeLastYearAreaValue;

            homePage.ToolBar.Action_SelectView(ChartView.Month);
            chartSection.Expand = false;
            summaryBar = chartSection.SummaryBar;
            name = summaryBar.Name;
            value = summaryBar.Value;
            compareWithLast = summaryBar.CompareWithLast;

            chartSection.Expand = true;
            //chartSection.MetricItems[0].Selected = true;
            //chartSection.MetricItems.ForEach(x => x.Selected = true);
            //chartSection.MetricItems.ForEach(x => x.Selected = false);
            //homePage.ToolBar.Action_SelectStartDayOfWeek(DayOfWeek.Monday);
            //homePage.ToolBar.Action_SelectStartDayOfWeek(DayOfWeek.Sunday);
            //homePage.ToolBar.Action_SelectStartDayOfWeek(DayOfWeek.Tuesday);
        }

        [Fact(DisplayName = cst_DisplayName + ".DemoTest01", Skip = "Test Demo")]
        public void DemoTest01()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Home);
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);

            homePage.ToolBar.Action_SelectView(ChartView.Year);
            var chartSection = homePage.ChartSections.FirstOrDefault();
            chartSection.Expand = true;
            
            var data_2013 = chartSection.ChartView["2013"];

            homePage.ToolBar.Action_SelectView(ChartView.Quarter);            
            var data_2015_Q1 = chartSection.ChartView["Q1","2015"];

            homePage.ToolBar.Action_SelectView(ChartView.Month);
            var data_2015_Month10 = chartSection.ChartView["Sep", "2015"];

            homePage.ToolBar.Action_SelectView(ChartView.Week);
            var data_2015_Week3 = chartSection.ChartView["36", "2015"];
        }

    }
}
