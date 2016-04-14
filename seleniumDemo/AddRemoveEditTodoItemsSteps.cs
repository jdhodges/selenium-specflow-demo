using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumDemo.Support;
using TechTalk.SpecFlow;

namespace seleniumDemo {
    public static class WebElementExtensions {
        public static bool ElementIsPresent(this IWebDriver driver, By by) {
            try {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException) {
                return false;
            }
        }
    }
    [Binding]
    public class AddRemoveEditTodoItemsSteps : StepsBase {
        By selectTodoItems = By.CssSelector(".todo-list li");

        // Adding
        [When(@"I enter ""(.*)"" into the text field")]
        public void WhenEnterIntoTheTextField(string text) {
            driver.FindElement(By.CssSelector(".new-todo")).SendKeys(text);
        }

        [When(@"I press enter")]
        public void WhenIPressEnter() {
            actions.SendKeys(Keys.Enter).Build().Perform();
        }

        [Then(@"there should be no todo list shown")]
        public void ThenThereShouldBeNoTodoListShown() {
            Assert.IsFalse(WebElementExtensions.ElementIsPresent(driver, By.CssSelector(".todo-list")));
        }

        [Then(@"there should be (.*) todo items? in the list")]
        [Given(@"there (?:is|are) (.*) todo items? in the list")]
        public void ThenThereShouldBeXTodoItemsInTheList(int numberOfTodoItems) {
            var todoItems = driver.FindElements(selectTodoItems);
            Assert.AreEqual(numberOfTodoItems, todoItems.Count);
        }

        [Then(@"the (\d+)(?:st|nd|rd|th) todo item should be ""(.*)""")]
        [Given(@"the (\d+)(?:st|nd|rd|th) todo item is ""(.*)""")]
        public void ThenTheTodoItemAtIndexShouldBe(int index, string text) {
            var todoItems = driver.FindElements(selectTodoItems);
            Assert.AreEqual(text, todoItems[index - 1].FindElement(By.TagName("label")).Text);
        }

        // Removing
        [When(@"I hover over the (\d+)(?:st|nd|rd|th) item")]
        public void WhenIHoverOverTheItem(int index) {
            var todoItems = driver.FindElements(selectTodoItems);
            actions.MoveToElement(todoItems[index - 1]);
            actions.Build().Perform();
        }

        [When(@"I click the remove button for the (\d+)(?:st|nd|rd|th) item")]
        public void WhenIClickTheRemoveButton(int index) {
            var todoItems = driver.FindElements(selectTodoItems);
            todoItems[index - 1].FindElement(By.TagName("button")).Click();
        }

        // Editing
        [When(@"I double click the (\d+)(?:st|nd|rd|th) item label")]
        public void WhenIDoubleClickTheItemLabel(int index) {
            var todoItems = driver.FindElements(selectTodoItems);
            actions.MoveToElement(todoItems[index - 1].FindElement(By.TagName("label")));
            actions.DoubleClick();
            actions.Build().Perform();
        }

        [When(@"type ""(.*)""")]
        public void WhenType(string text) {
            actions.SendKeys(text).Build().Perform();
        }

        [When(@"delete the contents")]
        public void WhenDeleteTheContents() {
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Build().Perform();
        }
    }
}
