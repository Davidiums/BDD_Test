using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugzillaWebDriver.BaseClasses;
using BugzillaWebDriver.ComponentHelper;
using BugzillaWebDriver.Configuration;
using BugzillaWebDriver.Settings;

namespace Controle_David.Hook
{
    [Binding]
    public class InitScenarioHook
    {
        [BeforeTestRun]
        public static void InitScenario()
        {
            ObjectRepository.Config = new ConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = BaseClass.GetChromeWebDriver();
                    break;

                case BrowserType.Firefox:
                    ObjectRepository.Driver = BaseClass.GetFirefoxWebDriver();
                    break;

                case BrowserType.InternetExplorer:
                    ObjectRepository.Driver = BaseClass.GetInternetExplorerWebDriver();
                    break;
            }

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }
        [BeforeScenario]
        public static void BeforeScenario()
        {
            NavigationHelper.OpenNewTab();
            NavigationHelper.NavigateToHomePage();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            NavigationHelper.CloseTab();
        }

        [AfterTestRun]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
