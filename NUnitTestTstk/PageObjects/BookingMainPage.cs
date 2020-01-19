using NUnitTestTstk.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NUnitTestTstk.PageObjects
{
    class BookingMainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@type='search']")]
        public IWebElement searchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='sb-searchbox__button ']")]
        public IWebElement searchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='xp__dates-inner']")]
        public IWebElement calendar { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-bui-ref='calendar-next']")]
        public IWebElement calendarNextMonthBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-id='language_selector']")]
        public IWebElement languageIcon { get; set; }  ////li[@data-id='language_selector']

        public void openLanguageSelector()
        {
            languageIcon.Click();
        }

        public void setEnglishLocalization(IWebDriver driver)
        {
            By by = By.XPath("//a[@hreflang='en-us']");
            var engLocalizationListItems = driver.FindElements(by);
            if (engLocalizationListItems.Count > 0)
            {
                engLocalizationListItems[0].Click();
            }
        }


        public void SetSearchField(string searchText)
        {
            searchBox.SendKeys(searchText);
        }

        public void WaitForVisibleHintList(IWebDriver driver)
        {
            By hintListXpath = By.XPath("//div[@class='UUbT9']");
            WaitingUtilities.WaitForVisibleElement(driver, hintListXpath);
        }

        public void PressSearchButton()
        {
            searchButton.Click();
        }

        public void OpenCalendar()
        {
            calendar.Click();
        }

        public void NextCalendarPageButtonClick()
        {
            calendarNextMonthBtn.Click();
        }

        public void FindCalendarDate(IWebDriver driver, string year, string month)
        {
            var availableDates = getCurrentCalendarMonthAndYear(driver);
            var neededDate = $"{month} {year}";
            while (availableDates.Contains(neededDate) == false)
            {
                NextCalendarPageButtonClick();
                availableDates = getCurrentCalendarMonthAndYear(driver);
            }
        }

        private List<string> getCurrentCalendarMonthAndYear(IWebDriver driver)
        {
            By CalendarMontCaptionPath = By.XPath("//div[@aria-live='polite' and @class='bui-calendar__month']");
            var elements = driver.FindElements(CalendarMontCaptionPath);
            var dates = new List<string>();
            foreach (var el in elements)
            {
                dates.Add(el.Text);
            }
            return dates;
        }
        /// <summary>
        /// Select data in calendar (Arrival)
        /// </summary>
        /// <param name="driver">driver of test</param>
        /// <param name="date">date in string data type which will be in format: yyyy-mm-dd </param>
        public void setDateInCalendar(IWebDriver driver,string date)
        {
            string xpath = $"//td[@data-date='{date}']";
            By datePath = By.XPath(xpath);
            var pickeDate = driver.FindElement(datePath);
            pickeDate.Click();
        }
    }
}
