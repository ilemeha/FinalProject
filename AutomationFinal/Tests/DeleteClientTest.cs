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
    public class DeleteClientTest
    {
        [Test]
        public void DeleteClient()
        {
            var loginInfo = new LoginData();
            var person = new Person();
            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl(Config.GetUrl());

                //Login to the application
                var accessLoginPage = new LoginPage(driver);
                accessLoginPage.FillOutLoginData(loginInfo);
                accessLoginPage.ClickLoginButton();
                accessLoginPage.CheckClientPageTitle().ShouldBe("Clients");

                //Add a new client (as you did it in test case SST-002)
                var logClientPage = new AddClientPage(driver);
                logClientPage.ClickAddClient();
                logClientPage.SelectTeacher("9");
                logClientPage.TypeClientCompany("FoxNews");
                logClientPage.FillOutContactInformation(person);
                logClientPage.ChooseState("Iowa");
                logClientPage.AddressInfo(person);
                logClientPage.ZipInfo("60755");
                //logClientPage.UploadDoc();
                //logClientPage.FinisheUpl("C:\\Users\\Iryna Lemeha\\Desktop\\Chapter.txt");
                Thread.Sleep(3000);

                logClientPage.ClickSaveButton();
                logClientPage.TableClient().ShouldBe("Teacher");
                Thread.Sleep(3000);

                var deleteClient = new DeleteClientPage(driver);
                var clientID = deleteClient.SaveID();
                deleteClient.GetDeleteLink();
                deleteClient.VerifyPopupText().ShouldBe("Are you sure?");
                Thread.Sleep(3000);
                deleteClient.ClickConfirm();
                Thread.Sleep(5000);

                deleteClient.ClientInputBox(clientID);
                Thread.Sleep(5000);
                deleteClient.SearchButton();
            }
        }
    }
}
