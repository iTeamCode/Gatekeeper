using Gatekeeper.PageObject.Dashboard;
using Gatekeeper.TestPortal.Common;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class Dashboard_SignIn_Success_Test
    {
        [Fact]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Dashboard_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<DashboardSignInPage>(manager.Driver);
            signInPage.SignIn("tcoulson", "FT.Admin1", "dc");

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Dashboard_Home));
        }
    }

    public class Dashboard_SignIn_Error_Test : IClassFixture<SingleBrowserFixture>
    {
        private IDriverManager _driverManager { get; set; }
        private readonly ITestOutputHelper _output;
        public Dashboard_SignIn_Error_Test(ITestOutputHelper output, SingleBrowserFixture fixture)
        {
            _driverManager = fixture.DriverManager;
            _output = output;
        }

        [Theory]
        [InlineData("", "", "", "Username is required.")]
        [InlineData("tcoulson", "", "", "Password is required.")]
        [InlineData("tcoulson", "FT.Admin", "", "Church code is required.")]
        public void SignIn_Error(string userName, string pwd, string churchCode, string errorMsg)
        {
            //Create manager & Navigate page to Login.
            _driverManager.NavigateTo(PageAlias.Dashboard_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<DashboardSignInPage>(_driverManager.Driver);
            signInPage.SignIn(userName, pwd, churchCode);

            //Waiting & Check page.
            var isPass = signInPage.CheckErrorMessage(errorMsg);
            _output.WriteLine("[Info]:Error message '{0}'", signInPage.ErrorMsg);
            Assert.True(isPass, string.Format("error message is not '{0}'", errorMsg));
        }
    }
}
