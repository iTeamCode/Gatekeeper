﻿using Gatekeeper.PageObject.Launchpad;
using Gatekeeper.TestPortal.Common;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class Dashboard_SignIn_Success_Test
    {
        [Fact]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.LaunchPad_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<SignInPage>(manager.Driver);
            signInPage.Action_SignIn("ft.tester", "FT4life!");

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Dashboard_Home));
            manager.Driver.Close();
        }
    }
}
