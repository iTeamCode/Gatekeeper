using Gatekeeper.PageObject.Launchpad;
using Gatekeeper.TestPortal.Common;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Gatekeeper.TestPortal.Launchpad
{
    public class Launchpad_SignIn_Success_Test
    {
        [Fact]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.LaunchPad_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<SignInPage>(manager.Driver);
            signInPage.Action_SignIn("winnie.wang@activenetwork.com", "FT4life!");

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Dashboard_Home));
            manager.Driver.Close();
        }
    }
}
