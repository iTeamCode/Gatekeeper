using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Launchpad;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Launchpad;
//using Gatekeeper.Toolbox.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Launchpad
{
    public class Profile : IClassFixture<LaunchpadHighestAuthorityUserFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "MyAccount.Profile";

        private IDriverManager _driverManager;
        public Profile(LaunchpadHighestAuthorityUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            _driverManager.NavigateTo(PageAlias.Launchpad_Profile);
            //System.Threading.Thread.Sleep(5000);
        }
        #endregion

        [Theory(DisplayName = cst_DisplayName + ".VerificationTest")]
        [InlineData("", "", "", "", "", "", "First name is required.")]
        [InlineData("Winnie", "", "", "", "", "", "Last name is required.")]
        [InlineData("Winnie", "Wang", "", "", "", "", "Street1 for Address is required.")]
        [InlineData("Winnie", "Wang", "YunGu Road", "", "", "", "First name is required.")]
        [InlineData("Winnie", "Wang", "YunGu Road", "", "", "City is required.")]
        [InlineData("Winnie", "Wang", "YunGu Road", "Xian", "", "Zipcode is required.")]
        public void ProfileBasicInfoVerify(string firstName, string lastName, string street1, string city, string zipcode, string msg)
        {
            //_driverManager.NavigateTo(PageAlias.Launchpad_Profile);         
            var profileSettingsPage = GatekeeperFactory.CreatePageManager<ProfilePage>(_driverManager.Driver);
            profileSettingsPage.SetBaseProfile(firstName, lastName, street1, city, zipcode);

            var isExpected = profileSettingsPage.IsErrorMsgExpected(msg);
            Assert.True(isExpected, "Message is incorrect");
        }

        [Theory(DisplayName = cst_DisplayName + ".SuccessSaveBasicInfo")]
        [InlineData("Winnie", "Wang", "YunGu Road", "Xian", "92121", "Updated Successfully!")]        
        public void ProfileBasicInfoSuccessSave(string firstName, string lastName, string street1, string city, string zipcode, string msg)
        {
            //_driverManager.NavigateTo(PageAlias.Launchpad_Password);         
            var profileSettingsPage = GatekeeperFactory.CreatePageManager<ProfilePage>(_driverManager.Driver);
            string random= Guid.NewGuid().ToString().Substring(0, 5);
            firstName =firstName + random;
            lastName = lastName + random;
            street1 =street1 + random;
            city =city + random;
            zipcode =zipcode + random;     
             
            profileSettingsPage.SetBaseProfile(firstName, lastName, street1, city, zipcode);

            var isExpected = profileSettingsPage.IsSuccessMsgExpected(msg);
            Assert.True(isExpected, "Message is incorrect");

            //DB verify
            //var dbDataDic = new Dictionary<string, List<ReportDataModel>>();

            //var dbdatadic=new Dictionary <>
        }

        [Theory(DisplayName = cst_DisplayName + ".ClosePage")]      
        public void ClosePwdPage()
        {
            var profileSettingsPage = GatekeeperFactory.CreatePageManager<ProfilePage>(_driverManager.Driver);
            profileSettingsPage.btnClose.Click();

            //need assert if returned to Launchpad_Home page
        }
    }
}