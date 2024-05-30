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
        readonly WaitUtils waitUtils;

        public ReusableActions(IWebDriver driver)
        {
            this.driver = driver;
            waitUtils = new WaitUtils(driver);
        }
        public void EnterText(By element, String value)
        {
            waitUtils.WaitForElement(element);
            driver.FindElement(element).SendKeys(value);
        }

        public void ClickAction(By element)
        {
            waitUtils.WaitForElementToBeClickable(element);
            driver.FindElement(element).Click();
        }

        public String GetText(By element)
        {
            waitUtils.WaitForElement(element);
            return driver.FindElement(element).Text;
        }
    }
}
