using AutomationAssignment.Page;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AutomationAssignment
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            Driver.driver = new ChromeDriver();
            Driver.driver.Manage().Window.Maximize();
            Driver.driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("window.scrollTo(0, 300)");

        }

        [Test]
        public void Test1()
        {

            HomePage homepage = new HomePage();
            homepage.SignIn.Click();

            Register register = new Register();
            register.EmailId.SendKeys("Testing.12345677766@gmail.com");
            register.Create.Click();
            Thread.Sleep(2000);
            AccountCreationPage accountcreate = new AccountCreationPage();
            accountcreate.Gender.Click();
            accountcreate.Fname.SendKeys("Test");
            accountcreate.lname.SendKeys("Testing");
            accountcreate.Password.SendKeys("123@1");
            accountcreate.Date.Click();
            SelectElement dateselect = new SelectElement(accountcreate.Date);
            dateselect.SelectByValue("7");
            accountcreate.Months.Click();
            accountcreate.Months.SendKeys("March");
            accountcreate.Year.Click();
            SelectElement yearselect = new SelectElement(accountcreate.Year);
            yearselect.SelectByIndex(25);
            accountcreate.Company.SendKeys("QT");
            accountcreate.Address.SendKeys("New Address");
            accountcreate.City.SendKeys("Bangalore");
            accountcreate.State.Click();
            accountcreate.State.SendKeys("Maryland");
            accountcreate.Postal.SendKeys("00000");
            accountcreate.AddInfo.SendKeys("dsubsdufdsjfbdsufsdjkfbsdjkfbsdug");
            accountcreate.Homeno.SendKeys("1234567899");
            accountcreate.Mobile.SendKeys("1122334455");
            accountcreate.AliasAdd.SendKeys("new alias address");
            accountcreate.Registerbtn.Click();
            string value = Driver.driver.Title;
            Assert.AreEqual(value, "My account");


        }

        [Test]
        public void Test2()
        {
            HomePage homepage = new HomePage();
            homepage.SignIn.Click();
            Register register = new Register();
            register.Email.SendKeys("Testing.12345@gmail.com");
            register.Password.SendKeys("123@1");
            register.LoginBtn.Click();


        }
        [Test]
        public void Test3()
        {
            HomePage homepage = new HomePage();
            homepage.SignIn.Click();
            Register register = new Register();
            register.Email.SendKeys("Testing.12345@gmail.com");
            register.Password.SendKeys("123@1");
            register.LoginBtn.Click();
            AccountPage accpage = new AccountPage();
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(accpage.Women).Perform();
            accpage.Tshirts.Click();
            accpage.View.Click();
            var viewverify = Driver.driver.FindElement(By.CssSelector("div.center-block "));
            Assert.IsTrue(viewverify.Displayed);
            Driver.driver.FindElement(By.CssSelector("a[href='http://automationpractice.com/index.php?id_product=1&controller=product#/size-s/color-blue']")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("window.scrollTo(0, 300)");
            accpage.AddCart.Click();
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(accpage.Continue)).Click();
            accpage.SearchBar.SendKeys("dresses");
            accpage.SearchIcon.Click();

            //sorting
            var beforesort = Driver.driver.FindElements(By.CssSelector("span.price.product-price"));
            List<string> beforePrice = new List<string>();
            foreach (WebElement element in beforesort)
            {
                beforePrice.Add(element.Text);
                beforePrice.Sort();



            }



            SelectElement sortby = new SelectElement(Driver.driver.FindElement(By.Id("selectProductSort")));
            sortby.SelectByText("Price: Lowest first");
            Thread.Sleep(5000);
            var aftersort = Driver.driver.FindElements(By.CssSelector("span.price.product-price"));
            List<string> aftersortPrice = new List<string>();
            foreach (WebElement element in aftersort)
            {
                aftersortPrice.Add(element.Text);

                Console.WriteLine(aftersortPrice.ToString());


            }

            Assert.AreNotEqual(beforePrice, aftersortPrice);

            accpage.DressSelect.Click();


            Thread.Sleep(15000);
            //obj3.Close.Click();
            js.ExecuteScript("window.scrollTo(0,0)");
            accpage.Homeicon.Click();
            Thread.Sleep(5000);
            action.MoveToElement(homepage.MyCart).Perform();
            homepage.Checkout.Click();
            homepage.AddIcon.Click();
            //payment validation
            Payment payment = new Payment();
            var totalitem = payment.TotalItem.Text.Split("$");
            double totalitem1 = Convert.ToDouble(totalitem[1]);
            var tax = payment.TotalShip.Text.Split("$");
            double tax1 = Convert.ToDouble(tax[1]);
            var total = payment.Total.Text.Split("$");
            Double totalsum = Convert.ToDouble(total[1]);
            Double Sum = totalitem1 + tax1;
            Assert.AreEqual(Sum, totalsum);


            js.ExecuteScript("window.scrollTo(0, 1000)");
            wait.Until(ExpectedConditions.ElementToBeClickable(homepage.Checkout1)).Click();

            homepage.Checkout2.Click();
            homepage.Checkbox.Click();
            homepage.Checkout3.Click();
            homepage.Pay.Click();
            homepage.Confirm.Click();
            Thread.Sleep(7000);
            js.ExecuteScript("window.scrollTo(0, 300)");
            homepage.logout.Click();







        }
    }
    }
