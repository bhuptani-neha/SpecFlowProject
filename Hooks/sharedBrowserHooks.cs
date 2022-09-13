using BoDi;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;
using System;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class sharedBrowserHooks
    {
        [Binding]
        public class SharedBrowserHooks
        {
            [BeforeTestRun]
            public static void BeforeTestRun(ObjectContainer testThreadContainer)
            {
                //Initialize a shared BrowserDriver in the global container
                testThreadContainer.BaseContainer.Resolve<BrowserDriver>();
            }
        }
    }
}
