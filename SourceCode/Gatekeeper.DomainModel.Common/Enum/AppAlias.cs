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
        [Description("Coordinator")]
        Coordinator,
        [Description("Membership_AUI")]
        Membership_AUI,
        [Description("Membership_CUI")]
        Membership_CUI,
        [Description("Membership_Portal")]
        Membership_Portal
    }
}
