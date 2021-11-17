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
    public class baigiamasPVZTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://tomasgold.lt/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_driver.Manage().Window.Maximize();
            _driver.FindElement(By.CssSelector("#cookie-1 > div > div > div > div.operations > div")).Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }





    }
}
