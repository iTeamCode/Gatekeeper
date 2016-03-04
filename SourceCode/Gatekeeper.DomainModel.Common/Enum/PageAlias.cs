using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Common
{
    /// <summary>
    /// Alias for pages.
    /// </summary>
    public enum PageAlias
    {
        #region Dashboard
        /// <summary>
        /// Dashboard_SignIn
        /// </summary>
        [RouteInfomation(AppAlias.Dashboard)]
        Dashboard_SignIn = 10001,
        /// <summary>
        /// Dashboard_Home
        /// </summary>
        [RouteInfomation(AppAlias.Dashboard)]
        Dashboard_Home = 10002,
        /// <summary>
        /// Dashboard_Configuration
        /// </summary>
        [RouteInfomation(AppAlias.Dashboard)]
        Dashboard_Configuration = 10003,
        #endregion

        #region Teacher
        /// <summary>
        /// Teacher_SignIn
        /// </summary>
        [RouteInfomation(AppAlias.Teacher)]
        Teacher_SignIn = 20001,

        [RouteInfomation(AppAlias.Teacher)]
        Teacher_Roster = 20002,
        #endregion

        #region Coordinator
        /// <summary>
        /// Coordinator_RegisterDevice
        /// </summary>
        [RouteInfomation(AppAlias.Coordinator)]
        Coordinator_RegisterDevice = 30001,
        /// <summary>
        /// Coordinator_ActivityCodePage
        /// </summary>
        [RouteInfomation(AppAlias.Coordinator)]
        Coordinator_ActivityCode = 30002,
        /// <summary>
        /// Coordinator_ActivityInstances
        /// </summary>
        [RouteInfomation(AppAlias.Coordinator)]
        Coordinator_ActivityInstances = 30003,
        /// <summary>
        /// Coordinator_MovePage
        /// </summary>
        [RouteInfomation(AppAlias.Coordinator)]
        Coordinator_MovePage = 30004,
        #endregion

        #region Launchpad
        /// <summary>
        /// LaunchPad_SignIn
        /// </summary>
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_SignIn = 40001,
        /// <summary>
        /// Launchpad_Home
        /// </summary>
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_Home = 40002,       
        /// <summary>
        /// Launchpad_Profile
        /// </summary>
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_Profile= 40003,  
        /// <summary>
        /// Launchpad_Password
        /// </summary>
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_Password = 40004, 
        /// <summary>
        /// Launchpad_privacy
        /// </summary>
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_Privacy = 40005, 
        /// <summary>
        /// Launchpad_household
        /// </summary>
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_Household = 40006,
        /// <summary>
        /// Launchpad_SignIn_ChurchUndefined
        /// </summary>        
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_SignIn_ChurchUndefined = 40007,
        /// <summary>
        /// Launchpad_SignIn_WrongChurch
        /// </summary>    
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_SignIn_WrongChurch = 40008,
        /// <summary>
        /// Launchpad_SignIn_WrongUrl1
        /// </summary>    
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_SignIn_WrongUrl1 = 40009,
        /// <summary>
        /// Launchpad_SignIn_WrongUrl2
        /// </summary>    
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_SignIn_WrongUrl2 = 40010,
        /// <summary>
        /// Launchpad_SignIn_WrongUrl3
        /// </summary>    
        [RouteInfomation(AppAlias.Launchpad)]
        Launchpad_SignIn_WrongUrl3 = 40011,
        /// <summary>
        /// Empty_Page
        /// </summary>    
        Empty_Page = 0,           
        #endregion
    }
}