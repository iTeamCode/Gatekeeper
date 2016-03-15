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
    public class RegisterDevice_Fail_Test : IClassFixture<SingleBrowserFixture>
    {
        private IDriverManager _driverManager { get; set; }

        public RegisterDevice_Fail_Test(SingleBrowserFixture fixture)
        {
            _driverManager = fixture.DriverManager;
        }

        [Theory]
        // with no values entered
        [InlineData("", "", "", "User credentials are invalid.")]
        // Church Code is invalid
        [InlineData("ft.tester", "FT4life!", "dcc", "Your login attempt has failed. Church is not found.")]
        // username is incorrect
        [InlineData("ft.testertest1", "FT4life!", "dc", "Your login attempt has failed.")]
        // Password is incorrect
        [InlineData("ft.tester", "12312312", "dc", "Your login attempt has failed.")]
        // AUI account is not belong to the Church
        [InlineData("v2test", "Zhyl@382030", "dc", "Your login attempt has failed.")]
        // AUI account is inactive
        [InlineData("dzhang", "Zhyl@382030", "dc", "Your account is currently not active.")]
        // The Coordinator feature is not enabled for the church
        [InlineData("ft.tester", "FT4life!", "QAEUNLX0C2", "Login attempt failed. Please contact your administrator.")]
        // The church level cannot access to the feature (i.e. Coordinator is Preview feature, but the church is not Preview nor Development church)
        [InlineData("v2test", "Zhyl@382030", "QAEUNLX0V2", "Login attempt failed. Please contact your administrator.")]      

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
