using OpenQA.Selenium;
using System;

namespace GoogleTest.Pages
{
    public class TopPart
    {
        protected IWebDriver driver;

        public SearchComponent searchComponent;
        public IWebElement SearchButton
        { get { return driver.FindElement(By.CssSelector("div.rINcab > span")); } }
        public IWebElement AllResponse
        { get { return driver.FindElement(By.CssSelector("div.hdtb-mitem.hdtb-imb span.HF9Klc.ZYMsjf")); } }
        
        //Only for russian localiation:
        public IWebElement ImagesResponse
        { get { return driver.FindElement(By.XPath("//div[@id='hdtb-msb']//a[contains(text(),'Картинки')]")); } }
        public IWebElement VideosResponse
        { get { return driver.FindElement(By.XPath("//div[@id='hdtb-msb']//a[contains(text(),'Видео')]")); } }
        public IWebElement NewsResponse
        { get { return driver.FindElement(By.XPath("//div[@id='hdtb-msb']//a[contains(text(),'Новости')]")); } }
        public IWebElement MapsResponse
        { get { return driver.FindElement(By.XPath("//div[@id='hdtb-msb']//a[contains(text(),'Карты')]")); } }
        //

        public TopPart(IWebDriver driver)
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
                IWebElement temp = SearchButton;
                temp = AllResponse;
                temp = MapsResponse;
                temp = VideosResponse;
                temp = NewsResponse;
                temp = ImagesResponse;
            }
            catch (Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        public void CkickOnImagesResponse()
        {
            ImagesResponse.Click();
        }

        public void CkickOnVideosResponse()
        {
            VideosResponse.Click();
        }

        //To do for all functionality
    }
}
