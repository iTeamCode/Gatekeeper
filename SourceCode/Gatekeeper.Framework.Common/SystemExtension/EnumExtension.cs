using Gatekeeper.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Framework.Common
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static AppAlias GetAppAlias(this PageAlias value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(RouteInfomationAttribute)) as RouteInfomationAttribute;
            if (attribute == null || attribute.AppAlias == AppAlias.Unkonw)
            {
                //To do
                throw new Exception("Please set 'RouteInfomationAttribute' to PageAlias!");
            }
            return attribute.AppAlias;
        }

    }
}
