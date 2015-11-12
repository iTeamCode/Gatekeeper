using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    /// <summary>
    /// Alias for appliations.
    /// </summary>
    public enum AppAlias
    {
        Unkonw,
        [Description("Dashboard")]
        Dashboard,
        [Description("Teacher")]
        Teacher,
        [Description("Coordinator")]
        Coordinator,
        [Description("LaunchPad")]
        LaunchPad,
        [Description("Infellowship")]
        Infellowship,
        [Description("Portal")]
        Portal
    }
}
