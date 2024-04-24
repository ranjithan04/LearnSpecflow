using LearnSpecflow.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace LearnSpecflow.StepDefinitions
{
    [Binding]
    public class InvalidLoginValidationsStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;

        public InvalidLoginValidationsStepDefinitions(IWebDriver driver) { 
            this.driver = driver;
            loginPage = new LoginPage(driver);  
            homePage  = new HomePage(driver);
        }

        [Then(@"User should see error message as ""([^""]*)""")]
        public void ThenUserShouldSeeErrorMessageAs(string errorMsg)
        {
           loginPage.verifyError(errorMsg);
        }

    }
}
