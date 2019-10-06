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
        //"div.ellip"
        public ListResultSearchComponent(IWebDriver driver) : base(driver)
        {
            CheckElements();
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

        //To do for all functionality
    }
}
