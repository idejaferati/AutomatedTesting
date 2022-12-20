using AcceptanceQA.Pages;
using AcceptanceQA.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace AcceptanceQA.Tests
{
    class SignUpTest
    {
        public static IWebDriver _driver;
        public static SignUpPage _page;

        public SignUpTest()
        {
            BrowserUtils.WaitFor(3);
            _driver = Driver.Get();
            _page = new SignUpPage(_driver);
            _driver.Manage().Window.Maximize();
            _page.Navigate();
        }

        [Test]
        public void FillSignUpFormTest()
        {
            BrowserUtils.WaitFor(3);
            BrowserUtils.ScrollToElement(_page.SignUpFirstNameElement);
            BrowserUtils.WaitFor(3);
            _page.FillSignUpFirstName(_page.UserFirstName);
            _page.FillSignUpLastName(_page.UserLastName);
            _page.FillSignUpGender(_page.UserGender);
            _page.FillSignUpBirthDate(_page.UserBirthDate);
            _page.FillSignUpEmail(_page.UserEmail);
            _page.FillSignUpPassword(_page.UserPassword);
            _page.FillSignUpMunicipality(_page.UserMunicipality);
            BrowserUtils.WaitFor(3);
            _page.ClickSignUpBtn();
            BrowserUtils.WaitFor(3);
            Assert.AreEqual("Given email already is registered!", _page.ErrorLabelText().ToString());
        }


        [TearDown]
        public void EndTest()
        {
            Task.Delay(10 * 1000).ContinueWith((_) => _driver.Close());
        }
    }
}