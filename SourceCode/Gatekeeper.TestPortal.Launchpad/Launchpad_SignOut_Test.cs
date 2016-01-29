using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Launchpad;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Launchpad
{




    public class Launchpad_SignOut_Test : IClassFixture<LaunchpadHighestAuthorityUserFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "SignOut";

        private IDriverManager _driverManager;
        public Launchpad_SignOut_Test(LaunchpadHighestAuthorityUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
        }

        
        #endregion



        [Theory(DisplayName = cst_DisplayName)]
        [InlineData("Sign Out from Homepage")]
        public void LaunchpadSignOut(string action)
        {
            _driverManager.NavigateTo(PageAlias.Launchpad_Home);
            var launchpadHomepage = GatekeeperFactory.CreatePageManager<Homepage>(_driverManager.Driver);
            var manager = GatekeeperFactory.CreateDriverManager();
            
            launchpadHomepage.SignOut();
            System.Threading.Thread.Sleep(5000);

            //Assert.Contains("Sign In", "sign out failed!");
            

                Assert.True(manager.IsCurrentPage(PageAlias.Launchpad_SignIn));
                       
            //verify url is correct

            //var isExpected = passwordSettingsPage.IsErrorMsgExpected(msg);
            //Assert.True(isExpected, "Message is incorrect");
        }
    }
}
