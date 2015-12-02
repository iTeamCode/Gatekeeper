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
        private IDriverManager _manager;
        public Coordinator_ActivityCode_Authenticate(CoordinatorRegisterDeviceFixture Fixture)
        {
            _manager = Fixture.DriverManager;
        }
        [Fact]
        public void Coordinator_ActivityCodeAuth_Success() 
        {
            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(_manager.Driver);
            activityCodePage.AuthenticateActivityCode("7814");

            Assert.True(_manager.IsCurrentPage(PageAlias.Coordinator_ActivityInstance));

        }
    }
}
