using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFinal.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinal.Pages
{
    public class DeleteClientPage
    {
        private IWebDriver _driver;

        public DeleteClientPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement FindDeleteLink => _driver.FindElement(By.XPath("//*[@id='root']/div/div/div[3]/table/tbody/tr/td[6]/a"));
        private IWebElement VerifyPopup => _driver.FindElement(By.XPath("//*[@id='removeQuestion']/div[1]/div[1]/p"));
        private IWebElement ClickConfirmButton => _driver.FindElement(By.XPath("//*[@id='removeQuestion']/div[1]/div[2]/button[1]/b"));
   

     
        public void GetDeleteLink()
        {
           FindDeleteLink.Click();
        }
        public string VerifyPopupText()
        {
            return VerifyPopup.Text;
        }
        public void ClickConfirm()
        {
            ClickConfirmButton.Click();
        }
    }

}

    