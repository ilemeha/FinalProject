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

        private IWebElement UploadFile => _driver.FindElement(By.ClassName("filepond--label-action"));
        private IWebElement FinishUploadFile => _driver.FindElement(By.XPath("//input[@type='text']"));

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

        public void FillOutContactInformation(Person person)
        {
            FirstNameInput.SendKeys(person.FirstName);
            LastNameInput.SendKeys(person.LastName);           
        }
        public void ChooseState(string stateName)
        {
            StateInput.SelectByText(stateName);
        }
        public void ZipInfo(string zipcode)
        {
            ZipInput.SendKeys(zipcode);

        }
        public void AddressInfo(Person person)
        {
            
            PhoneNumberInput.SendKeys(person.PhoneNumber);
            EmailInput.SendKeys(person.Email);
        }
      

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }
        public string TableClient()
        {
            return VerifyClientTable.Text;
        }
        
        public void UploadDoc()
        {
            UploadFile.Click();
           
        }

        public void FinisheUpl(string fileUrl)
        {
            FinishUploadFile.SendKeys(fileUrl);
        }
    }

}
