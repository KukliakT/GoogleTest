using GoogleTest.Pages;
using GoogleTest.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleTest.Tests
{
    [TestFixture]
    class SearchTest : TestRunner
    {
        [TestCase]
        public void SimpleSearchTest()
        {
            HomePage homePage = LoadApplication();
            homePage.searchComponent.Search(WordForSearchRepository.GetWiki());
            Thread.Sleep(4000);   //Only for presentation
            TakesScreenshot("d:/ WikiResult.png");
            Thread.Sleep(4000);   //Only for presentation
            
        }
    }
}
