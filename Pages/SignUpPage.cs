using AcceptanceQA.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AcceptanceQA.Pages
{
    class SignUpPage
    {
        private readonly IWebDriver _driver;
        private readonly string URI = ConfigurationProperties.url;
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGender { get; set; }
        public string UserBirthDate { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserMunicipality { get; set; }

        /*
        // another way for form data 
        public readonly string UserFirstName = ConfigurationProperties.firstName;
        public readonly string UserLastName = ConfigurationProperties.lastName;
        public readonly string UserGender = ConfigurationProperties.gender;
        public readonly string UserBirthDate = ConfigurationProperties.birthDate;
        public readonly string UserEmail = ConfigurationProperties.userEmail;
        public readonly string UserPassword = ConfigurationProperties.userPassword;
        public readonly string UserMunicipality = ConfigurationProperties.municipality;
         */

        //SignUp
        //find elements using unique properties
        public IWebElement SignUpFirstNameElement => _driver.FindElement(By.Name("firstName"));
        private IWebElement SignUpLastNameElement => _driver.FindElement(By.Name("lastName"));
        private IList<IWebElement> SignUpGenderElements => _driver.FindElements(By.XPath("//label[@class='form-check-label']"));
        private IWebElement ErrorLabel => _driver.FindElement(By.XPath("//form[@id='signupVol']/div/p"));
        private IWebElement SignUpBirthDateElement => _driver.FindElement(By.Name("dateOfBirth"));
        private IWebElement SignUpEmailElement => _driver.FindElement(By.Name("email"));
        private IWebElement SignUpPasswordElement => _driver.FindElement(By.Name("password"));
        private IWebElement SignUpMunicipalityElement => _driver.FindElement(By.Name("municipality"));
        public IWebElement SignUpBtnElement => _driver.FindElement(By.XPath("//button[@type='submit']"));


        public SignUpPage(IWebDriver driver)
        {
            _driver = driver;
            Config txtReader = new Utilities.TextReader().GetData();

            UserFirstName = txtReader.firstName;
            UserLastName = txtReader.lastName;
            UserGender = txtReader.gender;
            UserBirthDate = txtReader.birthDate;
            UserEmail = txtReader.userEmail;
            UserPassword = txtReader.userPassword;
            UserMunicipality = txtReader.municipality;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);

        // SignUp
        public void FillSignUpFirstName(string firstName) => SignUpFirstNameElement.SendKeys(firstName);
        public void FillSignUpLastName(string lastName) => SignUpLastNameElement.SendKeys(lastName);
        public void FillSignUpGender(string type) => SignUpGenderElements.ToList().Find(gender => gender.Text.Equals(type))?.Click();
        public void FillSignUpBirthDate(string birthDate) => SignUpBirthDateElement.SendKeys(birthDate);
        public void FillSignUpEmail(string email) => SignUpEmailElement.SendKeys(email);
        public void FillSignUpPassword(string password) => SignUpPasswordElement.SendKeys(password);
        public void FillSignUpMunicipality(string municipality)
        {
            SelectElement dropDown = new(SignUpMunicipalityElement);
            dropDown.SelectByText(municipality);
        }
        public void ClickSignUpBtn() => SignUpBtnElement.Click();
        public string ErrorLabelText() => ErrorLabel.Text;

    }
}