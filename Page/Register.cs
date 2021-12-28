using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAssignment.Page
{
    public class Register
    {
        public Register()
        {
            PageFactory.InitElements(Driver.driver,this);
        }
        [FindsBy(How = How.CssSelector, Using = "input[id='email_create']")]
        public IWebElement EmailId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[id='SubmitCreate']")]
        public IWebElement Create { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement LoginBtn { get; set; }


    }
}
