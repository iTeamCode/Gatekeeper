using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Gatekeeper.TestPortal.Common;
using Gatekeeper.PageObject.Coordinator;


namespace Gatekeeper.TestPortal.Coordinator
{
    public class Coordinator_ActivityCode_Auth_Error_Test : IClassFixture<CoordinatorRegisterDeviceFixture>
    {
        private IDriverManager _driverManager;

        public Coordinator_ActivityCode_Auth_Error_Test (CoordinatorRegisterDeviceFixture Fixture)
        {
            _driverManager = Fixture.DriverManager;
        }

        [Theory]
        // invalid activity code - not digits
        [InlineData("abcd")]
        // invalid activity code (how to ensure the activity code is invalid????)
        [InlineData("1234")]
        // valid activity code but the related activity is inactive (how to ensure the activity is inactive????)
        [InlineData("2345")]
        // valid activity code but the related activity does not meet today
        [InlineData("3456")]
        // valid activity code but the Check-in App is disable for the activity (how to ensure disable????)
        [InlineData("4567")]
       
        public void ActivityCode_Auth_Error (string activityCode)
        {
            var activityCodePage = GatekeeperFactory.CreatePageManager<CoordinatorActivityCodePage>(_driverManager.Driver);
            activityCodePage.AuthenticateActivityCode(activityCode);

            var isExpected = activityCodePage.IsErrorMsgExpected("Either**** this Activity doesn't meet today or the activity code is invalid.");
            Assert.True(isExpected, "error message is wrong");

        }
    }
}
