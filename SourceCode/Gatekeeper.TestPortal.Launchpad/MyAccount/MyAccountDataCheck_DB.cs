using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Launchpad;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Launchpad;
using Gatekeeper.Toolbox.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Launchpad
{
    public partial class MyAccountDataCheck :IClassFixture<InitialAccountFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "Profile.DataCheck.DB";

        private IDriverManager _driverManager;
        public MyAccountDataCheck(InitialAccountFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            _driverManager.NavigateTo(PageAlias.Launchpad_Profile);                
        }
        #endregion 
        
        #region Test-Case   
        [Theory(DisplayName = cst_DisplayName + ".BasicInfo")]
        [InlineData(15, "winnie.wang@activenetwork.com", "BasicInfo")]
        public void VerifyBasicIndividualInfo(int churchId, string loginEmail, string infoType)
        {
            //#01. Inite data.            
            string firstname = "winnie";
            string lastname = "wang";
            string street1 = "Yungu Road";
            string city = "Xian";
            string zipcode;
            string random = Guid.NewGuid().ToString().Substring(0, 5);

            firstname = firstname + random;
            lastname = lastname + random;
            street1 = street1 + random;
            city = city + random;
            zipcode = random;

            var user = new UserProfileModel() { FirstName = firstname, LastName = lastname, Street1 = street1, City = city, Zipcode = zipcode };

            var profileSettingsPage = GatekeeperFactory.CreatePageManager<ProfilePage>(_driverManager.Driver);
            profileSettingsPage.SetBaseProfile(firstname, lastname, street1, city, zipcode);
            
            //#02. Get data from DB.
            var data = GetUserData(churchId, loginEmail, infoType);

            //#03. Compare data.
            Assert.True(data == user);
        }

        private UserProfileModel GetUserData(int churchId, string loginEmail, string infoType)
        {
            var dvLaunchpad = DataVisitor.Create<ILaunchpadDataVisitor>();
            var userData = dvLaunchpad.FetchBasicProfileData(churchId, loginEmail, infoType);
            return userData;
        }

        #endregion Test-Case
    }    
}
