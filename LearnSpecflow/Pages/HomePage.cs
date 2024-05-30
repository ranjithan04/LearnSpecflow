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
        private readonly IWebDriver driver;
        readonly ReusableActions actions;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new ReusableActions(driver);
        }

        private readonly By productTitleSpan = By.XPath("//span[@data-test='title']");
        private readonly By pageHeaderTitle = By.XPath("//div[@class='app_logo']");
        private readonly By burgerMenu = By.Id("react-burger-menu-btn");
        private readonly By logoutLink = By.Id("logout_sidebar_link");


        public void VerifyHomePageTitle()
        {
            Assert.AreEqual("Products", actions.GetText(productTitleSpan));
            Assert.AreEqual("Swag Labs", actions.GetText(pageHeaderTitle));
        }

        public void Logout()
        {
            actions.ClickAction(burgerMenu);
            actions.ClickAction(logoutLink);
        }
    }
}
