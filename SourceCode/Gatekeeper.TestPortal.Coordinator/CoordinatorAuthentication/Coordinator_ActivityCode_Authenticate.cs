using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Coordinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Coordinator
{

    public class Coordinator_ActivityCode_Authenticate : IClassFixture<CoordinatorRegisterDeviceFixture>
    {
        private IDriverManager _driverManager;
        public Coordinator_ActivityCode_Authenticate(CoordinatorRegisterDeviceFixture Fixture)
        {
            _driverManager = Fixture.DriverManager;
        }
        [Fact]
        public void Coordinator_ActivityCodeAuth_Success() 
        {
            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(_driverManager.Driver);
            activityCodePage.AuthenticateActivityCode("7814");

            Assert.True(_driverManager.IsCurrentPage(PageAlias.Coordinator_ActivityInstances));

            var activityInstancePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityInstancePage>(_driverManager.Driver);
            Assert.Equal("Dynamic Church", activityInstancePage.Header.ChurchName);
            Assert.Equal("Activity - CC1", activityInstancePage.Header.ActivityName);
                       

        }
    }
}
