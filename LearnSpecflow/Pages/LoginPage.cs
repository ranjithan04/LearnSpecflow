using LearnSpecflow.ReusableMethods;
using LearnSpecflow.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LearnSpecflow.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        ReusableActions actions;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new ReusableActions(driver);            
        }

        By userNameTxt = By.Id("user-name");
        By passwordTxt = By.Id("password");
        By loginBtn = By.Id("login-button");
        By errorTxt = By.XPath("//h3[@data-test='error']");
        public void login(String userName, String passWord)
        {
            actions.enterText(userNameTxt, userName);
            actions.enterText(passwordTxt, passWord);
            actions.clickAction(loginBtn);
        }

        public void verifyError(String errorMessage)
        {
            Assert.AreEqual(errorMessage, actions.getText(errorTxt));
        }
    }
}
