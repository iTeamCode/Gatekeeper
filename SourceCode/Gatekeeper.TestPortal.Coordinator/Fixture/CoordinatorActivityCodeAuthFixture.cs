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
    public class CoordinatorActivityCodeAuthFixture : CoordinatorRegisterDeviceFixture
    {
    
        public CoordinatorActivityCodeAuthFixture ()
        {
            var driverManager = this.DriverManager;
            // with church code auth successfully, auth activity code on the activity page

            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(driverManager.Driver);

            // enter activity code (????? need to initiate the activity...) 
            activityCodePage.AuthenticateActivityCode("7814");

            Assert.True(driverManager.IsCurrentPage(PageAlias.Coordinator_ActivityInstance));

        }

    }
}
