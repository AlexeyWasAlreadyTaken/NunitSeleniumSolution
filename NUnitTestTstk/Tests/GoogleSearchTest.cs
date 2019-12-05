using NUnit.Framework;
using NUnitTestTstk;
using NUnitTestTstk.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.IO;
using System.Reflection;
using System.Threading;

/// <summary>
/// ТЕСТОВОЕ ЗАДАНИЕ :
///∙    Сделать тест на C# с использованием Selenium/Webdriver, реализующий следующий сценарий:
///∙        Браузер Chrome открывает стартовую страницу www.google.com;
///∙        В поисковой строке вводится «Selenium IDE export to C#» (без кавычек);
///∙        Нажимается “Search”;
///∙        Проверить что на 4 строке результатов есть фраза Selenium IDE;
///∙        Если фраза найдена, тест считается пройденным успешно, иначе он должен закончиться как failed;
///∙     Применить Page Object, Page Factory и AAA, для поиска элементов использовать XPath;
///∙     Прислать мне этот тест Selenium, в формате Visual Studio solution, который собирается в библиотеку NUnit.
///∙     +
///∙     Применение абстракции будет плюсом.
/// </summary>
namespace GoogleTest
{
    [TestFixture]
    public class GoogleSearchTest
    {
        public IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.google.com");
        }

        [Test]
        public void MyGoogleSearchTest()
        {
            // ARRANGE
            var mainPage = new MainPage();
            PageFactory.InitElements(driver, mainPage);
            var searchResultPage = new SearchResultPage(driver);
            PageFactory.InitElements(driver, searchResultPage);
            // ACT
            mainPage.SetSearchField("Selenium IDE export to C#");
            mainPage.WaitForVisibleHintList(driver);
            mainPage.PressSearchButton();
            // ASSERT
            bool rowExists = searchResultPage.GetNRowWithMessage(driver,4, "Selenium IDE") == null ? false : true;
            Assert.IsTrue(rowExists);
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}





