using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using GoogleTest.Pages;
//using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace GoogleTest.Tests
{
    public abstract class TestRunner
    {
        const string PATH_TO_SCREEN = @"C:\Users\ASUS\source\repos\GoogleTest\Screenshot";
        
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //FOR FIREFOX DRIVER, USING EXISTED PROFILE:

            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\ASUS\Downloads");
            //service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            //FirefoxOptions options = new FirefoxOptions();
            //options.Profile = new FirefoxProfile(@"C:\Users\ASUS\AppData\Roaming\Mozilla\Firefox\Profiles\yfh4ahlc.default-release");

            //driver = new FirefoxDriver(service, options);
            //

            //FOR CHROME:
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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
                TakesScreenshot("FailScreen");
            }
        }

        protected void TakesScreenshot(string name, string filePath = PATH_TO_SCREEN)
        {
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath  + @"\" + name + ".png", ScreenshotImageFormat.Png);
        }


        public HomePage LoadApplication()
        {
            return new HomePage(driver);
        }


        //Explicit wait for screenshot
        public IWebElement WaitForListResultSearchComponent()
        {
            IWebElement result = wait.Until((drv) =>
            {
                //We are waiting for 'AllResponse' button will be displayed
                return new ListResultSearchComponent(drv).AllResponse;
            });
            return result;

        }

    }
}
