using FellowshipOne.Framework.Entitys;
using Gatekeeper.DomainModel.Launchpad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Toolbox.DataAccess
{
    public interface ILaunchpadDataVisitor : IDataVisitor
    {
        /// <summary>
        /// Fetch Basic Profile Data
        /// </summary>
        /// <param name="churchId">church Id</param>        
        /// <param name="loginEmail">loginEmail</param>
        /// <param name="infoType">Info Type</param>
        /// <returns>Report data</returns>
        List<UserProfileModel> FetchBasicProfileData(int churchId, string loginEmail, string infoType);        
    }
}


