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
    public partial class MyAccountDataCheck// :IClassFixture<InitialAccountFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "Profile.DataCheck.DB";
        
        //private IDriverManager _driverManager;
        //public MyAccountDataCheck(InitialAccountFixture fixture)
        //{
        //    this._driverManager = fixture.DriverManager;
        //   // _driverManager.NavigateTo(PageAlias.Launchpad_Profile);
        //    //System.Threading.Thread.Sleep(5000);
        //}
        #endregion 
        
        #region Test-Case   
        [Theory(DisplayName = cst_DisplayName + ".BasicInfo")]
        [InlineData(15, "winnie.wang@activenetwork.com", "BasicInfo")]
        public void VerifyBasicIndividualInfo(int churchId, string loginEmail, string infoType)
        {
            //#01. Save new data.
            //string random = Guid.NewGuid().ToString().Substring(0, 5);
            //string firstname = "winnie";
            //string lastname = "wang";
            //string street1 = "Yungu Road";
            //string city = "Xian";
            //string zipcode;

            //Save new value to current accout
            //firstname = firstname + random;
            //lastname = lastname + random;
            //street1 = street1 + random;
            //city = city + random;
            //zipcode = random;

            //var profileSettingsPage = GatekeeperFactory.CreatePageManager<ProfilePage>(_driverManager.Driver);  
            //profileSettingsPage.SetBaseProfile(firstname, lastname, street1, city, zipcode);
            //System.Threading.Thread.Sleep(5000);

            //var isExpected = profileSettingsPage.IsSuccessMsgExpected("Updated Successfully!");
            //Assert.True(isExpected, "Message is incorrect");

            //#02. Get data from DB.
            var dbDataDic = new Dictionary<string, List<UserProfileModel>>();
          
            dbDataDic = GetDataFromDB_Profile(loginEmail, churchId, infoType);
          
            

            //#03. Compare data.


        }  
        
        private Dictionary<string, List<UserProfileModel>> GetDataFromDB_Profile(string loginEmail, int churchId, string infotype)
        {               
            var newData = GetDataList(loginEmail, churchId, infotype);
            
             var dbDataList = new List<UserProfileModel>(25);

             var dicData = new Dictionary<string, List<UserProfileModel>>();
             
             return dicData;
        }
        
        private List<UserProfileModel> GetDataList(string loginEmail, int churchId, string infotype)
        {
            var dvLaunchpad = DataVisitor.Create<ILaunchpadDataVisitor>();
            //var dataList = new List<UserProfileModel>();
            var dataList = dvLaunchpad.FetchBasicProfileData(churchId, loginEmail, infotype);
            return dataList;
        }
        #endregion Test-Case
    }    
}
