using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.TestPortal.Common
{
    public interface IDriverManager
    {
        IWebDriver Driver { get; }

        void NavigateTo(PageAlias pageAlias);

        bool IsCurrentPage(PageAlias pageAlias);
    }
}
