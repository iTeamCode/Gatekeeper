using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class ChartViewControl : PageControlBase
    {
        public ChartViewControl(IWebDriver driver, string rootXPath) : base(driver, rootXPath) { }
    }
}
