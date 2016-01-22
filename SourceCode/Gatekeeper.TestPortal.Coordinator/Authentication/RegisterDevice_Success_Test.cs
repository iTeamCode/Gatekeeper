using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Coordinator;
using System;
using System.Linq;
using Xunit;
//using Gatekeeper.TestPortal.Dashboard;

namespace Gatekeeper.TestPortal.Coordinator
{
    public class Coordinator_RegisterDevice_Success_Test
    {
        [Fact]
        public void RegisterDevice_Success_Test()
        {
            // Create driver manager and navigate to Register Device page
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Coordinator_RegisterDevice);
            
            // Sign in with valid username/password/dc
            var registerDevicePage = GatekeeperFactory.CreatePageManager<CoordinatorRegisterDevicePage>(manager.Driver);
            registerDevicePage.AuthenticateChurch("ft.tester", "FT4life!", "dc");

            // Waiting & Check: the next page - Activity Code page is loaded
            Assert.True(manager.IsCurrentPage(PageAlias.Coordinator_ActivityCode));

            // Check the church name is showing on Activity Code page (in the header)
            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(manager.Driver);
            Assert.Equal("Dynamic Church", activityCodePage.HeaderChurchName);
            
            //Once register successfully, the sign in page won't come up the next time
            manager.NavigateTo(PageAlias.Coordinator_RegisterDevice, false);
            Assert.True(manager.IsCurrentPage(PageAlias.Coordinator_ActivityCode));

            
            manager.Driver.Close();
        }

    }
}
