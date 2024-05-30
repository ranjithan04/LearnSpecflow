using LearnSpecflow.PojoData;
using LearnSpecflow.ReusableMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LearnSpecflow.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;
        readonly ReusableActions actions;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new ReusableActions(driver);
        }

        private readonly By addToCartBtn = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By shopCartLink = By.XPath("//a[@class='shopping_cart_link']");
        private readonly By contShopBtn = By.Id("continue-shopping");
        private readonly By checkOutBtn = By.Id("checkout");
        private readonly By firstNameTxt = By.Id("first-name");
        private readonly By lastNameTxt = By.Id("last-name");
        private readonly By zipCodeTxt = By.Id("postal-code");
        private readonly By cancelBtn = By.Id("cancel");
        private readonly By continueBtn = By.Id("continue");
        private readonly By checkOutOverViewTitle = By.XPath("//div/span[@class='title']");
        private readonly By finishBtn = By.Id("finish");
        private readonly By orderConfirmHeaderTxt = By.XPath("//div/h2[@class='complete-header']");
        private readonly By backToHomeBtn = By.Id("back-to-products");

        public void AddProductToCart()
        {
            actions.ClickAction(addToCartBtn);

        }

        public void CheckOut()
        {
            actions.ClickAction(shopCartLink);
            actions.ClickAction(checkOutBtn);
        }

        public void PlaceTheOrder(String firstName,String lastName, String zipCode)
        {          
            actions.EnterText(firstNameTxt, firstName);
            actions.EnterText(lastNameTxt, lastName);
            actions.EnterText(zipCodeTxt, zipCode);
            actions.ClickAction(continueBtn);
            actions.ClickAction(finishBtn);
        }

        public void VerifyOnSuccess(string successMsg)
        {
            Assert.AreEqual(successMsg, actions.GetText(orderConfirmHeaderTxt));
        }

        public void placeTheOrderWithTableData(Table table)
        {
            CheckoutDetails checkoutDetails = table.CreateInstance<CheckoutDetails>();

            actions.enterText(firstNameTxt, checkoutDetails.FirstName);
            actions.enterText(lastNameTxt, checkoutDetails.LastName);
            actions.enterText(zipCodeTxt, checkoutDetails.ZipCode);
            actions.clickAction(continueBtn);
            actions.clickAction(finishBtn);

        }
        public void addMultipleProductToCart()
        {
            actions.clickAction(addToCartBtn);
            actions.clickAction(addMultipleToCartBtn);

        }

    }



}
