using IC_TimeMaterial.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

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
            // driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");
            //Read navigate url from Excel file
            driver.Navigate().GoToUrl(ExcelLibHelpers.ReadData(2, "url"));


            //Enter user name using ID
            // Username.SendKeys("hari
            //Reading userid from excel
            Username.SendKeys(ExcelLibHelpers.ReadData(2, "username"));
            //Enter password using ID
            // Password.SendKeys("123123");
            //Readin password from excel
            Password.SendKeys(ExcelLibHelpers.ReadData(2, "password"));

            //Click login button
            LoginButton.Click();
           //Validate if the user had logged in succfully
            Assert.That(LoggedinUser.Text, Is.EqualTo("Hello hari!"));
        }

        
    }
}