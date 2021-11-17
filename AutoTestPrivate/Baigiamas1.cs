using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestPrivate
{
    class Baigiamas1
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://tomasgold.lt/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.CssSelector("#cookie-1 > div > div > div > div.operations > div")).Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }

        [Test]
        public static void APrisijungimas()  // Login geriau i onetimesetup idet
        {
            IWebElement buttonLoginEntry = _driver.FindElement(By.CssSelector("#header-right > a"));
            buttonLoginEntry.Click();
            IWebElement loginInput = _driver.FindElement(By.Id("input-email"));
            loginInput.Click();
            loginInput.SendKeys("ulanaitee.lina@gmail.com");
            IWebElement passwordInput = _driver.FindElement(By.Id("input-password"));
            passwordInput.SendKeys("TomasGold");
            IWebElement buttonLoginComfirm = _driver.FindElement(By.CssSelector("#content > div > div:nth-child(2) > div > form > input.btn.btn-primary"));
            buttonLoginComfirm.Click();

            //assert
        }


        [Test]

        public static void BChangeAddress()
        {
            IWebElement buttonToChangeAddress = _driver.FindElement(By.CssSelector("#content > ul:nth-child(2) > li:nth-child(3) > a"));
            buttonToChangeAddress.Click();
            IWebElement buttonToEditAddress = _driver.FindElement(By.CssSelector("#content > table > tbody > tr > td.text-right > a.btn.btn-info"));
            buttonToEditAddress.Click();
            IWebElement buttonToCelectCity = _driver.FindElement(By.Id("input-address-1"));
            buttonToCelectCity.Clear();
            buttonToCelectCity.SendKeys("Taikos 20");
            IWebElement buttonToContinueAfterChangingAddress = _driver.FindElement(By.CssSelector("#content > form > div > div.pull-right > input"));
            buttonToContinueAfterChangingAddress.Click();
        }

        //[Test]

        //public static void SelectZiedai()
        //{
        //    IWebElement buttonZiedai = _driver.FindElement(By.XPath("//*[@id='megamenu'73388720']/div[2]/div/div/ul/li[1]/a/span/strong"));
        //    buttonZiedai.Click();
        //}


        [Test]

        public static void CSearchField()
        {
            IWebElement searchInput = _driver.FindElement(By.Id("search_query"));
            searchInput.Clear();
            searchInput.SendKeys("auskarai");
            IWebElement buttonSearch = _driver.FindElement(By.CssSelector("#header-right > div.search_form > div"));
            buttonSearch.Click();
        }

        [Test]

        public static void DSelectAukarai()
        {
            IWebElement selectAuskaraiClick = _driver.FindElement(By.CssSelector("#mfilter-content-container > div.product-grid.active > div:nth-child(1) > div:nth-child(1) > div > div.right > div.only-hover > ul > li > a > i"));
            selectAuskaraiClick.Click();
        }  


        //  ar testai turi buti susije? eiti paeiliui, nes pas mane paeiliui eina.
        // ta prasme pvz antras testas be pirmo neivyks
        // kaip daryt su Page, jei i kita psl pereina testo metu. 
    }
}
