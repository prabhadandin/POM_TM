using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IC_TimeMaterial.Pages
{
    class TMPage

    {
         IWebDriver driver;
        WebDriverWait Wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        public TMPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        IWebElement TypeCode => Wait.Until(driver => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]")));
        IWebElement Code => Wait.Until(driver => driver.FindElement(By.Id("Code")));
        IWebElement Desc => Wait.Until(driver => driver.FindElement(By.Id("Description")));
        IWebElement Price => Wait.Until(driver => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")));
        //IWebElement UploadFile => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
        //IWebElement Fileuploadsucess => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/ul/li/span[3]"));
        IWebElement SaveButton => driver.FindElement(By.Id("SaveButton"));
        IWebElement BackToListPage => Wait.Until(driver=>driver.FindElement(By.XPath("//a[@href='/TimeMaterial']")));
        IList<IWebElement> Tablerows => driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
        IWebElement GridNextPageLink => driver.FindElement(By.XPath("//a[@title='Go to the next page']"));
        //Func<IWebDriver,IWebElement> GridNextPage => driver.FindElement(By.XPath("//a[@title='Go to the next page']")))

        IWebElement CreateButton => driver.FindElement(By.LinkText("Create New"));


        public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public void CrtTM(IWebDriver driver)
        {
            //Click on create new button

            CreateButton.Click();

            //wait
            
            //Click type code drop box
            TypeCode.Click();

            //Enter code value
            Code.SendKeys("ME003");
            //Enter description Value
            Desc.SendKeys("MEchanical");
            //Scroll to Price unit to make visible to 
            Actions action = new Actions(driver);
            action.MoveToElement(Price).Perform();
            //Send price Value
            Price.SendKeys("1213");

            //Select FIle to upload
            // UploadFile.SendKeys("G:/Test.txt");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //checked file Successful Upload
            //click save
            SaveButton.Click();

            BackToListPage.Click();
            var Tablerows_count = Tablerows.Count;

            //check if record created or not
            try
            {
                while (true)
                {
                    for (int i = 1; i <= Tablerows_count; i++)
                    {
                        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                       String RowCodeValue = GetPath(i);
                        if (RowCodeValue.Equals("ME003"))
                        {

                            Console.WriteLine("'REcords succcefully created!,Test Pass");
                            return;
                        }

                    }
                    //Go to next grid page to search an record
                    GridNextPageLink.Click();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Records not Created,Test Failed " + e);
            }

        }

        public string GetPath(int i)
        {
            return Wait.Until(driver=>driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]"))).Text;
        }

        public void EdtTM(IWebDriver driver)
        {    
           var EditRows_Count = Tablerows.Count;

            try
            {
                while (true)

                {
                    for (int i = 1; i <= EditRows_Count; i++)
                    {
                        String EditRowCodeValue = GetPath(i);

                        if (EditRowCodeValue.Equals("edittest"))
                        {
                            //Click on edit button 
                            
                            IWebElement EditClick = GetEditButtonPath(i);
                            EditClick.Click();
                            //Edit the TD values
                            Code.Clear();
                            Code.SendKeys("EditTesting");
                            Desc.Clear();
                            Desc.SendKeys("editdesctesting");

                            //Scroll to Price unit to make visible to 
                            Actions action1 = new Actions(driver);
                            action1.MoveToElement(Price).Perform();
                            Price.Clear();
                            //Send price Value
                            Price.SendKeys("1213");
                            //Select FIle

                            //UploadFile.SendKeys("G:/Test-Copy.txt");
                            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            //Select Download button
                            //driver.FindElement(By.Id("downloadButton")).GetAttribute("Value");
                            // driver.FindElement(By.Id("downloadButton")).Click();

                            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            //Click save
                            SaveButton.Click();

                            // Go to last page
                            //BackToListPage.Click();
                            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            Assert.IsTrue(true);

                            Console.WriteLine("Records updated successfully!,Text Pass");
                            return;
                        }
                    }
                    //Go to next grid page to search an record
                   // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    GridNextPageLink.Click();
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Records not updated, Test Failed" + e);
            }
        }

        private IWebElement GetEditButtonPath(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[5]/a[text()='Edit']"));
        }

        public void DelTM(IWebDriver driver)
        {

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var DelRows_Count = Tablerows.Count;

            try
            {
                while (true)

                {
                    for (int i = 1; i <= DelRows_Count; i++)
                    {
                        //Get the td value of tr[i]th row
                        string DelRow_CodeValue = GetPath(i);

                        if (DelRow_CodeValue.Equals("deltest"))
                        {
                            //Click on delete button 
                            IWebElement DelButton = GetDelButtonPath(i);
                            DelButton.Click();
                           
                           
                            //Switch the control pf 'driver' to ther alert window
                            IAlert altert = driver.SwitchTo().Alert();
                            //get confirmation text
                            String ConfirmationalterText = altert.Text;
                            Console.WriteLine("Confirmation text" + ConfirmationalterText);
                            //to accept the alter(click on ok button)
                            altert.Accept();
                            
                            Assert.IsTrue(true);
                            StringAssert.DoesNotContain("DelCodeValue", "deltest");
                            Console.WriteLine("Records deleted successfully!,Test Pass");
                            return;
                        }
                    }
                    //Go to next grid page to search an record
                    GridNextPageLink.Click();
                    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Records not deleted!,Test fails" + e);
            }
        }

        private IWebElement GetDelButtonPath(int i)
        {
            return Wait.Until(driver=>driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[5]/a[text()='Delete']")));
        }
    }
}

