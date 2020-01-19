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



        [FindsBy(How = How.XPath, Using = "//div[@data-placeholder='Check-in Date']")]
        public IWebElement checkInDatefiled { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-placeholder='Check-out Date']")]
        public IWebElement checkOutDatefiled { get; set; }


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

        public bool datesIsCorrect(string inDate, string outDate)
        {
            string chkInDate = checkInDatefiled.Text;
            string chkOutDate = checkOutDatefiled.Text;

            chkInDate = chkInDate.Substring(chkInDate.IndexOf(' ')+1);
            chkOutDate = chkOutDate.Substring(chkOutDate.IndexOf(' ')+1);

            var checkInCorrect = chkInDate == inDate ? true : false;
            var checkOutCorrect = chkOutDate == outDate ? true : false;

            if (checkInCorrect && checkOutCorrect)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}



