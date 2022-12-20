using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace AcceptanceQA.Utilities
{
    class BrowserUtils
    {
        public static void WaitFor(int seconds)
        {
            try
            {
                Thread.Sleep(seconds * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver.Get()).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}