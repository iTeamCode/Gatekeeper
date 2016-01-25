using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Launchpad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Launchpad
{
    public class LaunchpadHighestAuthorityUserFixture : SingleBrowserFixture
    {
        public CurrentUserModel CurrentUser { get; protected set; }
        public LaunchpadHighestAuthorityUserFixture()
            : base()
        { 
            //Sign in Launchpad
            //Create manager & Navigate page to login.
            var manager = this.DriverManager ?? GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Launchpad_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<LaunchpadSignInPage>(manager.Driver);
            signInPage.Action_SignIn("winnie.wang@activenetwork.com", "111111");

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Launchpad_Home));

            this.CurrentUser = new CurrentUserModel
            {
                UserName = "wwang",
                Password = "@Ctive111",
                //ChurchCode = "dc",
                //ChurchId = 15
            };
        
        }

    }
}

