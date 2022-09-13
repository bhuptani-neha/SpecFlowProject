using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class StepArgumentTransformationStepsDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public StepArgumentTransformationStepsDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [StepArgumentTransformation(@"(?:([a-zA-Z]+) month)")]
        public TimeSpan convertMonthToDays(string month)
        {
            
            Console.WriteLine(month);
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.ParseExact(month, "MMMM", new CultureInfo("en-US")).Month);
            return new TimeSpan(days,0,0,0);
        }


        [Given(@"the first input is given as (.*)")]
        public void GivenTheFirstInputIsGivenAsJuneMonth(TimeSpan days)
        {
            Console.WriteLine(days);
            _scenarioContext.Add("first", days);
        }

        [Given(@"the second input is given as (.*)")]
        public void GivenTheSecondInputIsGivenAsJulyMonth(TimeSpan days)
        {
            Console.WriteLine(days);
            _scenarioContext.Add("second", days);
        }

        [Then(@"the total days should be given  (.*) days")]
        public void ThenTheTotalDaysShouldBeGivenDays(int p0)
        {
            Console.WriteLine(p0);
            int days = _scenarioContext.Get<TimeSpan>("first").Days + _scenarioContext.Get<TimeSpan>("second").Days;
            Console.WriteLine(days);
            p0.Should().Be(days);
        }

    }
}
