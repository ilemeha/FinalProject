﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationFinal.Pages
{
    public class LoginLogoutPage
    {
        private IWebDriver _driver;

        public LoginLogoutPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
