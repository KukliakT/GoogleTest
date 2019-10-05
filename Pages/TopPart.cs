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
    }
}
