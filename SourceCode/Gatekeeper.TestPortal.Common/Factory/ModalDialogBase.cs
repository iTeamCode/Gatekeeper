using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    public class ModalDialogBase
    {
        public ModalDialogBase(IWebDriver driver, string rootXPath)
        {
            this._driver = driver;
            this._rootXPath = rootXPath;
        }
        protected IWebDriver _driver;
        protected string _rootXPath;

        public bool VerifyElement()
        {
            return WebElementKeeper.WaitingFor_ElementIsVisible(_driver, By.XPath(_rootXPath));
        }
    }
}
