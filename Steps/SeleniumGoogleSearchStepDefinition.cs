using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using System.Linq;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class SeleniumGoogleSearchStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly GooglePageObject googlePage;
        private readonly ScenarioContext _scenarioContext;

        public SeleniumGoogleSearchStepDefinition(BrowserDriver browserDriver, ScenarioContext scenarioContext)
        {
            Console.WriteLine("In Browser Calculator Steps");
            googlePage = new GooglePageObject(browserDriver.Current);
            this._scenarioContext = scenarioContext;
        }

        [Given(@"Go to Google")]
        public void GivenGoToGoogle()
        {
            googlePage.NavigateToGoogle();
        }

        [When(@"Search ""(.*)"" in Goolge")]
        public void WhenSearchInGoolge(string p0)
        {
            googlePage.EnterSearchData(p0);
            _scenarioContext.Add("input", p0);
        }

        [Then(@"first result has selenium in url")]
        public void ThenFirstResultHasSeleniumInUrl()
        {
            string url = googlePage.ClickFirstResultandGetURL();
            url.ToLower().Should().Contain(_scenarioContext.Get<string>("input").ToLower());
        }


    }
}
