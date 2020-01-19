using NUnit.Framework;
using NUnitTestTstk;
using NUnitTestTstk.PageObjects;
using NUnitTestTstk.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.IO;
using System.Reflection;
using System.Threading;

namespace NUnitTestTstk.Tests
{
    [TestFixture]
    class BookingTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.booking.com/");
        }

        [Test]
        public void MyBookingTest()
        {
            // ARRANGE
            var mainPage = new BookingMainPage();
            PageFactory.InitElements(driver, mainPage);
            var results = new BookingSearchResultsPage();
            PageFactory.InitElements(driver, results);
            var resultPageHotelsContainerPath = "//div[@data-hotelid]";
            // ACT
            mainPage.openLanguageSelector();
            mainPage.setEnglishLocalization(driver);
            mainPage.SetSearchField("New York");
            mainPage.OpenCalendar();
            mainPage.FindCalendarDate(driver,"2020","May");
            mainPage.setDateInCalendar(driver,"2020-05-01");
            mainPage.setDateInCalendar(driver, "2020-05-30");
            mainPage.PressSearchButton();
            Utilities.WaitingUtilities.WaitForVisibleElement(driver,By.XPath(resultPageHotelsContainerPath));
            var allHotelsInSpecifiedCity = results.AllHotelsInOneCity(driver,"New York");
            var dateIsCorrect = results.datesIsCorrect("May 1, 2020", "May 30, 2020");
            // ASSERT
            Assert.IsTrue(allHotelsInSpecifiedCity && dateIsCorrect);
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
