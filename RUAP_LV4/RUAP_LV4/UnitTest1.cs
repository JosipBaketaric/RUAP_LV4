using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        private String tel;
        private String fax;
        private String email;
        private String postc;
        private String password;

        private void setupRandom()
        {
            Random rnd = new Random();
            tel = rnd.Next(1000, 100000).ToString();
            fax = rnd.Next(1000, 100000).ToString();
            email = "miro" + rnd.Next(100, 1000).ToString() + "@yahoo.com";
            postc = rnd.Next(1000, 100000).ToString();
            password = "pass" + rnd.Next(1000, 100000).ToString();
        }

        [SetUp]
        public void SetupTest()
        {
            setupRandom();
            driver = new FirefoxDriver();
            baseURL = "http://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTest()
        {
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("asdfgh");
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("asdfghj");
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys(email);
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys(tel);
            driver.FindElement(By.Id("input-fax")).Clear();
            driver.FindElement(By.Id("input-fax")).SendKeys(fax);
            driver.FindElement(By.Id("input-company")).Clear();
            driver.FindElement(By.Id("input-company")).SendKeys("sdfgh");
            driver.FindElement(By.Id("input-address-1")).Clear();
            driver.FindElement(By.Id("input-address-1")).SendKeys("asdfghjk");
            driver.FindElement(By.Id("input-address-2")).Clear();
            driver.FindElement(By.Id("input-address-2")).SendKeys("asdfgh");
            driver.FindElement(By.Id("input-city")).Clear();
            driver.FindElement(By.Id("input-city")).SendKeys("asdfgh");
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys(postc);
            new SelectElement(driver.FindElement(By.Id("input-country"))).SelectByText("Tuvalu");

            Thread.Sleep(2000);

            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByText("Nanumanga");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys(password);
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys(password);
            driver.FindElement(By.Name("agree")).Click();

            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
       

            driver.FindElement(By.LinkText("Continue")).Click();
            
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
