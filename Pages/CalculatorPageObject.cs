using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject1.Pages
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class CalculatorPageObject
    {
        //The URL of the calculator to be opened in the browser
        private const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver driver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public CalculatorPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Finding elements by ID
        private IWebElement FirstNumberElement => driver.FindElement(By.Id("first-number"));
        private IWebElement SecondNumberElement => driver.FindElement(By.Id("second-number"));
        private IWebElement AddButtonElement => driver.FindElement(By.Id("add-button"));
        private IWebElement ResultElement => driver.FindElement(By.Id("result"));
        private IWebElement ResetButtonElement => driver.FindElement(By.Id("reset-button"));

        public void EnterFirstNumber(string number)
        {
            FirstNumberElement.Clear();
            FirstNumberElement.SendKeys(number);
        }

        public void EnterSecondNumber(string number)
        {
            SecondNumberElement.Clear();
            SecondNumberElement.SendKeys(number);
        }

        public void ClickAdd()
        {
            AddButtonElement.Click();
        }

        public void ClickReset()
        {
            ResetButtonElement.Click();
        }

        public void EnsureCalculatorIsOpenAndReset()
        {
            if (driver.Url != CalculatorUrl)
            {
                driver.Url = CalculatorUrl;
            }
            else
            {
                ResetButtonElement.Click();
                WaitForEmptyResult();
            }
        }

        public string WaitForNonEmptyResult()
        {
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitForEmptyResult()
        {
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => result == string.Empty);
        }

        public string WaitForEmptyFirstNumber()
        {
            //Wait for the result to be empty
            return WaitUntil(
                () => FirstNumberElement.GetAttribute("value"),
                result => result == string.Empty);
        }

        public string WaitForEmptySecondNumber()
        {
            //Wait for the result to be empty
            return WaitUntil(
                () => SecondNumberElement.GetAttribute("value"),
                result => result == string.Empty);
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
        }
    }
}
