using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NUnitTestTstk.PageObjects
{
    class BookingSearchResultsPage
    {
        private IWebDriver driver;
        public int getResultsCount(IWebDriver driver)
        {
            string allHotelsListResult = "//div[@data-hotelid]";
            By by = By.XPath(allHotelsListResult);
            var ResultsListElements = driver.FindElements(by);
            return ResultsListElements.Count;
        }

        public bool AllHotelsInOneCity(IWebDriver driver, string sityName)
        {
            string xpath = $"//div[@data-hotelid]//a[@class='bui-link' and contains(text(),'{sityName}')]";
            By by = By.XPath(xpath);
            var elements = driver.FindElements(by);
            return elements.Count == getResultsCount(driver) ? true : false;
        }
    }
}



