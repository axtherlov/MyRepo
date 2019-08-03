using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectLibrary.AutomationPractice.ContactUs;
using PageObjectLibrary.AutomationPractice.Menu;
using PageObjectLibrary.Steps.AutomationPractice.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTestSol
{
    [TestClass]
    public class TestClass
    {
        IWebDriver webDriver;
        NavigationSteps navigationSteps;  

        [TestMethod, TestCategory("ContactUs Valid data")]
        public void ContactUsFormIsSentCorrectly()
        {            
            ContactUsPage contactUsPage = navigationSteps.NavigateToContactUs();
            //explicit waiter
            //Thread.Sleep(TimeSpan.FromSeconds(20));

            //explicit waiter with expected conditions

            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "daniel.terceros@gmail.com", "1234", @"C:\File.txt", "my message");
            string actualMessage = contactUsPage.GetConfirmationMessage();
            string expectedMessage = "Your message has been successfully sent to our team."; //expected data

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod, TestCategory("ContactUs Invalid data")]
        public void ContactUsFormIsNotSentWithInvalidData()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");
            //implicit waiter
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            navigationSteps = new NavigationSteps(webDriver);
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [TestCleanup]
        public void TearDown()
        {
            webDriver.Close();
            webDriver.Quit();
        }
    }
}
