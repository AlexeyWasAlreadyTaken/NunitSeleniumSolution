﻿using System;
using NUnit.Framework;
using NUnitTestTstk.CustomExeptions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace NUnitTestTstk.Pages
{
    class GoogleSearchResultPage
    {
        private IWebDriver driver;

        public GoogleSearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement GetNRowWithMessage(IWebDriver driver, int row, string message)
        {
            By currentRowXpath = By.XPath($"//div[@class='srg']//div[@class='g'][{row}]//*[contains(text(),'{message}')]");
            return driver.FindElement(currentRowXpath);
        }
    }
}
