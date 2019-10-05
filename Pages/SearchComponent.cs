using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTest.Pages
{
    public class SearchComponent
    {
        protected IWebDriver driver;
        //
        public IWebElement SearchField
        { get { return driver.FindElement(By.Name("q")); } }

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

        public SearchComponent EnterInSearchField(string input_data)
        {
            SearchField.Click();
            SearchField.Clear();
            SearchField.SendKeys(input_data);
            return this;
        }

        //to do class 'ListOfResultSearch'
        public ListOfResultSearch Search(string input_data)
        {
            EnterInSearchField(input_data).SearchField.SendKeys(Keys.Enter);
            
            return new ListOfResultSearch();
        }

    }
}
