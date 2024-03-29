﻿using GoogleTest.Pages;
using GoogleTest.Data;
using NUnit.Framework;
using System.Linq;

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

            //The method with explicit wait for making a screenshot
            WaitForListResultSearchComponent();

            //TakeScreenshot can consist two parameters: Name of screenshot and path where it will be saved
            TakesScreenshot("Result SimpleSearchTest()");

            Assert.IsTrue(homePage.GetListResultSearchComponent().GetListResponseTitle().
                Any(title => title.Contains(WordForSearchRepository.GetWiki().ToString())));
        }
    }
}
