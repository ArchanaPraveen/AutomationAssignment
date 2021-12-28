using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAssignment.Page
{
    public  class AccountPage
    {
        public AccountPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
       // List  <string> navigationbar =new List<string>{ "Women","Dresses","T-shirts"};

      
         [FindsBy(How = How.CssSelector, Using = "a[title='Women']")]
        public IWebElement Women { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title='T-shirts']")]
        public IWebElement Tshirts { get; set; }

        [FindsBy(How = How.Id, Using = "list")]
        public IWebElement View{ get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.exclusive")]
        public IWebElement AddCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[title='Continue shopping']")]
        public IWebElement Continue { get; set; }

        [FindsBy(How = How.Id, Using = "search_query_top")]
        public IWebElement SearchBar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[name='submit_search']")]
        public IWebElement SearchIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = "img[title='Printed Chiffon Dress']")]
        public IWebElement DressSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.fancybox-item.fancybox-close")]
        public IWebElement Close { get; set; }

        [FindsBy(How = How.ClassName, Using = "icon-home")]
        public IWebElement Homeicon { get; set; }





    }
}
