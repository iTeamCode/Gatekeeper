using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    public class WebDriverManager : IDriverManager
    {
        private IWebDriver _driver;

        public IWebDriver Driver
        {
            get
            {
                return this._driver;
            }
        }
        public PageAlias CurrentPage
        {
            get
            {
                var url = this._driver.Url;
                var alias = PageAlias.Empty_Page;
                try
                {
                    alias = RouteMapper.ConvertUrlToAlias(url);
                }
                catch
                {
                    alias = PageAlias.Empty_Page;
                }
                return alias;
            }
        }

        public WebDriverManager(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void NavigateTo(PageAlias pageAlias)
        {
            var url = RouteMapper.ConvertAliasToUrl(pageAlias);
            _driver.Url = url;

            if (_driver.Url != url)
            {
                throw new Exception(string.Format("Navigate To : {0} faild!", pageAlias));
            }
        }

        public bool IsCurrentPage(PageAlias pageAlias)
        {
            return WebElementKeeper.WaitingFor_UrlToBe(_driver, pageAlias);
        }
    }
}
