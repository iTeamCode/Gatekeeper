using Gatekeeper.DomainModel.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Framework.Common
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
            NavigateTo(pageAlias, true);
        }
        public void NavigateTo(PageAlias pageAlias, bool isCheckPage)
        {
            if (this.CurrentPage == pageAlias) { return; }

            var url = RouteMapper.ConvertAliasToUrl(pageAlias);
            _driver.Url = url;

            if (isCheckPage && !WebElementKeeper.WaitingFor_UrlToBe(_driver, pageAlias))
            {
                throw new Exception(string.Format("Navigate To : {0} faild!", pageAlias));
            }
        }

        public void NavigateToUnstablePage(PageAlias pageAlias)
        {
            NavigateToUnstablePage(pageAlias, true); 
            
            //This waitfor can be extracted to a public method in Object/Common folder
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(_driver, By.XPath(".//div[@class='spinner']"));  
        }
        public void NavigateToUnstablePage(PageAlias pageAlias, bool isCheckPage)
        {
            if (this.CurrentPage == pageAlias) { return; }

            var url = RouteMapper.ConvertAliasToUrl(pageAlias);
            _driver.Url = url;         
        }

        public bool IsCurrentPage(PageAlias pageAlias)
        {
            //return WebElementKeeper.WaitingFor_UrlToBe(_driver, pageAlias);
            return WebElementKeeper.WaitingFor_UrlContains(_driver, pageAlias);
        }
    }
}
