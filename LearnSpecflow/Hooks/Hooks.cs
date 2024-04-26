using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace LearnSpecflow.Hooks
{
    [Binding]
    public sealed class Hooks 
    {
        private static ExtentReports extentReports;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentSparkReporter sparkReporter;

        private readonly IObjectContainer _container;
       
        public Hooks(IObjectContainer container) { 

            _container = container;   
          
        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            extentReports = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(@"C:\\Users\\611689\\source\\repos\\LearnSpecflow\\LearnSpecflow\\Test Results\\ExtentReport.html");

            sparkReporter.Config.ReportName = "Automation Report";
            sparkReporter.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(sparkReporter);
        }
         

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
            feature = extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
    
        [AfterStep]
        [Obsolete]
        public void AfterStep()
        {
            string stepType = ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = ScenarioContext.Current.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepName);
                }
            }
            if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepName).Fail(ScenarioContext.Current.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver,ScenarioContext.Current)).Build());
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepName).Fail(ScenarioContext.Current.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, ScenarioContext.Current)).Build());
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepName).Fail(ScenarioContext.Current.TestError.Message,
                         MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, ScenarioContext.Current)).Build());
                }
            }
        }


        [BeforeScenario(Order = 1)]
        [Obsolete]
        public void BeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }   

        [AfterScenario]
        public void AfterScenario()
        {
           var driver = _container.Resolve<IWebDriver>();
           driver.Close();

            if(driver != null)
            {
                driver.Quit();
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReports.Flush();
        }

        public static string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(@"C:\\Users\\611689\\source\\repos\\LearnSpecflow\\LearnSpecflow\\Test Results", scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }

    }
}