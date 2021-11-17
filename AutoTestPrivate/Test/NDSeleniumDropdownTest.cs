using AutoTestPrivate.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestPrivate.Test
{
    public class NDSeleniumDropdownTest
    {
        private static NDSeleniumDropdownPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new NDSeleniumDropdownPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //_page.CloseBrowser();
        }


        [Test]   // kodas teisingas, testas failina, nes rodo antra valstija
        public void TestSelectTwoStatesFromMultiDropdown()
        {
            _page.SelectFromMultiDropdownTwoStatesByValue("New Jersey", "Florida")
                .ClickButtonFirstSelected()
                .VerifyIfFirstSelected("New Jersey");
        }


        [Test]   // tinklapyj, paspaudus mygtuka, rodo tik antra valstija
        public void TestSelectTwoStatesFromMultiDropdown1()
        {
            _page.SelectFromMultiDropdownTwoStatesByValue("New Jersey", "Ohio")
                .ClickButtonGetAllSelected()
                .VerifyIfAllSelectedOfTwoValues("New Jersey", "Ohio");
        }


        [Test]   // tinklapyj, paspaudus mygtuka, rodo tik paskutine valstija - Washington
        public void SelectThreeStatesFromMultiDropdown()
        {
            _page.SelectFromMultiDropdownThreeStatesByValue("Florida", "Texas", "Washington")
                .ClickButtonFirstSelected()
                .VerifyIfFirstSelected("Florida");
        }


        [Test]  // tinklapyj, paspaudus mygtuka, rodo tik paskutine valstija - Ohio
        public void SelectForStatesFromMultiDropdown()
        {
            _page.SelectFromMultiDropdownFourStatesByValue("Florida", "Texas", "Washington", "Ohio")
                .ClickButtonGetAllSelected()
                .VerifyIfAllSelectedOfFourValues("Florida", "Texas", "Washington", "Ohio");
        }
    }
}
