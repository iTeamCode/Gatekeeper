using FellowshipOne.Framework.Entitys;
using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Toolbox.DataAccess
{
    public class CommonDataVisitor : ICommonDataVisitor
    {
        private static DataManager _dataManager = DataManagerFactory.CreateDataManager(DataBaseType.SQLServer);

        public ChurchModel FetchChurchInfomation(int churchId)
        {
            CustomerCommand command = _dataManager.CreateCustomerCommand("Church.FetchChurchInfomation");
            command.SetParameterValue("@ChurchId", churchId);

            ChurchModel church = command.ExecuteCommandToEntity<ChurchModel>();
            return church;
        }
    }
}
