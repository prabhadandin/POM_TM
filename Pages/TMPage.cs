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

        public void CrtTM(IWebDriver driver)
        {


            //Click on create new button
            driver.FindElement(By.LinkText("Create New")).Click();

            //wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Click type code drop box
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]")).Click();

            //Enter code value
            driver.FindElement(By.Id("Code")).SendKeys("ME003");

            //Enter description Value
            driver.FindElement(By.Id("Description")).SendKeys("MEchanical");

            //Get Price by Xpath
            IWebElement Price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            //Scroll to Price unit to make visible to 
            Actions action = new Actions(driver);
            action.MoveToElement(Price).Perform();
            //Send price Value
            Price.SendKeys("1213");

            //Select FIle to upload
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
            driver.FindElement(By.XPath("//*[@id='files']")).SendKeys("G:/Test.txt");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //checked file Successful Upload
            //IWebElement fileuploadsucess = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/ul/li/span[3]"));
            //click save
            driver.FindElement(By.Id("SaveButton")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Go to last page
            driver.FindElement(By.LinkText("Go to the last page")).Click();
            //check if record created or not
            try
            {
                //getting the number of rows.
                IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
                var row_count = row.Count;

                while (true)
                {
                    for (int i = 1; i <= row_count; i++)
                    {

                        var codevaluerow = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                        //Assert.IsTrue(codevaluerow.Equals("ME003"));
                        // StringAssert.Contains("ME003", codevaluerow, "Records Saved successfully!,Test passed");
                        if (codevaluerow == "ME003")
                        {

                            Console.WriteLine("REcords succcefully created!,Test Pass");
                            return;
                        }

                    }
                    //Go to next grid page to search an record
                    driver.FindElement(By.XPath("//a[@title='Go to the next page']")).Click();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Records not Created,Test Failed " + e);
            }

        }


        public void EdtTM(IWebDriver driver)
        {
            //Explicit wait for driver
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           // bool running = true;
            //Get the total number of rows
            IList<IWebElement> EditRow_Elements = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var EditRows_Count = EditRow_Elements.Count;
            try
            {
                while (true)

                {

                    for (int i = 1; i <= EditRows_Count; i++)
                    {
                        //Get the td value of tr[i]th row
                        var EditingCodeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                        //Check if the code vaue='ME003'  
                        if (EditingCodeValue == "edittest")
                        {
                            //Click on edit button 
                            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[5]/a[text()='Edit']")).Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            //Edit the TD values
                            driver.FindElement(By.XPath("//*[@id='Code']")).Clear();
                            driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys("EditTesting");
                            driver.FindElement(By.XPath("//*[@id='Description']")).Clear();
                            driver.FindElement(By.XPath("//*[@id='Description']")).SendKeys("editdesctesting");

                            //IWebElement EditPrice=driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]']"));
                            //Scroll to Price unit to make visible to 
                            //Actions action1 = new Actions(driver);
                            //action1.MoveToElement(EditPrice).Perform();
                            //EditPrice.Clear();
                            //Send price Value
                            // EditPrice.SendKeys("1213");
                            //Select FIle
                            // driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
                            // driver.FindElement(By.XPath("//*[@id='files']")).SendKeys("G:/Test-Copy.txt");
                            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            //Select Download button
                            //driver.FindElement(By.Id("downloadButton")).GetAttribute("Value");
                            // driver.FindElement(By.Id("downloadButton")).Click();

                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            //Click save
                            driver.FindElement(By.Id("SaveButton")).Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
                            // Go to last page
                            //driver.FindElement(By.LinkText("Go to the last page")).Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                            Assert.IsTrue(true);
                      
                            Console.WriteLine("Records updated successfully!,Text Pass");
                            return;
                        }
                    }
                    //Go to next grid page to search an record
                    driver.FindElement(By.XPath("//a[@title='Go to the next page']")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Records not updated, Test Failed"+e);
            }
        }
      public void DelTM(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Get the total number of rows
            IList<IWebElement> DelRow_Elements = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var DelRows_Count = DelRow_Elements.Count;
            try
            {
                while (true)

                {

                    for (int i = 1; i <= DelRows_Count; i++)
                    {
                        //Get the td value of tr[i]th row
                        var DelCodeValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                        //Check if the code vaue='ME003'  
                        if (DelCodeValue == "123")
                        {
                            //Click on delete button 
                            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[5]/a[@class='k-button k-button-icontext k-grid-Delete']")).Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            //Switch the control pf 'driver' to ther alert window
                            IAlert altert = driver.SwitchTo().Alert();
                            //get confirmation text
                            String ConfirmationalterText = altert.Text;

                            Console.WriteLine("Confirmation text" + ConfirmationalterText);
                            //to accept the alter(click on ok button)
                            altert.Accept();

                            // Go to last page
                            //driver.FindElement(By.LinkText("Go to the last page")).Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                            Assert.IsTrue(true);

                            StringAssert.DoesNotContain("DelCodeValue", "deltest");
                            Console.WriteLine("Records deleted successfully!,Test Pass");
                        }
                    }
                    //Go to next grid page to search an record
                    driver.FindElement(By.XPath("//a[@title='Go to the next page']")).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Records not deleted!,Test fails");
            }
        }

   } 
}

