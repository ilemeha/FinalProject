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

		//TODO: this XPath has to be improved.
        private IWebElement ClickLogin => _driver.FindElement(By.XPath("//*[@id='root']/button[type='submit']"));

		//TODO: these two elements have the same locators... Looks weird...
		private IWebElement AdminLink => _driver.FindElement(By.LinkText("admin"));
        private IWebElement HoverAdminLink => _driver.FindElement(By.LinkText("admin"));

        //TODO: these two elements have the same locators... Looks weird...
        private IWebElement LoginCheckTitle => _driver.FindElement(By.XPath("//h2[contains(., 'Login')]"));
		private IWebElement ClientPageTitle => _driver.FindElement(By.XPath("//h2[contains(., 'Clients')]"));

		//TODO: Please rename the element to LogoutLink. The element is just a link, you will click it with a special method. So currently the name of the element is confusing
	    private IWebElement LogoutClickLink => _driver.FindElement(By.XPath("//ul[@class='dropdown-menu']//a"));

		public void FillOutLoginData(LoginData logInf)
        {
            LoginInput.SendKeys(logInf.LoginD);
            PasswordInput.SendKeys(logInf.PasswordData);

        }
        public void ClickLoginButton()
        {
            ClickLogin.Click();
        }


		//TODO: please rename the method to GetClientPageTitle()
		public string CheckClientPageTitle()
        {
            return ClientPageTitle.Text;
        }

		//TODO: please rename the method to Get...
		public string CheckAdminLink()
        {
            return AdminLink.Text;
        }
        public void ClickLogoutButton()
        {
            HoverAdminLink.Click();
            LogoutClickLink.Click();

        }

	    //TODO: please rename the method to Get...
		public string CheckLoginPageTitle()
        {
            return LoginCheckTitle.Text;
        }
 
    }
}

