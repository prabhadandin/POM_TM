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
        public void NavigateTM(IWebDriver driver)
        {
            //navigate to time and material page
            //Click on administration
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //click on time and material
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();


        }
       
    }
}