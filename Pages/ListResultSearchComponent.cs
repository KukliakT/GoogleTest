using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTest.Pages
{
    public class ListResultSearchComponent : TopPart
    {
        public IList<IWebElement> ListResponce
        { get; set; }

        public ListResultSearchComponent(IWebDriver driver) : base(driver)
        {
            InitElements();
            CheckElements();
        }

        private void InitElements()
        {
            ListResponce = driver.FindElements(By.CssSelector("div.ellip"));
        }

        private void CheckElements()
        {
            try
            {
                //IWebElement temp = SearchField;
            }
            catch (Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        public IList<string> GetListResponceTitle()
        {
            IList<string> result = new List<string>();
            foreach (IWebElement current in ListResponce)
            {
                result.Add(current.Text);
                Console.WriteLine(current.Text);
            }
            return result;
        }

        //To do for all functionality
    }
}
