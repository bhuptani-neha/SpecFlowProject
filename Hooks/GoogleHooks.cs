using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public class GoogleHooks
    {
        [BeforeScenario("Google")]
        public static void BeforeScenario(BrowserDriver browserDriver)
        {
            var googlePage = new GooglePageObject(browserDriver.Current);
            googlePage.EnsureGoogleIsOpen();
        }
    }
}
