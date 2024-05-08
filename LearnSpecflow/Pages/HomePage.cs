using LearnSpecflow.ReusableMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSpecflow.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver = null;
        ReusableActions actions = null;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new ReusableActions(driver);
        }

        By productTitleSpan = By.XPath("//span[@data-test='title']");
        By pageHeaderTitle = By.XPath("//div[@class='app_logo']");
        By burgerMenu = By.Id("react-burger-menu-btn");
        By logoutLink = By.Id("logout_sidebar_link");


        public void verifyHomePageTitle()
        {
            Assert.AreEqual("Products", actions.getText(productTitleSpan));
            Assert.AreEqual("Swag Labs", actions.getText(pageHeaderTitle));
        }

        public void logout()
        {
            actions.clickAction(burgerMenu);
            actions.clickAction(logoutLink);
        }
    }
}
