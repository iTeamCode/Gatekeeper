using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Common
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
        [Description("Launchpad")]
        Launchpad,
        [Description("Infellowship")]
        Infellowship,
        [Description("Portal")]
        Portal
    }
}
