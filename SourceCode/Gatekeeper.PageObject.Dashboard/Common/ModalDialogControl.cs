using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class ModalDialogControl : ModalDialogBase
    {
        public ModalDialogControl(IWebDriver driver, string rootXPath) : base(driver, rootXPath) { }

        protected IWebElement _title;
        protected IWebElement txtTitle
        {
            get
            {
                if (_title == null)
                {
                    _title = WebElementKeeper.WaitingFor_GetElementWhenExists(_driver, By.XPath(string.Format(@"{0}/div/div[@class='modal-header']/h4", _rootXPath)));
                }
                return _title;
            }
        }

        protected IWebElement _content;
        protected IWebElement txtContent
        {
            get
            {
                if (_content == null)
                {
                    _content = WebElementKeeper.WaitingFor_GetElementWhenExists(_driver, By.XPath(string.Format(@"{0}/div/div[@class='modal-body']/p", _rootXPath)));
                }
                return _content;
            }
        }
        protected IWebElement _btnClose;
        protected IWebElement btnClose
        {
            get
            {
                if (_content == null)
                {
                    _content = WebElementKeeper.WaitingFor_GetElementWhenExists(_driver, By.XPath(string.Format(@"{0}/div/div[@class='modal-footer']/button", _rootXPath)));
                }
                return _content;
            }
        }

        public string TitleText
        {
            get
            {
                return this.txtTitle.Text;
            }
        }
        public string ContentText
        {
            get
            {
                return this.txtContent.Text;
            }
        }
        public void Close()
        {
            this.btnClose.Click();
        }
    }
}
