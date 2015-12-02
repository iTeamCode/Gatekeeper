using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class DashboardAuthorizedUserFixture : SingleBrowserFixture
    {
        public DashboardAuthorizedUserFixture()
            : base()
        {
            //sign in dashboard
            //Create manager & Navigate page to Login.
            var manager = this.DriverManager ?? GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Dashboard_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<SignInPage>(manager.Driver);
            signInPage.Action_SignIn("ft.tester", "FT4life!", "dc");

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Dashboard_Home));
        }
    }
}
