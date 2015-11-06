using Gatekeeper.PageObject.Dashboard;
using Gatekeeper.TestPortal.Common;
using System;
using System.Linq;
using Xunit;

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
            WebElementKeeper.WaitingFor_UrlToBe(manager.Driver, PageAlias.Dashboard_Home);
            Assert.True(manager.CurrentPage == PageAlias.Dashboard_Home);
        }
    }

    //public class Dashboard_SignIn_Error_Test : IClassFixture<SingleBrowserFixture>
    public class Dashboard_SignIn_Error_Test : IClassFixture<TestXXXFixture>
    {
        public static IDriverManager DriverManager { get; set; }
        //[Fact]
        [Theory]
        [InlineData("", "", "", "Username is required.")]
        [InlineData("tcoulson", "", "", "Password is required.")]
        [InlineData("tcoulson", "FT.Admin", "", "Church code is required.")]
        public void SignIn_Error(string userName, string pwd, string churchCode, string errorMsg)
        {
            //Create manager & Navigate page to Login.
            //var manager = GatekeeperFactory.CreateDriverManager();

            var manager = Dashboard_SignIn_Error_Test.DriverManager;
            manager.NavigateTo(PageAlias.Dashboard_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<DashboardSignInPage>(manager.Driver);
            signInPage.SignIn(userName, pwd, churchCode);

            Assert.True(signInPage.IsShowErrorMsgBox);
            Assert.Equal(signInPage.ErrorMsg, errorMsg);
        }
    }

    public class TestXXXFixture : IDisposable
    {
        public TestXXXFixture()
        {
            //Create
            Dashboard_SignIn_Error_Test.DriverManager = GatekeeperFactory.CreateDriverManager();
        }
        public void Dispose()
        {
            //Romove
            Dashboard_SignIn_Error_Test.DriverManager.Driver.Close();
        }
    }
}
