using NUnitTestTstk.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace NUnitTestTstk
{
    class GoogleMainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@class='gLFyf gsfi']")]
        public IWebElement searchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='btnK']")]
        public IWebElement searchButton { get; set; }

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
    }
}
