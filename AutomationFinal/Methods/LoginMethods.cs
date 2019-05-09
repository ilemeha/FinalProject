using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFinal.Methods
{
    /*public class LoginMethods
    {
        public static void Login(IWebDriver driver)
        {
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("2VLu=j^ykC");
            driver.FindElement(By.XPath("//*[@id='root']/div/div/form/div[3]/div/div/button/span")).Click();
        }
    }*/
    public class LoginUtilsNonStatic
    {
        public void LoginNonStatic(IWebDriver driver)
        {
                driver.FindElement(By.Id("username")).SendKeys("admin");
                driver.FindElement(By.Id("password")).SendKeys("2VLu=j^ykC");
                driver.FindElement(By.ClassName("input-group")).Click();
        }
        
    }
}
