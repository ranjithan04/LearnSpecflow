﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using BoDi;
using LearnSpecflow.Utility;
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
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
    
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();
            if (scenarioContext.TestError == null)
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
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentSetup.AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentSetup.AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                         MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentSetup.AddScreenshot(driver, scenarioContext)).Build());
                }
            }
        }


        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

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
    }
}