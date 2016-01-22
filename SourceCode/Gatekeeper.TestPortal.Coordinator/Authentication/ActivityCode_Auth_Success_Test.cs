using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Coordinator;
using Gatekeeper.Toolbox.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Coordinator
{

    public class ActivityCode_Auth_Success_Test : IClassFixture<CoordinatorRegisterDeviceFixture>
    {
        private IDriverManager _driverManager;
        public ActivityCode_Auth_Success_Test(CoordinatorRegisterDeviceFixture Fixture)
        {
            _driverManager = Fixture.DriverManager;
        }
        [Fact]
        public void ActivityCode_Auth_Success() 
        {
            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(_driverManager.Driver);
            activityCodePage.AuthenticateActivityCode("7814");

            Assert.True(_driverManager.IsCurrentPage(PageAlias.Coordinator_ActivityInstances));
            var dv = DataVisitor.Create<ICommonDataVisitor>();
            var church = dv.FetchChurchInfomation(15);
 
            var activityInstancePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityInstancePage>(_driverManager.Driver);
            Assert.Equal(church.ChurchName, activityInstancePage.Header.ChurchName);
            Assert.Equal("Activity - CC1", activityInstancePage.Header.ActivityName);
                       

        }
    }
}
