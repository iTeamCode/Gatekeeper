using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
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
        #endregion

        #region Coordinator
        /// <summary>
        /// Coordinator_SignIn
        /// </summary>
        [RouteInfomation(AppAlias.Coordinator)]
        Coordinator_SignIn = 30001,
        #endregion

        #region LaunchPad
        /// <summary>
        /// LaunchPad_SignIn
        /// </summary>
        [RouteInfomation(AppAlias.LaunchPad)]
        LaunchPad_SignIn = 40001,
        #endregion
        /// <summary>
        /// Empty_Page
        /// </summary>
        Empty_Page = 0
    }
}
