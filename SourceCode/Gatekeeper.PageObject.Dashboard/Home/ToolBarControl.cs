using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class ToolBarControl : PageControlBase
    {
        public ToolBarControl(IWebDriver driver, string rootXPath) : base(driver, rootXPath) { }

        protected override void ReloadElements()
        {
            base.ReloadElements();
            //Reload:Start day of week
            //Reload:Time frame
        }

        #region Dom elements xpath
        //DateRange
        protected const string cst_DateRange = "{0}/div[@class='Navigation']/div[@class='dateRangeOuter']/div[@class='dateRange']";
        protected const string cst_DateRangeChurch = cst_DateRange + "/span[contains(@class,'dateRange-church')]";
        protected const string cst_DateRange_Date = cst_DateRange + "/span[@class='dateRange-date']";
        //Configurator
        protected const string cst_Configurator = "{0}/div[@class='Navigation']/div[@class='Navigation-right']/a/img";
        //Select view
        protected const string cst_SelectView = "{0}/div[@class='Range']/div[1]";

        protected const string cst_SelectView_Week_Label = ".//input[@id='view-type-week']/following-sibling::label[@for='view-type-week']";
        protected const string cst_SelectView_Month_Label = ".//input[@id='view-type-month']/following-sibling::label[@for='view-type-month']";
        protected const string cst_SelectView_Quarter_Label = ".//input[@id='view-type-quarter']/following-sibling::label[@for='view-type-quarter']";
        protected const string cst_SelectView_Year_Label = ".//input[@id='view-type-year']/following-sibling::label[@for='view-type-year']";

        protected const string cst_SelectView_Week_Radio = ".//input[@id='view-type-week']";
        protected const string cst_SelectView_Month_Radio = ".//input[@id='view-type-month']";
        protected const string cst_SelectView_Quarter_Radio = ".//input[@id='view-type-quarter']";
        protected const string cst_SelectView_Year_Radio = ".//input[@id='view-type-year']";

        //Start day of week
        protected const string cst_StartDayOfWeek = "{0}/div[@class='Range']/div[2]";
        #endregion

        #region Dom elements object
        [FindsBy(How = How.XPath, Using = cst_SelectView_Week_Label)]
        protected IWebElement _btnWeek;
        [FindsBy(How = How.XPath, Using = cst_SelectView_Month_Label)]
        protected IWebElement _btnMonth;
        [FindsBy(How = How.XPath, Using = cst_SelectView_Quarter_Label)]
        protected IWebElement _btnQuarter;
        [FindsBy(How = How.XPath, Using = cst_SelectView_Year_Label)]
        protected IWebElement _btnYear;

        protected IWebElement _btnWeekDay_Sunday;
        protected IWebElement _btnWeekDay_Monday;
        protected IWebElement _btnWeekDay_Tuesday;
        protected IWebElement _btnWeekDay_Wednesday;
        protected IWebElement _btnWeekDay_Thursday;
        protected IWebElement _btnWeekDay_Friday;
        protected IWebElement _btnWeekDay_Saturday;
        #endregion

        #region Property for client
        #endregion

        #region Action for client
        #endregion

        #region Check point for client
        #endregion
    }
}
