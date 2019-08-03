using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectLibrary.AutomationPractice.ContactUs;
using PageObjectLibrary.AutomationPractice.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestSol
{
    [TestClass]
    public class TestClass
    {
        IWebDriver webDriver;

        public TestClass()
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");
        }

        [TestMethod]
        public void MyFirstTest()
        {
            //navigate to automation practice site
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            MenuPage menuPage = new MenuPage(webDriver);
            menuPage.ClickContactUs();

            ContactUsPage contactUsPage = new ContactUsPage(webDriver);
            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "daniel.terceros@gmail.com", "1234", @"C:\File.txt", "my message");
            string actualMessage = contactUsPage.GetConfirmationMessage();
            string expectedMessage = "Your message has been successfully sent to our team."; //expected data

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
