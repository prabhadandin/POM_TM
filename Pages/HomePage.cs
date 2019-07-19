using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TimeMaterial.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
       IWebElement AdminPage => driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        IWebElement TMCategory => driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));

        public void NavigateTM()
        {
            //navigate to time and material page
            //Click on administration Tab
            AdminPage.Click();

            //click on time and material category
            TMCategory.Click();
            
        }
       
    }
}