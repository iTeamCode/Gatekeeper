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
    public class ConfigurationPage_BasicCheck : IClassFixture<DashboardAuthorizedUserFixture>
    {
        #region Init & check data
        private IDriverManager _driverManager;
        public ConfigurationPage_BasicCheck(DashboardAuthorizedUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //check data here;
        }
        #endregion

        [Fact]
        public void Check_TitleText()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Configuration);
            var configurationPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(_driverManager.Driver);

            //Check title text.
            Assert.Equal("Active Widgets", configurationPage.TitleText);
        }

        [Fact]
        public void Check_MaxWidgetCount()
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Configuration);
            var configurationPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(_driverManager.Driver);

            //Check max widget count.
            var enabledWidgets = configurationPage.ActiveWidgets.FindAll(x => x.Enabled);
            Assert.True(enabledWidgets.Count <= 6);

            configurationPage.Action_EnabledAllActiveWidgets();
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
    }
}
