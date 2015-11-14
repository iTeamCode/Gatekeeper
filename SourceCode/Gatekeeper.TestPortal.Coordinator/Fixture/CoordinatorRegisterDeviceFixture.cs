using Gatekeeper.PageObject.Coordinator;
using Gatekeeper.TestPortal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Coordinator
{
    public class CoordinatorRegisterDeviceFixture : SingleBrowserFixture
    {
        public CoordinatorRegisterDeviceFixture()
            : base()
        {

            //Navigate to Register Device page to login             
            var manager = this.DriverManager;
            manager.NavigateTo(PageAlias.Coordinator_RegisterDevice);
           
            var registerDevicePage = GatekeeperFactory.CreatePageManager<CoordinatorRegisterDevicePage>(manager.Driver);
            registerDevicePage.AuthenticateChurch("ft.tester", "FT4life!", "dc");
            
            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Coordinator_ActivityCode));
         
        }
    }
}
