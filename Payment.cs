using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAssignment
{
    public class Payment
    {
        int Sum = 0;
        public Payment()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "td[id='total_product']")]
        public IWebElement TotalItem { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td[id='total_shipping']")]
        public IWebElement TotalShip { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[id='total_price']")]
        public IWebElement Total { get; set; }



    }
}
