using Gatekeeper.TestPortal.Common;
using Gatekeeper.PageObject.Coordinator;
using System;
using System.Linq;
using Xunit;

namespace Gatekeeper.TestPortal.Coordinator
{
    public class Coordinator_RegisterDevice_Test
    {
        [Fact]
        public void RegisterDevice_Success()
        {
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Coordinator_RegisterDevice);

            var registerDevicePage = GatekeeperFactory.CreatePageManager<CoordinatorRegisterDevicePage>(manager.Driver);
            registerDevicePage.AuthenticateChurch("ft.tester", "FT4life!", "dc");

            Assert.True(manager.IsCurrentPage(PageAlias.Coordinator_ActivityCode));

            manager.NavigateTo(PageAlias.Coordinator_RegisterDevice, false);
            Assert.True(manager.IsCurrentPage(PageAlias.Coordinator_ActivityCode));
        }

        
    }

}
