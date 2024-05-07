using LearnSpecflow.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace LearnSpecflow.StepDefinitions
{
    [Binding]
    public class LoginValidationsStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;

        public LoginValidationsStepDefinitions(IWebDriver driver) { 
            this.driver = driver;
            loginPage = new LoginPage(driver);  
            homePage  = new HomePage(driver);
        }

        [Given(@"Navigate to sause demo portal")]
        public void GivenNavigateToSauseDemoPortal()
        {
            driver.Url = "https://www.saucedemo.com/";
        }

        [When(@"User enter valid ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserEnterValidAnd(string username, string password)
        {
           loginPage.login(username, password);
        }

        [Then(@"User should see the home page")]
        public void ThenUserShouldSeeTheHomePage()
        {
            homePage.verifyHomePageTitle();
        }

        [Then(@"User can logout from the home page")]
        public void ThenUserCanLogoutFromTheHomePage()
        {
            homePage.logout();
        }

        [Given(@"User navigates to sause demo portal")]
        public void GivenUserNavigatesToSauseDemoPortal()
        {
            driver.Url = "https://www.saucedemo.com/";
        }
        [When(@"User should click on login button")]
        public void WhenUserShouldClickOnLoginButton()
        {
        }



    }
}
