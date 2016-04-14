using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumDemo.Support;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace seleniumDemo
{
    [Binding]
    public class FilterTodoItemsSteps : StepsBase
    {
        By selectTodoItems = By.CssSelector(".todo-list li");
        Dictionary<string, int> filters = new Dictionary<string, int>() {
            { "All", 0 },
            { "Active", 1 },
            { "Completed", 2 }
        };

        [When(@"I add (.*) todo items")]
        public void WhenIAddTodoItems(int numberOfItems) {
            for (int i = 0; i < numberOfItems; i++) {
                driver.FindElement(By.CssSelector(".new-todo")).SendKeys("" + (i + 1));
                actions.SendKeys(Keys.Enter).Build().Perform();
            }
        }

        [When(@"I mark the (\d+)(?:st|nd|rd|th) item as complete")]
        public void WhenIMarkTheItemAsComplete(int index) {
            var todoItems = driver.FindElements(selectTodoItems);
            todoItems[index - 1].FindElement(By.ClassName("toggle")).Click();
        }

        [Then(@"the (\d+)(?:st|nd|rd|th) todo item should be marked as complete")]
        [Given(@"the (\d+)(?:st|nd|rd|th) todo item is marked as complete")]
        public void ThenTheTodoItemShouldBeMarkedAsComplete(int index) {
            var todoItems = driver.FindElements(selectTodoItems);
            Assert.AreEqual("completed", todoItems[index - 1].GetAttribute("class"));
        }

        [Then(@"the item counter should be (.*)")]
        public void ThenTheItemCounterShouldBe(int expectedItemCount) {
            Assert.AreEqual("" + expectedItemCount, driver.FindElement(By.CssSelector(".todo-count > strong")).Text);
        }

        [Then(@"the clear completed button should be present")]
        [Given(@"the clear completed button is present")]
        public void ThenTheClearCompletedButtonShouldBePresent() {
            Assert.IsTrue(WebElementExtensions.ElementIsPresent(driver, By.ClassName("clear-completed")));
        }

        [When(@"I filter by ""(.*)""")]
        public void WhenIFilterBy(string filter) {
            var filterButtons = driver.FindElements(By.CssSelector(".filters > li > a"));

            int filterIndex;
            if (filters.TryGetValue(filter, out filterIndex)) {
                filterButtons[filterIndex].Click();
            } else {
                throw new AssertFailedException();
            }
        }

        [When(@"I click the clear completed button")]
        public void WhenIClickTheClearCompletedButton() {
            ScenarioContext.Current.Pending();
        }

    }
}
