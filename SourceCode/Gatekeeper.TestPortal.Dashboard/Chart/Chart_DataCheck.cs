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
    public class Chart_DataCheck : IClassFixture<InitialConfigurationFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "Chart.DataCheck";

        private IDriverManager _driverManager;
        public Chart_DataCheck(InitialConfigurationFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //check data here;
        }
        #endregion

        [Fact(DisplayName = cst_DisplayName + ".TopBar")]
        public void VerifiedTopBarData()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Home);
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);
            var toolBar = homePage.ToolBar;
            toolBar.Action_SelectView(ChartView.Year);

            homePage.ChartSections.ForEach(x => x.Expand = false);
            var chartSection = homePage.ChartSections.Find(x => x.SummaryBar.Name.Contains("Giving"));
            chartSection.Expand = true;
            var chartView_YearData = chartSection.ChartView.GetEndData();
            var chartView_LastYearData = chartSection.ChartView.GetEndData(1);
            var chartView_BeforeLastYearData = chartSection.ChartView.GetEndData(2);

            var currentYear = DateTime.Now.Year;
            Assert.Equal("Today " + currentYear, chartSection.DetailBar.MainAreaTitle);
            Assert.Equal(chartView_YearData, chartSection.DetailBar.MainAreaValue);

            Assert.Equal((currentYear - 1).ToString(), chartSection.DetailBar.LastYearAreaTitle);
            Assert.Equal(chartView_LastYearData, chartSection.DetailBar.LastYearAreaValue);

            Assert.Equal((currentYear - 2).ToString(), chartSection.DetailBar.BeforeLastYearAreaTitle);
            Assert.Equal(chartView_BeforeLastYearData, chartSection.DetailBar.BeforeLastYearAreaValue);

            //homePage.ChartSections.Concat
        }
    }
}
