using Gatekeeper.DomainModel.Dashboard;
using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    /// <summary>
    /// Tool bar control
    /// </summary>
    public class ToolBarControl : PageControlBase
    {
        public ToolBarControl(IWebDriver driver, string rootXPath) : base(driver, rootXPath) { }

        protected override void ReloadControls()
        {
            base.ReloadControls();
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
        protected const string cst_StartDayOfWeek_Sunday_Label = ".//input[@id='first-day-sunday']/following-sibling::label[@for='first-day-sunday']";
        protected const string cst_StartDayOfWeek_Monday_Label = ".//input[@id='first-day-monday']/following-sibling::label[@for='first-day-monday']";
        protected const string cst_StartDayOfWeek_Tuesday_Label = ".//input[@id='first-day-tuesday']/following-sibling::label[@for='first-day-tuesday']";
        protected const string cst_StartDayOfWeek_Wednesday_Label = ".//input[@id='first-day-wednesday']/following-sibling::label[@for='first-day-wednesday']";
        protected const string cst_StartDayOfWeek_Thursday_Label = ".//input[@id='first-day-thursday']/following-sibling::label[@for='first-day-thursday']";
        protected const string cst_StartDayOfWeek_Friday_Label = ".//input[@id='first-day-friday']/following-sibling::label[@for='first-day-friday']";
        protected const string cst_StartDayOfWeek_Saturday_Label = ".//input[@id='first-day-saturday']/following-sibling::label[@for='first-day-saturday']";

        protected const string cst_StartDayOfWeek_Sunday_Radio = ".//input[@id='first-day-sunday']";
        protected const string cst_StartDayOfWeek_Monday_Radio = ".//input[@id='first-day-monday']";
        protected const string cst_StartDayOfWeek_Tuesday_Radio = ".//input[@id='first-day-tuesday']";
        protected const string cst_StartDayOfWeek_Wednesday_Radio = ".//input[@id='first-day-wednesday']";
        protected const string cst_StartDayOfWeek_Thursday_Radio = ".//input[@id='first-day-thursday']";
        protected const string cst_StartDayOfWeek_Friday_Radio = ".//input[@id='first-day-friday']";
        protected const string cst_StartDayOfWeek_Saturday_Radio = ".//input[@id='first-day-saturday']";

        protected const string cst_ProgressBar = ".//div[@role='progressbar']/parent::div";

        
        #endregion

        #region Dom elements object
        [FindsBy(How = How.XPath, Using = cst_Configurator)]
        protected IWebElement _btnConfigurator;

        //[FindsBy(How = How.XPath, Using = cst_SelectView_Week_Label)]
        protected IWebElement _btnWeek;
        protected IWebElement btnWeek {
            get {
                if (_btnWeek == null)
                {
                    _btnWeek = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_SelectView_Week_Label));
                }
                return _btnWeek;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_SelectView_Month_Label)]
        protected IWebElement _btnMonth;
        protected IWebElement btnMonth
        {
            get
            {
                if (_btnMonth == null)
                {
                    _btnMonth = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_SelectView_Month_Label));
                }
                return _btnMonth;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_SelectView_Quarter_Label)]
        protected IWebElement _btnQuarter;
        protected IWebElement btnQuarter
        {
            get
            {
                if (_btnQuarter == null)
                {
                    _btnQuarter = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_SelectView_Quarter_Label));
                }
                return _btnQuarter;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_SelectView_Year_Label)]
        protected IWebElement _btnYear;
        protected IWebElement btnYear
        {
            get
            {
                if (_btnYear == null)
                {
                    _btnYear = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_SelectView_Year_Label));
                }
                return _btnYear;
            }
        }

        //[FindsBy(How = How.XPath, Using = cst_StartDayOfWeek_Sunday_Label)]
        protected IWebElement _btnWeekDay_Sunday;
        protected IWebElement btnWeekDay_Sunday
        {
            get
            {
                if (_btnWeekDay_Sunday == null)
                {
                    _btnWeekDay_Sunday = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_StartDayOfWeek_Sunday_Label));
                }
                return _btnWeekDay_Sunday;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_StartDayOfWeek_Monday_Label)]
        protected IWebElement _btnWeekDay_Monday;
        protected IWebElement btnWeekDay_Monday
        {
            get
            {
                if (_btnWeekDay_Monday == null)
                {
                    _btnWeekDay_Monday = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_StartDayOfWeek_Monday_Label));
                }
                return _btnWeekDay_Monday;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_StartDayOfWeek_Tuesday_Label)]
        protected IWebElement _btnWeekDay_Tuesday;
        protected IWebElement btnWeekDay_Tuesday
        {
            get
            {
                if (_btnWeekDay_Tuesday == null)
                {
                    _btnWeekDay_Tuesday = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_StartDayOfWeek_Tuesday_Label));
                }
                return _btnWeekDay_Tuesday;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_StartDayOfWeek_Wednesday_Label)]
        protected IWebElement _btnWeekDay_Wednesday;
        protected IWebElement btnWeekDay_Wednesday
        {
            get
            {
                if (_btnWeekDay_Wednesday == null)
                {
                    _btnWeekDay_Wednesday = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_StartDayOfWeek_Wednesday_Label));
                }
                return _btnWeekDay_Wednesday;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_StartDayOfWeek_Thursday_Label)]
        protected IWebElement _btnWeekDay_Thursday;
        protected IWebElement btnWeekDay_Thursday
        {
            get
            {
                if (_btnWeekDay_Thursday == null)
                {
                    _btnWeekDay_Thursday = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_StartDayOfWeek_Thursday_Label));
                }
                return _btnWeekDay_Thursday;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_StartDayOfWeek_Friday_Label)]
        protected IWebElement _btnWeekDay_Friday;
        protected IWebElement btnWeekDay_Friday
        {
            get
            {
                if (_btnWeekDay_Friday == null)
                {
                    _btnWeekDay_Friday = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_StartDayOfWeek_Friday_Label));
                }
                return _btnWeekDay_Friday;
            }
        }
        //[FindsBy(How = How.XPath, Using = cst_StartDayOfWeek_Saturday_Label)]
        protected IWebElement _btnWeekDay_Saturday;
        protected IWebElement btnWeekDay_Saturday
        {
            get
            {
                if (_btnWeekDay_Saturday == null)
                {
                    _btnWeekDay_Saturday = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_StartDayOfWeek_Saturday_Label));
                }
                return _btnWeekDay_Saturday;
            }
        }
        #endregion

        #region Property for client
        #endregion

        #region Action for client
        /// <summary>
        /// Action for select view.
        /// </summary>
        /// <param name="view">enum for view type</param>
        public void Action_SelectView(ChartView view)
        {
            string waitElement = string.Empty;
            switch (view)
            {
                case ChartView.Week:
                    this.btnWeek.Click();
                    break;
                case ChartView.Month:
                    this.btnMonth.Click();
                    break;
                case ChartView.Quarter:
                    this.btnQuarter.Click();
                    break;
                case ChartView.Year:
                    this.btnYear.Click();
                    break;
                default:
                    return;
            }
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this._driver, By.XPath(cst_ProgressBar));
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        /// <summary>
        /// Action for select start day of week.
        /// </summary>
        /// <param name="view">enum for DayOfWeek type</param>
        public void Action_SelectStartDayOfWeek(DayOfWeek startDay)
        {
            string waitElement = string.Empty;
            switch (startDay)
            {
                case DayOfWeek.Sunday:
                    this.btnWeekDay_Sunday.Click();
                    break;
                case DayOfWeek.Monday:
                    this.btnWeekDay_Monday.Click();
                    break;
                case DayOfWeek.Tuesday:
                    this.btnWeekDay_Tuesday.Click();
                    break;
                case DayOfWeek.Wednesday:
                    this.btnWeekDay_Wednesday.Click();
                    break;
                case DayOfWeek.Thursday:
                    this.btnWeekDay_Thursday.Click();
                    break;
                case DayOfWeek.Friday:
                    this.btnWeekDay_Friday.Click();
                    break;
                case DayOfWeek.Saturday:
                    this.btnWeekDay_Saturday.Click();
                    break;
                default:
                    return;
            }
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this._driver, By.XPath(cst_ProgressBar));
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        #endregion

        #region Check point for client
        #endregion
    }
}
