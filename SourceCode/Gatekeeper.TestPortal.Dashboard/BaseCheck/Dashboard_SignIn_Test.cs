using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Dashboard;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class Dashboard_SignIn_Success_Test
    {
        private const string cst_DisplayName = "BaseCheck.SignIn";
        [Fact(DisplayName = cst_DisplayName + ".Success")]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Dashboard_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<SignInPage>(manager.Driver);
            signInPage.Action_SignIn("ft.tester", "FT4life!", "dc");

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Dashboard_Home));
            manager.Driver.Close();
        }
    }

    public class Dashboard_SignIn_Error_Test : IClassFixture<SingleBrowserFixture>
    {
        private const string cst_DisplayName = "BaseCheck.SignIn";
        private IDriverManager _driverManager { get; set; }
        private readonly ITestOutputHelper _output;
        public Dashboard_SignIn_Error_Test(ITestOutputHelper output, SingleBrowserFixture fixture)
        {
            _driverManager = fixture.DriverManager;
            _output = output;
        }

        [Theory(DisplayName = cst_DisplayName + ".Error")]
        [InlineData("", "", "", "Username is required.")]
        [InlineData("ft.tester", "", "", "Password is required.")]
        [InlineData("ft.tester", "FT4life!", "", "Church code is required.")]
        public void SignIn_Error(string userName, string pwd, string churchCode, string errorMsg)
        {
            //Create manager & Navigate page to Login.
            _driverManager.NavigateTo(PageAlias.Dashboard_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<SignInPage>(_driverManager.Driver);
            signInPage.Action_SignIn(userName, pwd, churchCode);

            //Waiting & Check page.
            var isPass = signInPage.Check_ErrorMessage(errorMsg);
            _output.WriteLine("[Info]:Error message '{0}'", signInPage.ErrorMsg);
            Assert.True(isPass, string.Format("error message is not '{0}'", errorMsg));
        }
    }
}
