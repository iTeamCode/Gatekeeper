﻿using Gatekeeper.DomainModel.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Framework.Common
{
    /// <summary>
    /// Interface DriverManager
    /// </summary>
    public interface IDriverManager
    {
        /// <summary>
        /// get web driver entity.
        /// </summary>
        IWebDriver Driver { get; }
        /// <summary>
        /// get current page.
        /// </summary>
        PageAlias CurrentPage { get; }


        /// <summary>
        /// Navigate page function
        /// </summary>
        /// <param name="pageAlias"></param>
        /// <param name="isCheckPage"></param>
        void NavigateTo(PageAlias pageAlias);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageAlias"></param>
        /// <param name="isCheckPage"></param>
        void NavigateTo(PageAlias pageAlias, bool isCheckPage);

        /// <summary>
        /// Navigate to an unstable page which will be redirected to another page automatically
        /// </summary>
        /// <param name="pageAlias"></param>
        /// <param name="isCheckPage"></param>
        void NavigateToUnstablePage(PageAlias pageAlias);

        bool IsCurrentPage(PageAlias pageAlias);
    }
}
