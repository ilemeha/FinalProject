using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFinal.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinal.Pages
{
    public class ClientSearchPage
    {
        private IWebDriver _driver;

        public ClientSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement SearchClientInput => _driver.FindElement(By.Id("q"));
        private IWebElement SearchClientClick => _driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement VerifyClientTable1 => _driver.FindElement(By.XPath("//th[.='Teacher']"));
        private IWebElement VerifyClientTable2 => _driver.FindElement(By.XPath("//th[.='First Name']"));
        private IWebElement StudenFirstName => _driver.FindElement(By.XPath("//*[@id='root']/div/div/div[3]/table/tbody/tr/td[3]"));
        private IWebElement StudentLastName => _driver.FindElement(By.XPath("//*[@id='root']/div/div/div[3]/table/tbody/tr/td[4]"));


        public void SearchClientBox(string client)
        {
            SearchClientInput.SendKeys(client);
            
        }
        public void ClickSearchButton()
        {
            SearchClientClick.Click();
        }

        public string VerifyTable1()
        {
            return VerifyClientTable1.Text;
        }
        public string VerifyTable2()
        { 
            return VerifyClientTable2.Text;
        }
        public string StudentFName()
        {
            return StudenFirstName.Text;
        }
        public string StudentLName()
        {
            return StudentLastName.Text;
        }
    }
}

