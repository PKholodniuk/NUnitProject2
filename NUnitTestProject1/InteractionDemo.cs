using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace NUnitTestProject1
{
    [TestFixture]
    [Parallelizable]
    public class InteractionDemo
    {
        private ChromeDriver _driver;
        private Actions _action;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _action = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }



        [Test]
        [Obsolete]
        public void ReadOnlyCollection()
        {
            _driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            _driver.Manage().Window.Maximize();
            List<String> textOfAnchor = new List<string>();
            ReadOnlyCollection<IWebElement> anchorList = _driver.FindElements(By.TagName("a"));
            foreach (IWebElement anchor in anchorList)
            {
                if (anchor.Text.Length > 0 && anchor.Text.Contains("English"))
                {
                    textOfAnchor.Add(anchor.Text);
                    anchor.Click();
                }
            }
            string stop = "";
        }

        [Test]
        [Obsolete]
        public void SelectElement()
        {
            _driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            _driver.Manage().Window.Maximize();
            SelectElement selectLanguage = new SelectElement(_driver.FindElement(By.Id("searchLanguage")));
            selectLanguage.SelectByText("Deutsch");
            selectLanguage.SelectByIndex(0);
            selectLanguage.SelectByValue("da");
            #region
            //List<String> textOfAnchor = new List<string>();
            //ReadOnlyCollection<IWebElement> anchorList = _driver.FindElements(By.TagName("a"));
            //foreach (IWebElement anchor in anchorList)
            //{
            //    if (anchor.Text.Length == 0 && anchor.Text.Contains("English"))
            //    {
            //        textOfAnchor.Add(anchor.Text);
            //        anchor.Click();
            //    }
            //}
            //string stop = "";
            #endregion

        }

        [Test]
        [Obsolete]
        public void DragDropExample1()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            _action.DragAndDrop(sourceElement, targetElement).Perform();
            Assert.AreEqual("Dropped!", targetElement.Text);
        }

        [Test]
        [Obsolete]
        public void GoogleSearch()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
            _driver.Manage().Window.Maximize();
            IWebElement search = _driver.FindElement(By.Name("q"));
            search.SendKeys("#selenium webdriver");
            var button = _driver.FindElement(By.Name("btnK"));
            _wait.Until(ExpectedConditions.ElementToBeClickable(button));
            button.Click();
            var reasult = _driver.FindElements(By.TagName("h3"));
            reasult[1].Click();
            Thread.Sleep(5000);
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}