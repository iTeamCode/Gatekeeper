using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Launchpad
{
    public class LaunchpadSignInPage : PageObjectBase, ISignInPage
    {

        public LaunchpadSignInPage(IWebDriver driver)
            : base(driver)
        {
            WebElementKeeper.WaitingFor_ElementExists(this.Driver, By.Id("username"));
        }
        #region Page elements
        [FindsBy(How = How.Id, Using = "username")]
        protected IWebElement txtUserName;

        [FindsBy(How = How.Id, Using = "password")]
        protected IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='First name']")]
        protected IWebElement txtFirstname;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Last name']")]
        protected IWebElement txtLastname;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Email']")]
        protected IWebElement txtEmail;

        [FindsBy(How = How.XPath, Using = ".//input[contains(@placeholder,'Password') and contains(@class,'Textbox')]")]
        protected IWebElement txtSignUpPassword;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Confirm password']")]
        protected IWebElement txtConfirmPassword;
        
        [FindsBy(How = How.XPath, Using = ".//button[text()='Sign in']")]
        protected IWebElement btnSignIn;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Save and create account']")]
        protected IWebElement btnSignUp;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Reset password']")]
        protected IWebElement btnRestPwd;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Cancel']")]
        protected IWebElement btnCancel;

        [FindsBy(How = How.XPath, Using = ".//a[text()='Sign up!']")]
        public IWebElement linkSignUp;

        [FindsBy(How = How.XPath, Using = ".//a[text()='Forgot Password?']")]
        public IWebElement linkForgotPassword;
        
        private string _errorMsgXPath = ".//div[@ng-show='errorText']";
        [FindsBy(How = How.XPath, Using = ".//div[@ng-show='errorText']")]
        protected IWebElement txtErrorMsg;

        private string _errorMsgXPathSignUp = ".//div[@ng-show='signupErrorText']";
        [FindsBy(How = How.XPath, Using = ".//div[@ng-show='signupErrorText']")]
        protected IWebElement txtErrorMsgSignUp;

        private string _errorMsgXPathPassword = ".//div[@class='ng-scope']/div[@ng-show='errorText']";
        [FindsBy(How = How.XPath, Using = ".//div[@class='ng-scope']/div[@ng-show='errorText']")]
        protected IWebElement txtErrorMsgPassword;

        private string _spinnerRoseXPath = ".//div[@class='spinner']";
        [FindsBy(How = How.XPath, Using = ".//div[@class='spinner']")]
        protected IWebElement spinnerRose;
        #endregion Page elements

        #region Action for test case
        /// <summary>
        /// Sign In for Dashboard
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="churchCode">Church code</param>
        public void Action_SignIn()
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();
            this.btnSignIn.Click();
            //Wait for refreshing
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.XPath(_spinnerRoseXPath));
        }

        public void Action_SignIn(string userName, string password, string churchCode)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();
         //   this.txtChurchCode.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);
          //  this.txtChurchCode.SendKeys(churchCode);

            this.btnSignIn.Click();
        }

        public void Action_SignIn(string userName, string password)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);
            
            this.btnSignIn.Click();
        }

        public void Action_SignUp()
        {
            this.linkSignUp.Click();        
        }

        public void Action_SignUp(string firstName, string lastName, string email, string signUpPwd, string confirmPwd)
        {  
            this.txtFirstname.Clear();
            this.txtLastname.Clear();
            this.txtEmail.Clear();
            this.txtSignUpPassword.Clear();
            this.txtConfirmPassword.Click();

            this.txtFirstname.SendKeys(firstName);
            this.txtLastname.SendKeys(lastName);
            this.txtEmail.SendKeys(email);
            this.txtSignUpPassword.SendKeys(signUpPwd);
            this.txtConfirmPassword.SendKeys(confirmPwd);

            this.btnSignUp.Click();
            
            //Wait for refreshing
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.XPath(_spinnerRoseXPath));

        }

        public void Action_GetPassword()
        {
            this.linkForgotPassword.Click();        
        }

        public void Action_PwdSendEmail(string email)
        {
            this.txtEmail.Clear();

            this.txtEmail.SendKeys(email);

            this.btnRestPwd.Click();

            //Wait for refreshing
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.XPath(_spinnerRoseXPath));        
        }

        public void Action_Cancel()
        {
            this.btnCancel.Click();
        }

        public string ErrorMsg
        {
            get
            {
                var msg = string.Empty;

                var hasErrorMsg = WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));
                if (!hasErrorMsg && !txtErrorMsg.Displayed) return msg;

                return txtErrorMsg.Text;
            }
        }
        #endregion

        #region Check Point
        /// <summary>
        /// Check error message is 'expectedErrorMsg'.
        /// </summary>
        /// <param name="expectedErrorMsg">expected error message.</param>
        /// <returns>is verify success</returns>
        public bool Check_ErrorMessage(string expectedErrorMsg)
        {
            var verifyErrorMsg = false;
            var hasErrorMsg = WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));
            if (!hasErrorMsg && !txtErrorMsg.Displayed) return verifyErrorMsg;

            verifyErrorMsg = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsg, expectedErrorMsg);
            return verifyErrorMsg;
        }      

        public bool IsErrorMsgExpected(string expectedErrorMsg)
        {
            var isExpected = false;
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));

            if (!txtErrorMsg.Displayed)
                return isExpected;

            isExpected = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsg, expectedErrorMsg);
            return isExpected;
        }

        public bool IsErrorMsgExpectedSignUp(string expectedErrorMsg)
        {
            var isExpected = false;
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPathSignUp));

            if (!txtErrorMsgSignUp.Displayed)
                return isExpected;

            isExpected = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsgSignUp, expectedErrorMsg);
            return isExpected;
        }

        public bool IsErrorMsgExpectedPassword(string expectedErrorMsg)
        {
            var isExpected = false;
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPathPassword));

            if (!txtErrorMsgPassword.Displayed)
                return isExpected;

            isExpected = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsgPassword, expectedErrorMsg);
            return isExpected;
        }

        #endregion
    }
}