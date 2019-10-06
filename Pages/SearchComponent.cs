using OpenQA.Selenium;
using System;
using GoogleTest.Data;

namespace GoogleTest.Pages
{
    public class SearchComponent
    {
        const string FIREFOX_DRIVER_FULL_NAME = "OpenQA.Selenium.Firefox.FirefoxDriver";

        protected IWebDriver driver;

        public IWebElement SearchField
        { get { return driver.FindElement(By.Name("q")); } }
        public IWebElement VirtualKeyboard
        { get { return driver.FindElement(By.CssSelector("span.MiYK0e")); } }
        //'SearchByVoice' is appeared in Firefox, but not in Chrome
        public IWebElement SearchByVoice
        { get { return driver.FindElement(By.CssSelector("span.hb2Smf")); } }

        public SearchComponent(IWebDriver driver)
        {
            this.driver = driver;
            CheckElements();
        }

        private void CheckElements()
        {
            try
            {
                IWebElement temp = SearchField;
                temp = VirtualKeyboard;
                //In Firefoxe don't have voice search
                if(driver.GetType().ToString() != FIREFOX_DRIVER_FULL_NAME)
                {
                    temp = SearchByVoice;
                }
            }
            catch (Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        public string GetTextSearchField()
        {
            return SearchField.Text;
        }

        //Type input_data in search field
        public SearchComponent EnterInSearchField(string input_data)
        {
            SearchField.Click();
            SearchField.Clear();
            SearchField.SendKeys(input_data);
            return this;
        }

        //Type input_data in search field and click Entre
        public ListResultSearchComponent Search(WordForSearchRepository input_data)
        {
            EnterInSearchField(input_data.InputText).SearchField.SendKeys(Keys.Enter);
            return new ListResultSearchComponent(driver);
        }

    }
}
