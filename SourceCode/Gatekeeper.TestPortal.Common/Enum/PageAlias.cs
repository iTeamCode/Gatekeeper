using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    public enum PageAlias
    {
        #region Dashboard
        [RouteInfomation(AppAlias.Dashboard)]
        Dashboard_SignIn = 10001,
        [RouteInfomation(AppAlias.Dashboard)]
        Dashboard_Home = 10002,
        [RouteInfomation(AppAlias.Dashboard)]
        Dashboard_Configuration = 10003,
        #endregion

        #region Teacher
        [RouteInfomation(AppAlias.Teacher)]
        Teacher_SignIn = 20001,
        #endregion

        #region Coordinator
        [RouteInfomation(AppAlias.Coordinator)]
        Coordinator_SignIn = 30001,
        #endregion

        #region LaunchPad
        [RouteInfomation(AppAlias.LaunchPad)]
        LaunchPad_SignIn = 40001,
        #endregion

        Empty_Page = 0
    }
}
