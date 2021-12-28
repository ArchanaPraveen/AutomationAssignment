using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAssignment.Page
{
    public class AccountCreationPage
    {
        public AccountCreationPage()
        {
            PageFactory.InitElements(Driver.driver, this);

        }
        [FindsBy(How = How.CssSelector, Using = "input[id='id_gender2']")]
        public IWebElement Gender { get; set; }
        [FindsBy(How = How.Id, Using = "customer_firstname")]
        public IWebElement Fname { get; set; }

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        public IWebElement lname { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "days")]
        public IWebElement Date { get; set; }


        [FindsBy(How = How.Id, Using = "months")]
        public IWebElement Months { get; set; }


        [FindsBy(How = How.Id, Using = "years")]
        public IWebElement Year { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        public IWebElement Company { get; set; }

        [FindsBy(How = How.Id, Using = "address1")]
        public IWebElement Address { get; set; }


        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement City{ get; set; }


        [FindsBy(How = How.Id, Using = "id_state")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement Postal { get; set; }

        [FindsBy(How = How.Id, Using = "id_country")]
        public IWebElement Country { get; set; }

        [FindsBy(How = How.Id, Using = "other")]
        public IWebElement AddInfo { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement Homeno { get; set; }

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement Mobile { get; set; }

        [FindsBy(How = How.Id, Using = "alias")]
        public IWebElement AliasAdd { get; set; }

        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement Registerbtn { get; set; }



    }
}
