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
    public class CheckBoxSeleniumTest
    {
        private static CheckBoxSeleniumPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/basic-checkbox-demo.html");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new CheckBoxSeleniumPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [Test]
        public void AOneCheckBoxTest()
        {
            _page.ClickOnCheckBox()
            .CheckIsCheckBoxChecked();
        }
     
        [Test]
        public void BMultipleCheckBoxFirstPartTest()
        {
            _page.ClickCheckBoxes()
            .ClickAllCheckBoxes()
            .CheckValueOfButton("Uncheck All");
        }

        [Test]
        public void CCheckIfAllBoxesAreUnchecked()
        {
            _page.UncheckBoxes()
            .CheckIfAllBoxesAreUnchecked();
        }
    }
}
