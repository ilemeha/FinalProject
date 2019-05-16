using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFinal.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.Firefox;

namespace AutomationFinal.Pages
{
    public class DeleteClientPage
    {
        private IWebDriver _driver;

        public DeleteClientPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //Save Client Id
        private IWebElement SaveClientID => _driver.FindElement(By.XPath("//*[@id='root']/div/div/div[3]/table/tbody/tr/td[1]"));
        //Search the client by the saved client ID
        private IWebElement SearchClientInput => _driver.FindElement(By.XPath("//*[@id='q']"));
        private IWebElement SearchByIDClick => _driver.FindElement(By.XPath("//*[@id='root']/div/div/div[2]/form/button"));

        private IWebElement FindDeleteLink => _driver.FindElement(By.XPath("//*[@id='root']/div/div/div[3]/table/tbody/tr/td[6]/a"));
        private IWebElement VerifyPopup => _driver.FindElement(By.XPath("//*[@id='removeQuestion']/div[1]/div[1]/p"));
        private IWebElement ClickConfirmButton => _driver.FindElement(By.XPath("//*[@id='removeQuestion']/div[1]/div[2]/button[1]/b"));
     
        

        //Method to saved client ID
        public string SaveID()
        {
            return SaveClientID.Text;
        }

        //Click X button in the last cell of the table
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

       
        public void ClientInputBox(string clientId)
        {
            SearchClientInput.SendKeys(clientId);

        }
        public void SearchButton()
        {
            SearchByIDClick.Click();
        }

       
    }

}

    