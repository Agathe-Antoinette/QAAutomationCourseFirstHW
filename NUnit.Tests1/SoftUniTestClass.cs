using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace NUnit.Tests1
{
    [TestFixture]
    public class SoftUniTestClass
    {
        [Test]
        public void FindQAAutomationCourse()
        {
            using (IWebDriver driver = new FirefoxDriver()) 
            {
                driver.Navigate().GoToUrl("https://softuni.bg");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.EndsWith("Softuni.bg", StringComparison.OrdinalIgnoreCase));
                // TODO use the correct XPath
                driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/nav/div[1]/ul/li[2]/a")).Click();
                wait.Until(d => d.FindElement(By.ClassName("training-dropdown")).GetCssValue("display").Equals("block"));                
                driver.FindElement(By.LinkText("QA Automation - март 2017")).Click();
                //Assert.Equals("QA Automation - март 2017");
                /* TODO Steps to impelement:
                 * 0. wait for the page to reload - the title will be changed
                 * 1. Assert that there are 2 <h1> tags that contaın 'QA Automation - март 2017'
                 */
                wait.Until(d => d.Title.StartsWith("Курс QA Automation", StringComparison.OrdinalIgnoreCase));
                var elementExists = driver.FindElements(By.TagName("<h1>")).Any();
                Assert.AreEqual(elementExists, "QA Automation - март 2017");
            }
        }
    }
}
