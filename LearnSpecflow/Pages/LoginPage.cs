using LearnSpecflow.ReusableMethods;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LearnSpecflow.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        readonly ReusableActions actions;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new ReusableActions(driver);            
        }

        private readonly By userNameTxt = By.Id("user-name");
        private readonly By passwordTxt = By.Id("password");
        private readonly By loginBtn = By.Id("login-button");
        private readonly By errorTxt = By.XPath("//h3[@data-test='error']");
        public void Login(String userName, String passWord)
        {
            actions.EnterText(userNameTxt, userName);
            actions.EnterText(passwordTxt, passWord);
            actions.ClickAction(loginBtn);
        }

        public void VerifyError(String errorMessage)
        {
            Assert.AreEqual(errorMessage, actions.GetText(errorTxt));
        }
    }
}
