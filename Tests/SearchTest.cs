using GoogleTest.Pages;
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

            homePage.searchComponent.Search("Allo");
            Thread.Sleep(4000);   //Only for presentation
            
        }
    }
}
