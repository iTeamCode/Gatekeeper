using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class HeaderControl: PageControlBase

    {
        public HeaderControl (IWebDriver driver, string rootXpath): base (driver, rootXpath)
        {
           
        }

        # region Dom elements XPath

        protected const string cst_MoveHeader = "{0}";

        # endregion


        # region elements object
        
        # endregion




    }
}
