using Gatekeeper.PageObject.Coordinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Gatekeeper.Framework.Common;
using Gatekeeper.DomainModel.Common;

namespace Gatekeeper.TestPortal.Coordinator
{
    public class Coordinator_ActivityInstances_Check:IClassFixture<CoordinatorActivityCodeAuthFixture>
    {
        private IDriverManager _driverManager;
        public Coordinator_ActivityInstances_Check(CoordinatorActivityCodeAuthFixture Fixture)
        {
            _driverManager = Fixture.DriverManager;
        }


        [Fact]
        public void Check_ActivityInstancesAreUnselectedByDefault()
        {
            // Question (???)
            _driverManager.NavigateTo(PageAlias.Coordinator_ActivityCode);
            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(_driverManager.Driver);
            activityCodePage.AuthenticateActivityCode("7814");

            var activityInstancesPage = GatekeeperFactory.CreatePageManager<CoordinatorActivityInstancePage>(_driverManager.Driver);
            Assert.True(activityInstancesPage.Check_AreAllInstancesUnselected(), "all the activity instances should be unselected by default but actully not");

            activityInstancesPage.StartWithoutInstancesSelected();
            Assert.True(_driverManager.IsCurrentPage(PageAlias.Coordinator_ActivityCode));
        }

        [Fact]
        public void Check_TestPage()
        {
            // Question (???)
            _driverManager.NavigateTo(PageAlias.Coordinator_ActivityCode);
            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(_driverManager.Driver);
            activityCodePage.AuthenticateActivityCode("7814");


            var activityInstancesPage = GatekeeperFactory.CreatePageManager<CoordinatorActivityInstancePage>(_driverManager.Driver);

            var isExists = activityInstancesPage.ActivityInstances.Exists(x => x.Radio == true);
            var i = activityInstancesPage.ActivityInstances.Find(x => x.Name == "");    

            Assert.False(isExists, "all the activity instances should be unselected by default but actully not");

            activityInstancesPage.StartWithoutInstancesSelected();
            Assert.True(_driverManager.IsCurrentPage(PageAlias.Coordinator_ActivityCode));
        }

        //[Fact]
        //public void Check_StartIsNotAvailableWithoutInstancesSelected()
        //{
        //    _driverManager.NavigateTo(PageAlias.Coordinator_ActivityInstances);
        //     var activityInstancesPage = GatekeeperFactory.CreatePageManager<CoordinatorActivityInstancePage>(_driverManager.Driver);

        //    //with Activity Instance page loaded, click Start button directly - next page cannot be loaded
         
        //}

        [Fact]
        public void Check_StartIsAvailableWithInstanceSelected()
        {
            // navigate to Activity Instances page
            _driverManager.NavigateTo(PageAlias.Coordinator_ActivityInstances);

            var activityInstancesPage = GatekeeperFactory.CreatePageManager<CoordinatorActivityInstancePage>(_driverManager.Driver);

            // click on the first activity instance and click Start button.
            activityInstancesPage.StartWithInstanceSelected(0);
            // check - with start button is clicked, the next page - Roster List page will be loaded
            Assert.True(_driverManager.IsCurrentPage(PageAlias.Coordinator_MovePage));

        }



 
    }
}
