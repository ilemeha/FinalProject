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
    public class LoginPageTest
    {
        [Test]
        public void LoginTest()
        {
            var loginInfo = new LoginData();

            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl(Config.GetUrl());
                //driver.Navigate().GoToUrl(Config.GetUrl(driver));

                var loginAccessPage = new LoginPage(driver);
                loginAccessPage.FillOutLoginData(loginInfo);
                loginAccessPage.ClickLoginButton();
                loginAccessPage.CheckClientPageTitle().ShouldBe("Clients");
                loginAccessPage.CheckAdminLink().ShouldBe("admin");
                loginAccessPage.ClickLogoutButton();
                loginAccessPage.CheckLoginPageTitle().ShouldBe("Login");

				//TODO: this is useless. Plese remove.
                //Thread.Sleep(5000);
            }
        }
    }
}
