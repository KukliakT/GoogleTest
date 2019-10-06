using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTest.Pages
{
    public class TopPart
    {
        protected IWebDriver driver;

        public SearchComponent searchComponent;
        public IWebElement SearchButton
        { get { return driver.FindElement(By.CssSelector("div.rINcab > span")); } }
        public IWebElement AllResponce
        { get { return driver.FindElement(By.CssSelector("div.hdtb-mitem.hdtb-imb span.HF9Klc.ZYMsjf")); } }
        public IWebElement ImagesResponce
        { get { return driver.FindElement(By.XPath("//a[@class='q qs'][contains(text(),'Зображення')]")); } }
        public IWebElement VideosResponce
        { get { return driver.FindElement(By.XPath("//a[@class='q qs'][contains(text(),'Відео')]")); } }
        public IWebElement NewsResponce
        { get { return driver.FindElement(By.XPath("//a[@class='q qs'][contains(text(),'Новини')]")); } }
        public IWebElement MapsResponce
        { get { return driver.FindElement(By.XPath("//a[@class='q qs'][contains(text(),'Карти')]")); } }

        public TopPart(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
            CheckElements();
        }

        private void InitElements()
        {
            //dropdownComponent = null;
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            //IWebElement temp = Currency; // TODO All Web Elements
        }

        public void CkickOnImagesResponce()
        {
            ImagesResponce.Click();
        }
    }
}
