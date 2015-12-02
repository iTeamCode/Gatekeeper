using Gatekeeper.PageObject.Dashboard;
using Gatekeeper.TestPortal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class ConfigurationPage_BasicCheck : IClassFixture<DashboardAuthorizedUserFixture>
    {
        private const string cst_DisplayName = "BaseCheck.Configuration";
        #region Init & check data
        private IDriverManager _driverManager;
        public ConfigurationPage_BasicCheck(DashboardAuthorizedUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //check data here;
        }
        #endregion

        /// <summary>
        /// Check title Text is 'Active Widgets'
        /// </summary>
        [Fact(DisplayName = cst_DisplayName + ".CheckTitleText")]
        public void Check_TitleText()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Configuration);
            var configurationPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(_driverManager.Driver);

            //Check title text.
            Assert.Equal("Active Widgets", configurationPage.TitleText);
        }

        /// <summary>
        /// Check max selected widget count letter than 6 
        /// </summary>
        [Fact(DisplayName = cst_DisplayName + ".CheckMaxWidgetCount")]
        public void Check_MaxWidgetCount()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Configuration);
            var configurationPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(_driverManager.Driver);

            //Check max widget count.
            var enabledWidgets = configurationPage.ActiveWidgets.FindAll(x => x.Enabled);
            Assert.True(enabledWidgets.Count <= 6);

            configurationPage.Action_UnableAllActiveWidgets();
            enabledWidgets = configurationPage.ActiveWidgets.FindAll(x => x.Enabled);
            Assert.Equal(0, enabledWidgets.Count);

            for (int i = 0; i < 7; i++)
            {
                var widget = configurationPage.ActiveWidgets[i];
                widget.Enabled = true;
                widget.Expand = false;
            }

            Assert.True(configurationPage.Check_ModalDialog());
            configurationPage.Action_CloseModalDialog();
        }
        /// <summary>
        /// selected count of widget item panel is match to title bar display.
        /// </summary>
        [Fact(DisplayName = cst_DisplayName + ".CheckWidgetItemSelectCount", Skip = "Check After")]
        public void Check_WidgetItemSelectCount()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Configuration);
            var configurationPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(_driverManager.Driver);

            configurationPage.Action_UnableAllActiveWidgets(); //clear 
            //var widget = configurationPage.ActiveWidgets.FirstOrDefault();
            var activeWidgets = configurationPage.ActiveWidgets;
            for (var i = 0; i < activeWidgets.Count && i < 6; i++)
            {
                var widget = activeWidgets[i];
                widget.Enabled = true;
                //widget.WaitingForDomElementShow();
                var selectedWidgetItems = widget.Items.FindAll(x => x.Selected);
                var matche = Regex.Match(widget.Title, @"\(\d+\)");
                matche = Regex.Match(matche.Value, @"\d+");

                Assert.Equal(int.Parse(matche.Value), selectedWidgetItems.Count);
                widget.Enabled = false;
            }
        }
    }
}
