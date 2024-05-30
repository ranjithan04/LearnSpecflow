using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace LearnSpecflow.Utility
{
    public class WaitUtils
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait; 
        public WaitUtils(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        
        public void WaitForElement(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public void WaitForElementToBeClickable(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
