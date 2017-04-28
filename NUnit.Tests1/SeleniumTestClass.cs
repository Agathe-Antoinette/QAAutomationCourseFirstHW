using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace NUnit.Tests1
{
    [TestFixture]
    public class SeleniumTestClass
    {
        public object Find { get; private set; }

        [Test]
        public void FirstSeleniumTest()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://www.google.com");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("selenium");
                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("selenium", StringComparison.OrdinalIgnoreCase));

                // Should see: "Cheese - Google Search" (for an English locale)
                Console.WriteLine("Page title is: " + driver.Title);

                driver.FindElement(By.XPath("//div[contains(@class,'mw')]//h3/a")).Click();
                //TODO Assert the page title

                var title = driver.FindElements(By.Name("title"));
                Assert.AreEqual(title, "Google");
            }
        }
    }
}