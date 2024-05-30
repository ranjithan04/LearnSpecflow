using LearnSpecflow.Pages;
using OpenQA.Selenium;

namespace LearnSpecflow.StepDefinitions
{
    [Binding]
    public class InvalidLoginValidationsStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

        public InvalidLoginValidationsStepDefinitions(IWebDriver driver) { 
            this.driver = driver;
            loginPage = new LoginPage(driver);  
            homePage  = new HomePage(driver);
        }

        [Then(@"User should see error message as ""([^""]*)""")]
        public void ThenUserShouldSeeErrorMessageAs(string errorMsg)
        {
           loginPage.VerifyError(errorMsg);
        }

    }
}
