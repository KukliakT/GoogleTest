using OpenQA.Selenium;
using System;


namespace GoogleTest.Pages
{
    public class ServicesComponent
    {
        protected IWebDriver driver;

        public IWebElement AccountServiceButton
        { get { return driver.FindElement(By.XPath("//span[@class='Rq5Gcb' and contains(text(),'Аккаунт')]")); } }

        public ServicesComponent(IWebDriver driver)
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
                IWebElement temp = AccountServiceButton;
            }
            catch (Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        //TO DO Account class
        //public Account ClickOnAccountService()
        //{
        //    AccountServiceButton.Click();
        //}


    }
}
