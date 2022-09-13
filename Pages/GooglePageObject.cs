using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowProject1.Pages
{
    public class GooglePageObject
    {
        private const string googleURL = "https://Google.com";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver driver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public GooglePageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        //Finding elements by ID
        private IWebElement GoogleSearchTextBox => driver.FindElement(By.CssSelector("input[title=Search]"));
        private IReadOnlyCollection<IWebElement> Results => driver.FindElements(By.XPath("//div[@class='yuRUbf']//a"));

        public void EnsureGoogleIsOpen()
        {
            if (driver.Url != googleURL)
            {
                driver.Url = googleURL;
            }
        }

        public void NavigateToGoogle()
        {
            driver.Url = googleURL;
        }

        public void EnterSearchData(String input)
        {
            GoogleSearchTextBox.SendKeys(input + Keys.Enter);
        }

        public String ClickFirstResultandGetURL()
        {
            Results.FirstOrDefault().Click();
            string url = driver.Url;
            Console.WriteLine(url);
            return url;
        }
    }
}
