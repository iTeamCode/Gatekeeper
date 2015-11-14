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
    public class Coordinator_RegisterDevice_Error_Test : IClassFixture<SingleBrowserFixture>
    {
        private IDriverManager _driverManager { get; set; }

        public Coordinator_RegisterDevice_Error_Test(SingleBrowserFixture fixture)
        {
            _driverManager = fixture.DriverManager;
        }

        [Theory]
        // with no values entered
        [InlineData("", "", "", "user credentials are invalid.")]
        // Password is incorrect
        [InlineData("ft.tester", "12312312", "dc", "Your login attempt has failed.")]
        // Church Code is invalid
        [InlineData("ft.tester", "FT4life!", "dcc", "Your login attempt has failed. Church is not found.")]
        // The Coordinator feature is not enabled for the church
        [InlineData("ft.tester", "FT4life!", "QAEUNLX0V2", "Login attempt failed. Please contact your administrator.")]
        // AUI account is inactive
        //[InlineData("test", "Test!123", "dc", "Your account is currently not active.")]

        public void RegisterDevice_Error(string userName, string password, string churchCode, string expectedErrorMsg)
        {
            _driverManager.NavigateTo(PageAlias.Coordinator_RegisterDevice);
            var registerDevicePage = GatekeeperFactory.CreatePageManager<CoordinatorRegisterDevicePage>(_driverManager.Driver);

            registerDevicePage.AuthenticateChurch(userName, password, churchCode);

            var isPass = registerDevicePage.IsErrorMsgExpected(expectedErrorMsg);
            Assert.True(isPass, "error message is not expected");
        }

    }
}
