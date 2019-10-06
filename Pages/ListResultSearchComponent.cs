using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace GoogleTest.Pages
{
    public class ListResultSearchComponent : TopPart
    {
        //list of title search responces
        public IList<IWebElement> ListResponse
        { get; set; }

        public ListResultSearchComponent(IWebDriver driver) : base(driver)
        {
            InitElements();
            CheckElements();
        }

        private void InitElements()
        {
            ListResponse = driver.FindElements(By.CssSelector("div.ellip"));
        }

        private void CheckElements()
        {
            try
            {
                IList<IWebElement> temp = ListResponse;
            }
            catch (Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        //Get the list of titles(as string)
        public IList<string> GetListResponseTitle()
        {
            IList<string> result = new List<string>();
            foreach (IWebElement current in ListResponse)
            {
                result.Add(current.Text);
                Console.WriteLine(current.Text);
            }
            return result;
        }

        //To do for all functionality
    }
}
