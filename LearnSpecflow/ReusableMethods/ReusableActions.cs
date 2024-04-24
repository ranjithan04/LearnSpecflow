using LearnSpecflow.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearnSpecflow.ReusableMethods
{
    public class ReusableActions
    {
        private readonly IWebDriver driver;
        WaitUtils waitUtils;

        public ReusableActions(IWebDriver driver)
        {
            this.driver = driver;
            waitUtils = new WaitUtils(driver);
        }
        public void enterText(By element, String value)
        {
            waitUtils.waitForElement(element);
            driver.FindElement(element).SendKeys(value);
        }

        public void clickAction(By element)
        {
            waitUtils.waitForElementToBeClickable(element);
            driver.FindElement(element).Click();
        }

        public String getText(By element)
        {
            waitUtils.waitForElement(element);
            return driver.FindElement(element).Text;
        }
    }
}
