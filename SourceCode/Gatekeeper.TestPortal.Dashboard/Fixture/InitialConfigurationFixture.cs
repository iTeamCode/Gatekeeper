using Gatekeeper.DomainModel.Common;
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
    public class InitialConfigurationFixture : DashboardAuthorizedUserFixture
    {
        public InitialConfigurationFixture()
            : base()
        {
            //sign in dashboard
            //Create manager & Navigate page to Login.
            var manager = this.DriverManager ?? GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Dashboard_Configuration);

            var configPage = GatekeeperFactory.CreatePageManager<ConfigurationPage>(manager.Driver);
            configPage.Action_UnableAllActiveWidgets();

            Assert.True(configPage.ActiveWidgets.Count >= 3, "ActiveWidgets is list than 3!");

            for (var i = 0; i < 3; i++)
            {
                var widget = configPage.ActiveWidgets[i];
                widget.Enabled = true;
            }
            configPage.Action_SaveConfiguratorAndClosePage();
            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Dashboard_Home));
        }
    }
}
