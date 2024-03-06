using System;
using BugzillaWebDriver.ComponentHelper;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Controle_David.StepDefinitions
{
    [Binding]
    public class CreditCardValidatorStepDefinitions
    {

        [Given(@"credit card number is sixteen digits long")]
        public void GivenCreditCardNumberIsSixteenDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "1234567890159485");
        }

        [Given(@"expiration date is at format MM/YYYY")]
        public void GivenExpirationDateIsAtFormatMMYYYY()
        {
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), "12/2025");
        }

        [Given(@"cvc is three digits long")]
        public void GivenCvcIsThreeDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "123");
        }

        [When(@"submit button is pressed")]
        public void WhenSubmitButtonIsPressed()
        {
            ButtonHelper.ClickButton(By.Id("submitCard"));
        }

        [Then(@"user is on page paymentConfirmed")]
        public void ThenUserIsOnPagePaymentConfirmed()
        {
            Assert.AreEqual("Paiement confirmé", PageHelper.GetPageTitle());
        }

        [Given(@"credit card number is not sixteen digits long")]
        public void GivenCreditCardNumberIsNotSixteenDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "123456789015948552");
        }

        [Then(@"user is on homePage")]
        public void ThenUserIsOnHomePage()
        {
            Assert.AreEqual("Page Workshop Card Validator", PageHelper.GetPageTitle());
        }

        [Given(@"expiration date is not at format MM/YYYY")]
        public void GivenExpirationDateIsNotAtFormatMMYYYY()
        {
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), "12/20255");
        }

        [Given(@"cvc is not three digits long")]
        public void GivenCvcIsNotThreeDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "1234");
        }

        [Given(@"all input are clear")]
        public void GivenAllInputAreClear()
        {
            TextBoxHelper.ClearTextBox(By.Id("creditCardNumber"));
            TextBoxHelper.ClearTextBox(By.Id("expirationDate"));
            TextBoxHelper.ClearTextBox(By.Id("cvc"));
        }

    }
}
