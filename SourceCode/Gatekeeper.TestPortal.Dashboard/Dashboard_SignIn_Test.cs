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

    public class Dashboard_SignIn_Error_Test //: IClassFixture<SingleBrowserFixture>
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
}
