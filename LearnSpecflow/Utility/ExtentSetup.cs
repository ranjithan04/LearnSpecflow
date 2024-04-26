using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSpecflow.Utility
{
    public class ExtentSetup
    {
        private readonly IWebDriver driver;

        public ExtentSetup(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public String addScreenshot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLoc = Path.Combine(testResultPath, ScenarioContext.Current.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLoc);
            return screenshotLoc;
        }
    }
}
