using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Shouldly;
using AutomationFinal.WebDriver;
using AutomationFinal.Configuration;
using AutomationFinal.Pages;
using AutomationFinal.TestData;
using System.Windows.Forms;
using OpenQA.Selenium.Firefox;


namespace AutomationFinal.Tests
{
    [TestFixture]
    public class AddClientPageTest
    {
        [Test]
        public void AddClientTest()
        {
            var loginInfo = new LoginData();
            var person = new Person();

            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                driver.Navigate().GoToUrl(Config.GetUrl());

                var accessLoginPage = new LoginPage(driver);
                accessLoginPage.FillOutLoginData(loginInfo);
                accessLoginPage.ClickLoginButton();
                accessLoginPage.GetClientPageTitle().ShouldBe("Clients");

                var logClientPage = new AddClientPage(driver);
                logClientPage.ClickAddClient();
                logClientPage.SelectTeacher("9");
                logClientPage.TypeClientCompany("FoxNews");
                logClientPage.FillOutContactInformation(person);
                logClientPage.ChooseState("Iowa");
                logClientPage.AddressInfo(person);
                logClientPage.ZipInfo("60755");

                logClientPage.ClickBrowseButton();
                Thread.Sleep(2000);
                logClientPage.GetFileUrlUploaded(@"C:\Users\Iryna Lemeha\Desktop\Chapter.txt");
                Thread.Sleep(10000);

                logClientPage.ClickSaveButton();
                Thread.Sleep(5000);

                logClientPage.GetFirstName().ShouldBe(person.FirstName);
                logClientPage.GetLastName().ShouldBe(person.LastName);

                Thread.Sleep(5000);
            }
        }
    }
}