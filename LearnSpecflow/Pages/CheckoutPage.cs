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
        ReusableActions actions;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new ReusableActions(driver);
        }

        By addToCartBtn = By.Id("add-to-cart-sauce-labs-backpack");
        By addMultipleToCartBtn = By.Name("add-to-cart-sauce-labs-bike-light");
        By addMultipleToCartBtn2 = By.Name("add-to-cart-sauce-labs-fleece-jacket");
        By shopCartLink = By.XPath("//a[@class='shopping_cart_link']");
        By contShopBtn = By.Id("continue-shopping");
        By checkOutBtn = By.Id("checkout");
        By firstNameTxt = By.Id("first-name");
        By lastNameTxt = By.Id("last-name");
        By zipCodeTxt = By.Id("postal-code");
        By cancelBtn = By.Id("cancel");
        By continueBtn = By.Id("continue");
        By checkOutOverViewTitle = By.XPath("//div/span[@class='title']");
        By finishBtn = By.Id("finish");
        By orderConfirmHeaderTxt = By.XPath("//div/h2[@class='complete-header']");
        By backToHomeBtn = By.Id("back-to-products");

        public void addProductToCart()
        {
            actions.clickAction(addToCartBtn);

        }

        public void checkOut()
        {
            actions.clickAction(shopCartLink);
            actions.clickAction(checkOutBtn);
        }

        public void placeTheOrder(String firstName,String lastName, String zipCode)
        {          
            actions.enterText(firstNameTxt, firstName);
            actions.enterText(lastNameTxt, lastName);
            actions.enterText(zipCodeTxt, zipCode);
            actions.clickAction(continueBtn);
            actions.clickAction(finishBtn);
        }

        public void verifyOnSuccess(string successMsg)
        {
            Assert.AreEqual(successMsg, actions.getText(orderConfirmHeaderTxt));
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
