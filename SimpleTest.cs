using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/Screenshot1.png", ScreenshotImageFormat.Png);
        }

    }
}
