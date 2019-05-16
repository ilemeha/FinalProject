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

namespace AutomationFinal.Tests
{
    [TestFixture]
    public class ClientSearchTest
    {
        [Test]
        public void ClientSearch()
        {
            var loginInfo = new LoginData();

            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl(Config.GetUrl());

                var accessLoginPage = new LoginPage(driver);
                accessLoginPage.FillOutLoginData(loginInfo);
                accessLoginPage.ClickLoginButton();
                accessLoginPage.CheckClientPageTitle().ShouldBe("Clients");

                var clientSearchPage = new ClientSearchPage(driver);
                clientSearchPage.SearchClientBox("ilka@mailinator.com");
                clientSearchPage.ClickSearchButton();
                clientSearchPage.VerifyTable1().ShouldBe("Teacher");
                clientSearchPage.VerifyTable2().ShouldBe("First Name");
                clientSearchPage.StudentFName().ShouldBe("Iryna");
                clientSearchPage.StudentLName().ShouldBe("Shch");
            }
        }
    }
}
