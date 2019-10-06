using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace GoogleTest
{
    [TestFixture]
    class SimpleTest
    {
        private static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [TestCase]
        public void TestSearch()
        {
            IWebElement searchField = driver.FindElement(By.Name("q"));
            searchField.Click();
            searchField.Clear();
            searchField.SendKeys("Wikipedia" + Keys.Enter);
            Thread.Sleep(5000);
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/Screenshot1.png", ScreenshotImageFormat.Png);
        }

    }
}
