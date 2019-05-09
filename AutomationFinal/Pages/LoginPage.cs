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
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement LoginInput => _driver.FindElement(By.Id("username"));  
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement ClickLogin => _driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/div/div/button/span"));
        private IWebElement ClientPageTitle => _driver.FindElement(By.TagName("h2"));
        private IWebElement AdminLink => _driver.FindElement(By.LinkText("admin"));
        private IWebElement HoverAdminLink => _driver.FindElement(By.LinkText("admin"));
        private IWebElement LogoutClickLink => _driver.FindElement(By.XPath("//ul[@class='dropdown-menu']//a"));
        private IWebElement LoginCheckTitle => _driver.FindElement(By.TagName("h2"));
        
        public void FillOutLoginData(LoginData logInf)
        {
            LoginInput.SendKeys(logInf.LoginD);
            PasswordInput.SendKeys(logInf.PasswordData);

        }
        public void ClickLoginButton()
        {
            ClickLogin.Click();
        }
        

        public string CheckClientPageTitle()
        {
            return ClientPageTitle.Text;
        }

        public string CheckAdminLink()
        {
            return AdminLink.Text;
        }
        public void ClickLogoutButton()
        {
            HoverAdminLink.Click();
            LogoutClickLink.Click();

        }
        public string CheckLoginPageTitle()
        {
            return LoginCheckTitle.Text;
        }
 
    }
}

