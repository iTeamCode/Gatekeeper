using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Membership.PageObject.AUI;
using Membership.TestPortal.AUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class MemberShipAuthorizedUserFixture : SingleBrowserFixture
    {
        public CurrentUserModel CurrentUser { get; protected set; }
        public MemberShipAuthorizedUserFixture()
            : base()
        {
            //build current user.
            CurrentUserModel user = new CurrentUserModel
            {
                UserName = "demi.zhang_test123@active111.com",
                Password = "start123"
            };
            //Create manager & Navigate page to Login.
            var manager = this.DriverManager ?? GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.AUI_SignIn, false);
            
            var signInPage = GatekeeperFactory.CreatePageManager<MembershipSignInPage>(manager.Driver);
            signInPage.Action_SignIn(user.UserName, user.Password);

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.AUI_Organization_Home));

            this.CurrentUser = user;
        }
    }
}
