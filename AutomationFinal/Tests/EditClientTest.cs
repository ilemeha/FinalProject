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
    public class EditClientTest
    {
        [Test]
        public void EditClient()
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
                //Thread.Sleep(3000);
                logClientPage.ClickSaveButton();
                logClientPage.TableClient().ShouldBe("Teacher");
                Thread.Sleep(3000);

                var saveId = new DeleteClientPage(driver);
                var clientID = saveId.SaveID();

                //Edit client's first name, last name and email. Save your changes


                var editClient = new EditClientPage(driver);
                string changeFname = "Oksana";
                string changeLname = "Morozko";
                string changeEm = "okmoroska@gmail.com";
                editClient.GetClientID();
                editClient.VerifyEditTitle().ShouldBe("Edit Client");
                editClient.ChangeClient(changeFname,changeLname,changeEm );
                editClient.ClickSaveButton();
                Thread.Sleep(3000);
                //Verify your changes are displayed on the Clients page
                editClient.VerifyFNameChnages().ShouldBe(changeFname);
                editClient.VerifyLNameChnages().ShouldBe(changeLname);



            }
        }

    }
}
