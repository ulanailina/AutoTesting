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
    public class SeleniumDropdownDemoTest
    {
        private static SeleniumDropdownDemoPage _page; 

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new SeleniumDropdownDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //_page.CloseBrowser();
        }

        [Test]

        public void TestSeleniumDropdown()
        {
            _page.SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }

        [Test]
        public void TestSeleniumDropdownByIndeks()
        {
            _page.SelectFromDropdownByIndex(2)
                .VerifyResult("Monday");  // o tai cia butinai rasyt zodziu? negalima indekso skaiciuko imest?
        }

        [Test]
        public void TestMultiDropdown()
        {
            _page.SelectFromMultiDropdownByValue("Florida", "Ohio")
                .ClickAllSelectedButton();
        }

        [TestCase("Florida", "New Jersey")]
        [TestCase("Texas, Washington, Florida")]

        public static void TestSelectFromMultiDropdownByValue1(params string[] selectedElements) 
        {
            _page.SelectFromMuiltipleDropdownByValue1(selectedElements.ToList())
            .ClickFirstSelectedButton()
            .ClickAllSelectedButton();

        }

        [TestCase("Florida", "New Jersey", true, false)]
        [TestCase("Texas, Washington, Florida")]

        public void Pabandymas(string firstCity, string secondCity, bool OneSelected, bool AllSelected)
        {
            
        }


    }
}
