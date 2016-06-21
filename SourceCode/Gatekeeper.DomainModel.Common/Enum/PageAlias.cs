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
        ///// <summary>
        ///// Teacher_SignIn
        ///// </summary>
        //[RouteInfomation(AppAlias.Teacher)]
        //Teacher_SignIn = 20001,

        //[RouteInfomation(AppAlias.Teacher)]
        //Teacher_Roster = 20002,
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
        /// AUI_SignIn
        /// </summary>
        [RouteInfomation(AppAlias.Membership_AUI)]
        AUI_SignIn = 40000,
        /// <summary>
        /// AUI_Program_Home
        /// </summary>
        [RouteInfomation(AppAlias.Membership_AUI)]
        AUI_Organization_Home = 40001,
        /// <summary>
        /// AUI_Program_Home
        /// </summary>
        [RouteInfomation(AppAlias.Membership_AUI)]
        AUI_Program_Home = 40002,
        /// <summary>
        /// Empty_Page
        /// </summary>    
        Empty_Page = 0,           
        #endregion
    }
}