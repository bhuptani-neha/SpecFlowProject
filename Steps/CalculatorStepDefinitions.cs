using TechTalk.SpecFlow;
using FluentAssertions;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Non Browser the first number is (.*)")]
        public void GivenNonBrowserTheFirstNumberIs(int number)
        {
            _scenarioContext.Add("input1", number);
        }

        [Given("Non Browser the second number is (.*)")]
        public void GivenNonBrowserTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Add("input2", number);
        }

        [When("Non Browser the two numbers are added")]
        public void WhenNonBrowserTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            _scenarioContext.Add("result", _scenarioContext.Get<int>("input1")+_scenarioContext.Get<int>("input2"));
        }

        [Then("Non Browser the result should be (.*)")]
        public void ThenNonBrowserTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic
            result.Should().Be(_scenarioContext.Get<int>("result"));
        }
    }
}
