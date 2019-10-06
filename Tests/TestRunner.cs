using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GoogleTest.Pages;
using OpenQA.Selenium.Firefox;

namespace GoogleTest.Tests
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\ASUS\Downloads");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            FirefoxOptions options = new FirefoxOptions();
            options.Profile = new FirefoxProfile(@"C:\Users\ASUS\AppData\Roaming\Mozilla\Firefox\Profiles\yfh4ahlc.default-release");

            driver = new FirefoxDriver(service, options);
            //
            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public virtual void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public virtual void TearDown()
        {
            string resultMessage = TestContext.CurrentContext.Result.Message;
            if ((resultMessage != null) && (resultMessage.Length > 0))
            {
                Console.WriteLine("TestContext.CurrentContext.Result = " + TestContext.CurrentContext.Result.Message);
            }

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                TakesScreenshot("d:/FailScreen.png");
            }
        }

        protected void TakesScreenshot(string filePath)
        {
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }


        public HomePage LoadApplication()
        {
            return new HomePage(driver);
        }


        //public IWebElement WaitCheckOutLink()
        //{
        //    IWebElement result = wait.Until((drv) =>
        //    {
        //        return LoadApplication().GetCartContainerComponent().CheckOutLink;
        //    });
        //    return result;
        //}

        //public HomePage LoadHomePage()
        //{
        //    driver.Navigate().GoToUrl("http://192.168.17.128/opencart/upload/");
        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //    return new HomePage(driver);

        //}

    }
}
