using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFinal.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinal.Pages
{
    public class EditClientPage
    {
        private IWebDriver _driver;

        public EditClientPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement ClickClientId => _driver.FindElement(By.XPath("//*[@id='root']/div/div/div[3]/table/tbody/tr/td[1]/a"));
        private IWebElement EditPageTitle => _driver.FindElement(By.TagName("h2"));
        private IWebElement FirstNameInput => _driver.FindElement(By.Name("firstName"));
        private IWebElement LastNameInput => _driver.FindElement(By.Name("lastName"));
        private IWebElement EmailInput => _driver.FindElement(By.Name("email"));
        private IWebElement SaveInput => _driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[22]/div/div/button"));



        public void GetClientID()
        {
            ClickClientId.Click();
        }
        public string VerifyEditTitle()
        {
            return EditPageTitle.Text;
        }
        public void ChangeClient(string fName, string lname, string emailNew)
        {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(fName);
            LastNameInput.Clear();
            LastNameInput.SendKeys(lname);
            EmailInput.Clear();
            EmailInput.SendKeys(emailNew);
        }

        public void ClickSaveButton()
        {
            SaveInput.Click();
        }
    }

}
