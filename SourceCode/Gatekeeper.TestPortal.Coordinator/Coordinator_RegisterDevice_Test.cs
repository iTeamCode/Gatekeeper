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


       
        public class Coordinator_RegisterDevice_Error_Test: IClassFixture<SingleBrowserFixture>
        {
            private IDriverManager _driverManager { get; set; }

            public Coordinator_RegisterDevice_Error_Test (SingleBrowserFixture fixture)
            {
                _driverManager = fixture.DriverManager;
            }

            [Theory]
            [InlineData("", "", "", "user credentials are invalid.")]
            [InlineData("ft.tester", "", "", "user credentials are invalid.")]
            [InlineData("ft.tester", "FT4life!", "dcc", "Your login attempt has failed. Church is not found.")]
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

}
