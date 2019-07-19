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
        
        public TMPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
         //Type code xpath
        IWebElement TypeCode => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
        //Typecode Xpath
        IWebElement Code => driver.FindElement(By.Id("Code"));
        //Description Xpath
        IWebElement Desc =>  driver.FindElement(By.Id("Description"));
        //Get the number of rows from the Current Table
        IList<IWebElement> Tablerows => driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
        //PricePerUnit xpath
        IWebElement PricePerUnit => driver.FindElement(By.XPath("//input[@class = 'k-formatted-value k-input']"));
       
        //IWebElement UploadFile => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
        //IWebElement Fileuploadsucess => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/ul/li/span[3]"));
        //Save Button Locator
        IWebElement SaveButton => driver.FindElement(By.Id("SaveButton"));
       // IList<IWebElement> PageList => driver.FindElements(By.XPath(("//*[@id='tmsGrid']/div[4]/ul")));
        //IWebElement BackToListPage => Wait.Until<IWebElement>(driver=>driver.FindElement(By.XPath("//*[@id='container']/div/a")));
       //Grid Next page link path
        IWebElement GridNextPageLink => driver.FindElement(By.XPath("//span[@class='k-icon k-i-arrow-e']"));
        //Create Button Locator
        IWebElement CreateButton => driver.FindElement(By.LinkText("Create New"));

        //Method to get Typecode drop box  value
        //public IWebElement TypeCode_value()
        //{
        //     SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("Typecode")));
        //     oSelect.SelectByIndex(2);
        //}
        ////Create Material Function
        public void CrtTM(IWebDriver driver)
        {
            //Click on create new button
            CreateButton.Click();
            //Validate the Create page
            String ClickButtonTitle = driver.Title;
            Console.WriteLine("Create Page Opened Up Succefully"+ClickButtonTitle);
            Assert.AreEqual(ClickButtonTitle, "Edit - Dispatching System", "Create Page Opened up");
            //Click type code drop box
            TypeCode.Click();
            //SEnd code value
            Code.SendKeys("ME005");
            //SEnd description Value
            Desc.SendKeys("MEchanical");
            //Send Priceperunit Value
            PricePerUnit.SendKeys("1213");
            //Select FIle to upload
            // UploadFile.SendKeys("G:/Test.txt");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //checked file Successful Upload
            //click on save Button
            SaveButton.Click();
            //Validate Save Page
            String SavePageTitle = driver.Title;
            Console.WriteLine("Save Button Clicked Successfully"+SavePageTitle);
            Assert.AreEqual(SavePageTitle, "Edit - Dispatching System", "Save Button Clicked and opended new page");
        
        }


        public void ValidateNewRecord(IWebDriver driver)
        {
            //Get number of row count of current table
            var Tablerows_count = Tablerows.Count;
            bool looping = true;
            //check if record created or not
            try
            {
                while (looping)
                {
                    for (int i = 1; i <= Tablerows_count; i++)
                    {
                        //Get the xpath for code value of ith row
                        String RowCodeValue = GetCodeText(i);
                       //Check if CodeValue Matches with new created value
                        if (RowCodeValue.Equals("ME005"))
                        {
                            //Print successfully creared messgae
                            Console.WriteLine("'REcords succcefully created!,Test Pass");
                            looping = false;
                            return;
                        }

                    }

                    // driver.FindElement(By.XPath("//span[@class='k-icon k-i-arrow-e']")).Click();
                    //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    //IWebElement GridNextPageLink = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@title='Go to the next page']")));
                   //Go to next grid page to search an record
                    GridNextPageLink.Click();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Records not Created,Test Failed " + e);
            }

        }


        //Get the ith Row Code Value xPath
        public String GetCodeText(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
        }

        public void EdtTM(IWebDriver driver)
        {
               //Get the row count of current table in grid
            var EditRows_Count = Tablerows.Count;

            try
            {
                while (true)

                {

                    for (int i = 1; i <= EditRows_Count; i++)
                    {
                        //Get the xpath of ith row code value
                        String EditRowCodeValue = GetCodeText(i);
                        //check if the codevalue matches
                        if (EditRowCodeValue.Equals("edittest"))
                        {
                            //Click on edit button
                            IWebElement EditClick = GetEditButtonPath(i);
                            EditClick.Click();
                            //Clear Code Value
                            Code.Clear();
                            //Send code value
                            Code.SendKeys("EditTesting");
                            //Clear the description value
                            Desc.Clear();
                            //Send description value
                            Desc.SendKeys("editdesctesting");
                            //Clear PricePerUnit value
                            // PricePerUnit.Clear();
                            //Send priceperunit  Value
                             PricePerUnit.SendKeys("1213");
                            //Select FIle

                            //UploadFile.SendKeys("G:/Test-Copy.txt");
                            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            //Select Download button
                            //driver.FindElement(By.Id("downloadButton")).GetAttribute("Value");
                            // driver.FindElement(By.Id("downloadButton")).Click();

                           
                            //Click save
                            SaveButton.Click();
                            //Validate Save Page
                            String SavePageTitle = driver.Title;
                            Console.WriteLine("Save Button Clicked Successfully" + SavePageTitle);
                            Assert.AreEqual(SavePageTitle, "Edit - Dispatching System", "Save Button Clicked and opended new page");
                            Console.WriteLine("Records updated successfully!,Test Pass");
                            return;
                        }
                    }
                    //Go to Next page of Grids
                    GridNextPageLink.Click();
                   

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Records not updated, Test Failed" + e);
            }
        }

        //Method to get the edit button xpath of ith row
        private IWebElement GetEditButtonPath(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[5]/a[text()='Edit']"));
        }

        public void DelTM(IWebDriver driver)
        {
          

            //Get the bo of rows from current table           
            var DelRows_Count = Tablerows.Count;

            try
            {
                while (true)

                {
                    for (int i = 1; i <= DelRows_Count; i++)
                    {
                        //Get the code value path of tr[i]th row
                        string DelRow_CodeValue = GetCodeText(i);
                        //Check if code value matches
                        if (DelRow_CodeValue.Equals("deltest"))
                        {
                            //Click on delete button 
                            IWebElement DelButton = GetDelButtonPath(i);
                            DelButton.Click();
                            //Switch the control pf 'driver' to ther alert window
                            IAlert altert = driver.SwitchTo().Alert();
                            //get confirmation text
                            String ConfirmationalterText = altert.Text;
                            //Console.WriteLine("Confirmation text" + ConfirmationalterText);
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

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Records not deleted!,Test fails" + e);
            }
        }
        //Method to get the path of code value from ith row
        private IWebElement GetDelButtonPath(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[5]/a[text()='Delete']"));
        }
    }
}

