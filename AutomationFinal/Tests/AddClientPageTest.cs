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
            var person = new Person();


            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                driver.Navigate().GoToUrl(Config.GetUrl());

                var accessLoginPage = new LoginPage(driver);
                accessLoginPage.FillOutLoginData(loginInfo);
                accessLoginPage.ClickLoginButton();
                accessLoginPage.CheckClientPageTitle().ShouldBe("Clients");

                var logClientPage = new AddClientPage(driver);
                logClientPage.ClickAddClient();
                logClientPage.SelectTeacher("9");
                logClientPage.TypeClientCompany("FoxNews");
                logClientPage.FillOutContactInformation(person);
                logClientPage.ChooseState("Iowa");
                logClientPage.AddressInfo(person);
                logClientPage.ZipInfo("60755");
                
                logClientPage.UploadDoc();
                Thread.Sleep(20000);
                logClientPage.FinUpl();
                // logClientPage.FinisheUpl("C:\\Users\\Iryna Lemeha\\Desktop\\Chapter.txt");
                Thread.Sleep(20000);

                logClientPage.ClickSaveButton();
                Thread.Sleep(5000);
                logClientPage.TableClient().ShouldBe("Teacher");
                Thread.Sleep(5000);
            }
        }
    }
}