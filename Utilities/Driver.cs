using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceQA.Utilities
{
    internal class Driver
    {
        private static IWebDriver driver;

        public static IWebDriver Get()
        {
            if (driver == null)
            {
                string browser = ConfigurationProperties.browser;

                switch (browser)
                {
                    case "chrome":
                        driver = new ChromeDriver();
                        break;

                    case "firefox":
                        driver = new FirefoxDriver();
                        break;

                }
            }

            return driver;
        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                BrowserUtils.WaitFor(3);
                driver = null;
            }
        }
    }
}
