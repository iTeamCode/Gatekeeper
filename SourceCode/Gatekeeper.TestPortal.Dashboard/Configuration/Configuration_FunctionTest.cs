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
    public class Configuration_FunctionTest : IClassFixture<InitialConfigurationFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "Configuration.Function";

        private IDriverManager _driverManager;
        public Configuration_FunctionTest(InitialConfigurationFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //check data here;
        }
        #endregion

        [Theory(DisplayName = cst_DisplayName + ".DisableWidget")]
        [InlineData("Giving")]
        [InlineData("Attendance")]
        [InlineData(null)]
        public void DisableWidget(string disableWidgetName)
        {
            //#01. set & save configuration.
            _driverManager.NavigateTo(PageAlias.Dashboard_Configuration);
            var configurationPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(_driverManager.Driver);

            for (var i = 0; i < 3; i++)
            {
                configurationPage.ActiveWidgets[i].Enabled = true;                
            }

            if (string.IsNullOrEmpty(disableWidgetName))
            {
                //get attr here
                disableWidgetName = configurationPage.ActiveWidgets[2].Title;
                disableWidgetName = disableWidgetName.Substring(0, disableWidgetName.LastIndexOf("("));
            }

            var activeWidget = configurationPage.ActiveWidgets.Find(x => x.Title.StartsWith(disableWidgetName));
            Assert.True(activeWidget != null, string.Format("Can't find out widget which title starts with {0}", disableWidgetName));
            activeWidget.Enabled = false;

            configurationPage.Action_SaveConfiguratorAndClosePage();
            //#02. check result.
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);
            var result = homePage.ChartSections.Find(x => x.SummaryBar.Name == disableWidgetName);
            Assert.True(result == null, "Disable widget failed!");
        }

        [Theory(DisplayName = cst_DisplayName + ".DisableWidgetItems")]
        [InlineData("Giving")]
        [InlineData("Attendance")]
        //[InlineData(null)]
        public void DisableWidgetItems(string disableWidgetName)
        {
            //#01. set & save configuration.
            _driverManager.NavigateTo(PageAlias.Dashboard_Configuration);
            var configurationPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(_driverManager.Driver);

            if (string.IsNullOrEmpty(disableWidgetName))
            {
                //get attr here
                disableWidgetName = configurationPage.ActiveWidgets[2].Title;
                disableWidgetName = disableWidgetName.Substring(0, disableWidgetName.LastIndexOf("("));
            }

            var activeWidget = configurationPage.ActiveWidgets.Find(x => x.Title.StartsWith(disableWidgetName));
            Assert.True(activeWidget != null, string.Format("Can't find out widget which title starts with {0}", disableWidgetName));
            activeWidget.Enabled = true;
            activeWidget.Expand = true;

            var i = 0;
            var seeds = 0;
            if (activeWidget.Items.Count > 0 && activeWidget.Items[0].Selected) { seeds = 1; }
            var settingList = new List<WidgetItemModel>();
            activeWidget.Items.ForEach(x => {
                if (i < 10)
                {
                    x.Selected = (i % 2 == seeds);
                    i++;
                }
                else { x.Selected = false; }
                if (x.Selected) { settingList.Add(new WidgetItemModel() { Text = x.Text, Selected = x.Selected }); }
            });
            configurationPage.Action_SaveConfiguratorAndClosePage();

            //Get item in page.
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);
            var chartSection = homePage.ChartSections.FirstOrDefault(x => x.SummaryBar.Name == disableWidgetName);
            chartSection.Expand = true;

            var displayList = new List<WidgetItemModel>();
            chartSection.MetricItems.ForEach(x =>
            {
                displayList.Add(new WidgetItemModel() { Text = x.Text });
            });


            displayList.ForEach(x =>
            {
                var temp = settingList.FirstOrDefault(item => item.Text == x.Text);
                Assert.True(temp != null, string.Format("enable/disable widget items failed! item text:{0}", x.Text));
            });
        }
    }
}
