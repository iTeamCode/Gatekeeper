using FellowshipOne.Framework.Entitys;
using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Launchpad;
using Gatekeeper.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Toolbox.DataAccess
{
    public class LaunchpadDataVisitor : ILaunchpadDataVisitor
    {
        private static DataManager _dataManager = DataManagerFactory.CreateDataManager(DataBaseType.SQLServer);

        public List<UserProfileModel> FetchBasicProfileData(int churchId, string loginEmail, string infoType)
        {
            CustomerCommand command = _dataManager.CreateCustomerCommand("Launchpad.FetchBasicProfileData");
            command.SetParameterValue("@ChurchId", churchId);
            command.SetParameterValue("@LoginEmail", loginEmail);
            
            return command.ExecuteCommandToEntitys<UserProfileModel>();
        }
    }
}