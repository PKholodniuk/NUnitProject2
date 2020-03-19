using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitTestProject1
{
    [TestFixture]
    public class CourseYoutube
    {
        private FirefoxDriver _driver;
        private Actions _action;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _action = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
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
        public void DragDropExample2()
        {

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));

            //this code can be able in page object model
            var drag = _action
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(targetElement)
                .Build();

            //this code will be in test
            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
            
        }

        [Test]
        [Obsolete]
        public void JQueryDragDropQuiz()
        {
            _driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ExampleFrame-94")));

            var sourceLocator = _driver.FindElement(By.XPath("//*[@class='square ui-draggable']"));
            var distanationLocator = _driver.FindElement(By.XPath("//*[@class='squaredotted ui-droppable']"));
            _action.DragAndDrop(sourceLocator, distanationLocator).Perform();
            var droppedText = _driver.FindElement(By.Id("info")).Text;
            Assert.AreEqual("dropped!", droppedText);
        }

        [Test]
        [Obsolete]
        public void Resizable()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement resibleHandle = _driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));

            _action.ClickAndHold(resibleHandle).MoveByOffset(120, 120).Perform();
            Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id='resizable' and @style]")).Displayed);

        }
        [Test]
        public void OpenGoogle()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
            //_action.KeyDown(Keys.F12).Perform();
            //_action.KeyUp(Keys.F12).Perform();
            
            _action.KeyDown(Keys.Control).KeyDown(Keys.Shift).SendKeys("q").Perform();
            _action.KeyUp(Keys.Control).KeyUp(Keys.Shift).Perform();
            
            _action.KeyDown(Keys.Control).SendKeys("r").Perform();
            _action.KeyUp(Keys.Control).Perform();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}