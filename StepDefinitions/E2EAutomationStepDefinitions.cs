using AutomationAssignment.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationAssignment
{
    [Binding]
    public class E2EAutomationStepDefinitions
    {
        public List<string> beforePrice = new List<string>();
        //Register user 
        [Given(@"initialize browser with chromedriver")]
        public void GivenInitializeBrowserWithChromedriver()
        {
            Driver.driver = new ChromeDriver();
            Driver.driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("window.scrollTo(0, 300)");
        }

        [Given(@"Navigate to the ""([^""]*)""  site")]
        public void GivenNavigateToTheSite(string p0)
        {
            Driver.driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [When(@"user all the credentials")]
        public void WhenUserAllTheCredentials()
        {
            HomePage homepage = new HomePage();
            homepage.SignIn.Click();
            Register register = new Register();
            register.EmailId.SendKeys("Testing.12356750556@gmail.com");
            register.Create.Click();
            Thread.Sleep(2000);
            AccountCreationPage accountcreate = new AccountCreationPage();
            accountcreate.Gender.Click();
            accountcreate.Fname.SendKeys("Test");
            accountcreate.lname.SendKeys("Testing");
            accountcreate.Password.SendKeys("12356@1");
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
            

        }

        [Then(@"verify user is successfully registered")]
        public void ThenVerifyUserIsSuccessfullyRegistered()
        {
            string value = Driver.driver.Title;
            Assert.AreEqual(value, "My account - My Store");
        }

        //login and select items from navigation bar

        [Given(@"login with ""([^""]*)"" and ""([^""]*)""")]
        public void GivenLoginWithAnd(string p0, string p1)
        {
           
            HomePage homepage = new HomePage();
            homepage.SignIn.Click();
            Thread.Sleep(2000);
            Register register = new Register();
            register.Email.SendKeys(p0);
            register.Password.SendKeys(p1);
        }


        [When(@"select category and type from navigation bar")]
        public void WhenSelectCategoryAndTypeFromNavigationBar(Table table)

        {
            dynamic data = table.CreateDynamicInstance();
            AccountPage accpage = new AccountPage();
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(Driver.driver.FindElement(By.CssSelector("a[title='" + data.category + "']"))).Perform();
            Thread.Sleep(5000);
            Driver.driver.FindElement(By.CssSelector("a[title = '" + data.type + "']")).Click();
           
            
           
        }
        [When(@"Verify the product view")]
        public void WhenVerifyTheProductView(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            Driver.driver.FindElement(By.Id("" + data.view + "")).Click();
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var viewverify = Driver.driver.FindElement(By.CssSelector("div.center-block"));
            if (data.view == "list")
            {
                Assert.IsTrue(viewverify.Displayed);//list view
            }
            else
            {
                Assert.IsFalse(viewverify.Displayed);//grid view
            }
            
        }


        [When(@"navigate to selected option page and select color")]
        public void WhenNavigateToSelectedOptionPageAndSelectColor(Table table)

        {
            dynamic data = table.CreateDynamicInstance();
            Driver.driver.FindElement(By.CssSelector("a[href='http://automationpractice.com/index.php?id_product=1&controller=product#/size-s/color-"+data.color+"']")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("window.scrollTo(0, 300)");        
        }

        [Then(@"add item to cart and continue shopping")]
        public void ThenAddItemToCartAndContinueShopping()
        {
            AccountPage accpage = new AccountPage();
            accpage.AddCart.Click();
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(accpage.Continue)).Click();
        }

       // Search bar and Sorting items verification
        [Given(@"Enter Searchitem on search bar")]
        public void GivenEnterSearchitemOnSearchBar(Table table)
        {
            AccountPage accpage = new AccountPage();
            dynamic data=table.CreateDynamicInstance();
            accpage.SearchBar.SendKeys(data.Searchitem);
            accpage.SearchIcon.Click();
        }

        [When(@"user navigates to searchitem page")]
        public void WhenUserNavigatesToSearchitemPage()
        {
            string value = Driver.driver.Title;
            Assert.AreEqual(value, "Search - My Store");
        }
        
        [When(@"select option in which element has to be sorted")]
        public void WhenSelectOptionInWhichElementHasToBeSorted(Table table)
        {
            IList<IWebElement> beforesort = Driver.driver.FindElements(By.CssSelector("span.price.product-price"));
            List<string> beforePrice = new List<string>();
            foreach (WebElement element in beforesort)
            {
                beforePrice.Add(element.Text);
                
            }

            
        }
        [Then(@"select option in which element has to be sorted and verify")]
        public void ThenSelectOptionInWhichElementHasToBeSortedAndVerify(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            SelectElement sortby = new SelectElement(Driver.driver.FindElement(By.Id("selectProductSort")));
            sortby.SelectByText(""+data.option+"");
            Thread.Sleep(5000);
            IList<IWebElement> aftersort = Driver.driver.FindElements(By.CssSelector("span.price.product-price"));
            List<string> aftersortPrice = new List<string>();
            foreach (WebElement element in aftersort)
            {
                aftersortPrice.Add(element.Text);
            }
            beforePrice.Sort();
            Assert.AreNotEqual(beforePrice, aftersortPrice);

        }


        //Payment validation


        [Given(@"select item and go to homepage")]
        public void GivenSelectItemAndGoToHomepage()
        {
            AccountPage accpage = new AccountPage();
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(accpage.Women).Perform();
            accpage.Tshirts.Click();
            accpage.View.Click();
            Driver.driver.FindElement(By.CssSelector("a[href='http://automationpractice.com/index.php?id_product=1&controller=product#/size-s/color-blue']")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("window.scrollTo(0, 300)");
            accpage.AddCart.Click();
            Thread.Sleep(10000);
            Driver.driver.FindElement(By.CssSelector("span[title='Close window']")).Click();
            Thread.Sleep(5000);



        }

        [Given(@"click on homepage and select checkout")]
        public void GivenClickOnHomepageAndSelectCheckout()
        {
            Driver.driver.FindElement(By.CssSelector("a[title='Return to Home']")).Click();
            Thread.Sleep(5000);
        }

        [When(@"verify payment")]
        public void WhenVerifyPayment()
        {
            AccountPage accpage = new AccountPage();
            HomePage homepage = new HomePage();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;

            Actions action = new Actions(Driver.driver);
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
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(homepage.Checkout1)).Click();

            homepage.Checkout2.Click();
            homepage.Checkbox.Click();
            homepage.Checkout3.Click();
            homepage.Pay.Click();
            homepage.Confirm.Click();
            Thread.Sleep(7000);
            js.ExecuteScript("window.scrollTo(0, 300)");
        }

        [Then(@"signout")]
        public void ThenSignout()
        {
            HomePage homePage = new HomePage();
           homePage.logout.Click();

        }



    }
}
