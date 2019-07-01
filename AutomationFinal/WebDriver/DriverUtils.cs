using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using AutomationFinal.Configuration;

namespace AutomationFinal.WebDriver
{
    public class DriverUtils
    {
        public static IWebDriver CreateWebDriver()
        {
            string browser = Config.GetBrowser();
            if(browser =="Chrome")
            {
                return new ChromeDriver();
            }
            else if(browser== "FireFox")
            {
          

               return new FirefoxDriver();
            }
            else if (browser == "IE")
            {
                return new InternetExplorerDriver();
            }
            else
            {
                throw new InvalidOperationException("Browser is not suported");
            }
        }
    }
}
