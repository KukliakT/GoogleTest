using OpenQA.Selenium;
using System;

namespace GoogleTest.Pages
{
    public class HomePage
    {
        protected IWebDriver driver;

        public IWebElement Logo
        { get { return driver.FindElement(By.Id("hplogo")); } }

        public SearchComponent searchComponent;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
            CheckElements();
        }

        private void InitElements()
        {
            searchComponent = new SearchComponent(driver);
        }

        private void CheckElements()
        {
            try
            { 
                IWebElement temp = Logo;
            }
            catch(Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        public ListResultSearchComponent GetListResultSearchComponent()
        {
            return new ListResultSearchComponent(driver);
        }

    }
}
