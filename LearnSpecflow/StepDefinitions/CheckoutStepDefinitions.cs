using LearnSpecflow.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace LearnSpecflow.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        CheckoutPage checkoutPage;

        public CheckoutStepDefinitions(IWebDriver driver) { 
            this.driver = driver;
            loginPage = new LoginPage(driver);  
            homePage  = new HomePage(driver);
            checkoutPage = new CheckoutPage(driver);
        }


        [When(@"User add the product to cart")]
        public void WhenUserAddTheProductToCart()
        {
            checkoutPage.addProductToCart();
        }

        [When(@"User perform the checkout")]
        public void WhenUserPerformTheCheckout()
        {
            checkoutPage.checkOut();
        }

        [When(@"User place the order (.*),(.*),(.*)")]
        public void WhenUserPlaceTheOrderFirstNameLastNameZipCode(string firstName,string lastName, string zipCode)
        {
            checkoutPage.placeTheOrder(firstName, lastName, zipCode);
        }

        [Then(@"Order should be placed successfully (.*)")]
        public void ThenOrderShouldBePlacedSuccessfullySuccessMsg(string Message)
        {
            checkoutPage.verifyOnSuccess(Message);
        }

        [When(@"User place the order with details as")]
        public void WhenUserPlaceTheOrderWithDetailsAs(Table table)
        {
           checkoutPage.placeTheOrderWithTableData(table);
        }




    }
}
