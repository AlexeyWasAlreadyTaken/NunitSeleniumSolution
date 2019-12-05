using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestTstk.Utilities
{
    public static class WaitingUtilities
    {
        public static void WaitForVisibleElement(IWebDriver driver, By by)
        {
            By hintListXpath = by;
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(hintListXpath));
        }
    }
}
