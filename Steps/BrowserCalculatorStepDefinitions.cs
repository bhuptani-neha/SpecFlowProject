using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using System;

namespace SpecFlowProject1.Steps
{
    [Binding, Scope(Tag = "Web")]
    public sealed class BrowserCalculatorStepDefinitions
    {
        private readonly CalculatorPageObject calculatorPageObject;

        public BrowserCalculatorStepDefinitions(BrowserDriver browserDriver)
        {
            Console.WriteLine("In Browser Steps");
            calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            calculatorPageObject.EnterFirstNumber(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            calculatorPageObject.EnterSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            calculatorPageObject.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            var actualResult = calculatorPageObject.WaitForNonEmptyResult();

            actualResult.Should().Be(expectedResult.ToString());
        }

        [When(@"the two numbers are reset")]
        public void WhenTheTwoNumbersAreReset()
        {
            calculatorPageObject.ClickReset();
        }

        [Then(@"the first number should be empty")]
        public void ThenTheFirstNumberShouldBeEmpty()
        {
             var actualResult = calculatorPageObject.WaitForEmptyFirstNumber();

            actualResult.Should().Be(string.Empty);
        }

        [Then(@"the second number should be empty")]
        public void ThenTheSecondNumberShouldBeEmpty()
        {
            var actualResult = calculatorPageObject.WaitForEmptySecondNumber();

            actualResult.Should().Be(string.Empty);
        }

        [Then(@"the result should get empty")]
        public void ThenTheResultShouldGetEmpty()
        {
            var actualResult = calculatorPageObject.WaitForEmptyResult();

            actualResult.Should().Be(string.Empty);
        }




    }
}
