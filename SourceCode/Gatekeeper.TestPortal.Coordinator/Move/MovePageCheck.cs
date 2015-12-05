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
    public class MovePage_BasicCheck
    {
        public class RosterInfo_Check : IClassFixture<CoordinatorActivityCodeAuthFixture>
        {
            private IDriverManager _driverManager;

            public RosterInfo_Check (CoordinatorActivityCodeAuthFixture Fixture)
            {
                _driverManager = Fixture.DriverManager;
            }

            [Fact]
            public void MovePage_RosterInfo_Check ()
            {
                _driverManager.NavigateTo(PageAlias.Coordinator_ActivityInstances);

                var activityInstancesPage = GatekeeperFactory.CreatePageManager<CoordinatorActivityInstancePage>(_driverManager.Driver);
                activityInstancesPage.StartWithInstanceSelected(0);

                Assert.True(_driverManager.IsCurrentPage(PageAlias.Coordinator_MovePage));

                var moveHomePage = GatekeeperFactory.CreatePageManager<MoveHomePage>(_driverManager.Driver);

                var roster1 = moveHomePage.RosterPanel.Rosters[0];
                Assert.Equal(roster1.Name, "Roster - CC1");
                Assert.Equal(roster1.Time, "12:00 AM");

                roster1.Select();
                var rosterDetail = moveHomePage.RosterDetails;
                Assert.Equal("Roster - CC1 Roster Grouping 12:00 AM", rosterDetail.Title);
                

            }
        }
    }
}
