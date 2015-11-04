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
            var isSame = false;
            var url = RouteMapper.ConvertAliasToUrl(pageAlias);
            if (_driver.Url == url)
            {
                isSame = true;
            }
            return isSame;
        }
    }
}
