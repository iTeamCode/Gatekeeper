﻿using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Dashboard;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Gatekeeper.TestPortal.Dashboard
{
    public class Chart_DataCheck : IClassFixture<InitialConfigurationFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "Chart.DataCheck";

        private IDriverManager _driverManager;
        public Chart_DataCheck(InitialConfigurationFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //check data here;
        }
        #endregion

        #region Test-Driver Data
        /// <summary>
        /// input data for "VerifiedTopBar"
        /// </summary>
        public static IEnumerable<object[]> VerifiedTopBar_Data
        {
            get
            {
                return new[]
                {
                    //Giving
                    new object[]{0, "Giving", "$", ChartView.Quarter, null},
                    new object[]{0, "Giving", "$", ChartView.Month, null},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Sunday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Monday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Tuesday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Wednesday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Thursday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Friday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Saturday},
                    //Attendance
                    new object[]{1, "Attendance", "", ChartView.Quarter, null},
                    new object[]{1, "Attendance", "", ChartView.Month, null},
                    new object[]{1, "Attendance", "", ChartView.Week, DayOfWeek.Sunday},
                    new object[]{1, "Attendance", "", ChartView.Week, DayOfWeek.Monday},
                    new object[]{1, "Attendance", "", ChartView.Week, DayOfWeek.Tuesday},
                    new object[]{1, "Attendance", "", ChartView.Week, DayOfWeek.Wednesday},
                    new object[]{1, "Attendance", "", ChartView.Week, DayOfWeek.Thursday},
                    new object[]{1, "Attendance", "", ChartView.Week, DayOfWeek.Friday},
                    new object[]{1, "Attendance", "", ChartView.Week, DayOfWeek.Saturday},
                    //Attribute
                    new object[]{2, "", "", ChartView.Quarter, null},
                    new object[]{2, "", "", ChartView.Month, null},
                    new object[]{2, "", "", ChartView.Week, DayOfWeek.Sunday},
                    new object[]{2, "", "", ChartView.Week, DayOfWeek.Monday},
                    new object[]{2, "", "", ChartView.Week, DayOfWeek.Tuesday},
                    new object[]{2, "", "", ChartView.Week, DayOfWeek.Wednesday},
                    new object[]{2, "", "", ChartView.Week, DayOfWeek.Thursday},
                    new object[]{2, "", "", ChartView.Week, DayOfWeek.Friday},
                    new object[]{2, "", "", ChartView.Week, DayOfWeek.Saturday},
                };
            }
        }
        #endregion

        #region Test-Case
        [Theory(DisplayName = cst_DisplayName + ".TopBar_Year")]
        [InlineData(0, "Giving", "$")]
        [InlineData(1, "Attendance", "")]
        [InlineData(2, "", "")]
        public void VerifiedTopBarData_Year(int index, string title, string prefix)
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Home);
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);
            var toolBar = homePage.ToolBar;
            toolBar.Action_SelectView(ChartView.Year);

            homePage.ChartSections.ForEach(x => x.Expand = false);
            var chartSection = homePage.ChartSections[index];
            chartSection.Expand = true;
            if (!string.IsNullOrEmpty(title))
            {
                Assert.Equal(title, chartSection.DetailBar.Name);
            }

            var chartView_YearData = chartSection.ChartView.GetEndData().PointData.Value;
            var chartView_LastYearData = chartSection.ChartView.GetEndData(1).PointData.Value;
            var chartView_BeforeLastYearData = chartSection.ChartView.GetEndData(2).PointData.Value;

            var currentYear = DateTime.Now.Year;
            Assert.Equal("Today " + currentYear, chartSection.DetailBar.MainAreaTitle);

            if (chartView_YearData < 1000000)
            {
                Assert.Equal(chartView_YearData, chartSection.DetailBar.MainAreaValue);
            }
            else
            {
                Assert.Equal(RoundingData(chartView_YearData), RoundingData(chartSection.DetailBar.MainAreaValue));
            }

            Assert.Equal((currentYear - 1).ToString(), chartSection.DetailBar.LastYearAreaTitle);
            if (chartView_LastYearData < 1000000)
            {
                Assert.Equal(chartView_LastYearData, chartSection.DetailBar.LastYearAreaValue);
            }
            else
            {
                Assert.Equal(RoundingData(chartView_LastYearData), RoundingData(chartSection.DetailBar.LastYearAreaValue));
            }

            Assert.Equal((currentYear - 2).ToString(), chartSection.DetailBar.BeforeLastYearAreaTitle);
            if (chartView_BeforeLastYearData < 1000000)
            {
                Assert.Equal(chartView_BeforeLastYearData, chartSection.DetailBar.BeforeLastYearAreaValue);
            }
            else
            {
                Assert.Equal(RoundingData(chartView_BeforeLastYearData), RoundingData(chartSection.DetailBar.BeforeLastYearAreaValue));
            }


            string tempStr = "{0} From year prior {1}";
            string specifier = prefix == "$" ? "N" : "#,0";
            string dataFrom = (chartView_YearData == 0) ? (prefix + "0") : (prefix + chartView_YearData.ToString(specifier));
            string dataTo = (chartView_LastYearData == 0) ? (prefix + "0") : (prefix + chartView_LastYearData.ToString("#,0.##"));
            if (chartView_YearData != 0 && chartView_LastYearData != 0)
            {
                var data = (chartView_YearData - chartView_LastYearData) / chartView_LastYearData;
                dataFrom = (data * 100).ToString("#,0.##") + "%";
            }
            Assert.Equal(string.Format(tempStr, dataFrom, dataTo), chartSection.DetailBar.CompareText);

            chartSection.Expand = false;
            Assert.Equal(dataFrom, chartSection.SummaryBar.CompareWithLast);
        }

        [Theory(DisplayName = cst_DisplayName + ".TopBar")]
        [MemberData("VerifiedTopBar_Data")]
        public void VerifiedTopBar(int index, string title, string prefix, ChartView chartView, DayOfWeek? dayOfWeek)
        {
            _driverManager.NavigateTo(PageAlias.Dashboard_Home);
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);
            //Select view.
            var toolBar = homePage.ToolBar;
            toolBar.Action_SelectView(chartView);
            if (dayOfWeek.HasValue && chartView == ChartView.Week)
            {
                toolBar.Action_SelectStartDayOfWeek(dayOfWeek.Value);
            }

            homePage.ChartSections.ForEach(x => x.Expand = false);
            var chartSection = homePage.ChartSections[index];
            chartSection.Expand = true;


            if (!string.IsNullOrEmpty(title))
            {
                Assert.Equal(title, chartSection.DetailBar.Name);
            }

            //get data from chart.
            var cvCurrentModel = chartSection.ChartView.GetEndData();
            var cvLastModel = chartSection.ChartView.GetEndData(1);

            //verify data.
            var currentYear = DateTime.Now.Year;
            var lastYear = DateTime.Now.Year - 1;

            //MainArea
            Assert.Equal("Today " + currentYear, chartSection.DetailBar.MainAreaTitle);
            Assert.Equal(cvCurrentModel.PointData.Value, chartSection.DetailBar.MainAreaValue);

            //LastYearArea
            Assert.Equal(lastYear.ToString(), chartSection.DetailBar.LastYearAreaTitle);
            Assert.Equal(chartSection.ChartView[cvCurrentModel.X_Axis, lastYear.ToString()], chartSection.DetailBar.LastYearAreaValue);

            var currentData = cvCurrentModel.PointData;
            var lastData = cvLastModel.PointData;
            string tempStr = BuildCompareTextTemp(chartView);
            string specifier = prefix == "$" ? "N" : "#,0";
            string dataFrom = (!currentData.HasValue) ? (prefix + "0") : (prefix + currentData.Value.ToString(specifier));
            string dataTo = (!lastData.HasValue) ? (prefix + "0") : (prefix + lastData.Value.ToString("#,0.##"));

            if (currentData.Value != 0 && lastData.Value != 0)
            {
                var data = (currentData.Value - lastData.Value) / lastData.Value;
                dataFrom = (data * 100).ToString("#,0.##") + "%";
            }
            else
            {
                //dataFrom = prefix + (currentData.Value - lastData.Value).ToString(specifier);
                dataFrom = prefix + (currentData.Value - lastData.Value).ToString("#,0.##");
            }
            Assert.Equal(string.Format(tempStr, dataFrom, dataTo), chartSection.DetailBar.CompareText);

            chartSection.Expand = false;
            Assert.Equal(dataFrom, chartSection.SummaryBar.CompareWithLast);
        }

        private string RoundingData(decimal num)
        {
            return (num / 1000000).ToString("#.00");
        }

        private string BuildCompareTextTemp(ChartView view)
        {
            string strView = string.Empty;
            switch (view)
            {
                case ChartView.Month:
                    strView = "month";
                    break;
                case ChartView.Quarter:
                    strView = "quarter";
                    break;
                case ChartView.Week:
                    strView = "week";
                    break;
            }
            string tempStr = "{0} From " + strView + " prior {1}";
            return tempStr;
        }
        #endregion Test-Case
    }
}