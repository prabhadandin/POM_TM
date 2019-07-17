using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TimeMaterial.Pages
{
    class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        WebDriverWait Wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement Username => Wait.Until(driver => driver.FindElement(By.Id("UserName")));
        IWebElement Password => Wait.Until(driver => driver.FindElement(By.Id("Password")));
        IWebElement LoginButton => driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
        IWebElement LoggedinUser => driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
        public void LoginSteps(IWebDriver driver)
        {
            //Maximize the browser
            driver.Manage().Window.Maximize();

            //Navigate to login page
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");

            //Enter user name using ID
            Username.SendKeys("hari");
            //Enter password using ID
            Password.SendKeys("123123");
            //Click login button
            LoginButton.Click();
           //Validate if the user had logged in succfully
            Assert.That(LoggedinUser.Text, Is.EqualTo("Hello hari!"));
        }

        
    }
}