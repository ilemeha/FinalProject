using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFinal.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationFinal.Pages
{
    public class AddClientPage
    {
        private IWebDriver _driver;

        public AddClientPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement LoginInp => _driver.FindElement(By.Id("username"));
        private IWebElement PasswordInp => _driver.FindElement(By.Id("password"));
        private IWebElement ClickLoginButton => _driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/div/div/button/span"));
        private IWebElement ClientPageHead => _driver.FindElement(By.TagName("h2"));


        private IWebElement ClickAddClientLink => _driver.FindElement(By.LinkText("Add Client"));
        private SelectElement TeacherDropdown => new SelectElement(_driver.FindElement(By.Name("teacherId")));
        private IWebElement AddClientCompany => _driver.FindElement(By.Name("company"));

        private IWebElement FirstNameInput => _driver.FindElement(By.Name("firstName"));
        private IWebElement LastNameInput => _driver.FindElement(By.Name("lastName"));
        private SelectElement StateInput => new SelectElement(_driver.FindElement(By.Name("state")));
        private IWebElement ZipInput => _driver.FindElement(By.Name("zipCode"));
        private IWebElement PhoneNumberInput => _driver.FindElement(By.Name("phoneNumber"));
        private IWebElement EmailInput => _driver.FindElement(By.Name("email"));
        private IWebElement SaveButton => _driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[22]/div/div/button"));
        private IWebElement VerifyClientTable => _driver.FindElement(By.XPath("//th[.='Teacher']"));

        public void FillOutLoginData(LoginData logInf)
        {
            LoginInp.SendKeys(logInf.LoginD);
            PasswordInp.SendKeys(logInf.PasswordData);
            ClickLoginButton.Click();
        }

        public string CheckClientPageTitle()
        {
            return ClientPageHead.Text;
        }
        public void ClickAddClient()
        {
            ClickAddClientLink.Click();
        }
        public void SelectTeacher(string teacherChoice)
        {
            TeacherDropdown.SelectByValue(teacherChoice);
        }
        public void TypeClientCompany(string companyN)
        {
            AddClientCompany.SendKeys(companyN);
        }

        public void FillOutContactInformation(string personF, string personL)
        {
            FirstNameInput.SendKeys(personF);
            LastNameInput.SendKeys(personL);           
        }
        public void ChooseState(string stateName)
        {
            StateInput.SelectByText(stateName);
        }

        public void AddressInfo(string zipcode, string phone, string email)
        {
            ZipInput.SendKeys(zipcode);
            PhoneNumberInput.SendKeys(phone);
            EmailInput.SendKeys(email);
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }
        public string TableClient()
        {
            return VerifyClientTable.Text;
        }
    }

}
