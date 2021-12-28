using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAssignment.Page
{
    public class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.ClassName, Using = "login")]
        public IWebElement SignIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title='View my shopping cart']")]
        public IWebElement MyCart { get; set; }


        [FindsBy(How = How.CssSelector, Using ="a[id='button_order_cart']")]
        public IWebElement Checkout { get; set; }

        [FindsBy(How = How.CssSelector, Using = "i.icon-plus")]
        public IWebElement AddIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td[data-title='Unit price']")]
        public IWebElement UnitPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td[data-title='Total']")]
        public IWebElement Total { get; set; }



        [FindsBy(How = How.CssSelector, Using = "a[href='http://automationpractice.com/index.php?controller=order&step=1']")]
        public IWebElement Checkout1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[name='processAddress']")]
        public IWebElement Checkout2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#cgv")]
        public IWebElement Checkbox{ get; set; }


        [FindsBy(How = How.CssSelector, Using = "button[name='processCarrier']")]
        public IWebElement Checkout3 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[name='processAddress']")]
        public IWebElement Checkout4 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.cheque")]
        public IWebElement Pay { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.button.btn.btn-default.button-medium")]
        public IWebElement Confirm { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.logout")]
        public IWebElement logout { get; set; }



    }
}
