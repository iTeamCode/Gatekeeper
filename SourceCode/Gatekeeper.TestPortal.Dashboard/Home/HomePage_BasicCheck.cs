using Gatekeeper.DomainModel.Dashboard;
using Gatekeeper.PageObject.Dashboard;
using Gatekeeper.TestPortal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class HomePage_BasicCheck : IClassFixture<DashboardAuthorizedUserFixture>
    {
        #region Init & check data
        private IDriverManager _driverManager;
        public HomePage_BasicCheck(DashboardAuthorizedUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //check data here;
        }
        #endregion

        [Fact]
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

            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
            chartSection.Expand = true;
            //chartSection.MetricItems[0].Selected = true;
            chartSection.MetricItems.ForEach(x => x.Selected = true);
            chartSection.MetricItems.ForEach(x => x.Selected = false);
            //homePage.ToolBar.Action_SelectStartDayOfWeek(DayOfWeek.Monday);
            //homePage.ToolBar.Action_SelectStartDayOfWeek(DayOfWeek.Sunday);
            //homePage.ToolBar.Action_SelectStartDayOfWeek(DayOfWeek.Tuesday);
        }

    }
}
