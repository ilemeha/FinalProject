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
using AutomationFinal.Methods;
using AutomationFinal.TestData;

namespace AutomationFinal.Tests
{
    [TestFixture]
    public class AddClientPageTest
    {
        [Test]
        public void AddClientTest()
        {
            var loginInfo = new LoginData();

            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl(Config.GetUrl());

                var loginClientPage = new AddClientPage(driver);
                loginClientPage.FillOutLoginData(loginInfo);
                loginClientPage.CheckClientPageTitle().ShouldBe("Clients");

                loginClientPage.ClickAddClient();
                loginClientPage.SelectTeacher("9");
                loginClientPage.TypeClientCompany("FoxNews");
                loginClientPage.FillOutContactInformation("Marina", "Boyko");
                loginClientPage.ChooseState("Iowa");
                loginClientPage.AddressInfo("60622","7733987654", "lemeha@gmail.com");
                loginClientPage.ClickSaveButton();
                loginClientPage.TableClient().ShouldBe("Teacher");
                Thread.Sleep(5000);
            }
        }
    }
}