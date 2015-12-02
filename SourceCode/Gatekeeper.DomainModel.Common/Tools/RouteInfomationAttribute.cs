using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Common
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class RouteInfomationAttribute : Attribute
    {
        public AppAlias AppAlias { get; set; }

        public RouteInfomationAttribute(AppAlias app)
        {
            this.AppAlias = app;
        }
    }
}
