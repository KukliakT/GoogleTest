using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTest.Pages
{
    public class HomePage
    {
        protected IWebDriver driver;
        //
        public IWebElement Logo
        { get { return driver.FindElement(By.Id("hplogo")); } }
        public IWebElement SearchField
        { get { return driver.FindElement(By.Name("q")); } }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
            CheckElements();
        }

        private void InitElements()
        {
            
        }

        private void CheckElements()
        {
            try
            { 
                IWebElement temp = Logo;
                temp = SearchField;
            }
            catch(Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        public Search GetViewCartLinkText()
        {
            return ViewCartLink.Text;
        }

    }
}
