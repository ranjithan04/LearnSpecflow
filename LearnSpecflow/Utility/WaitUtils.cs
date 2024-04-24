using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace LearnSpecflow.Utility
{
    public class WaitUtils
    {
        private readonly IWebDriver driver;
        WebDriverWait wait; 
        public WaitUtils(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        
        public void waitForElement(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public void waitForElementToBeClickable(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
