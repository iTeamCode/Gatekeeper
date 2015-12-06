using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Dashboard
{
    public class WidgetItemModel
    {
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public bool Selected { get; set; }
    }
}
