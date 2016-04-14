Feature: Mark as complete and filter todo items
	In order to help organise the todo list
	As a user
	I want to be able to filter my todo items based on if they are completed or not

Scenario: Add three todo items
	When I add 3 todo items
	Then there should be 3 todo items in the list
	And the 1st todo item should be "1"
	And the 2nd todo item should be "2"
	And the 3rd todo item should be "3" 

Scenario: Mark the 1st item as complete
	Given there are 3 todo items in the list
	When I mark the 1st item as complete
	Then the 1st todo item should be marked as complete
	And the item counter should be 2
	And the clear completed button should be present

Scenario: Filter the list by active
	Given there are 3 todo items in the list
	And the 1st todo item is marked as complete
	When I filter by "Active"
	Then there should be 2 todo items in the list
	And the 1st todo item should be "2"
	And the 2nd todo item should be "3"

Scenario: Filter the list by completed
	Given there are 2 todo items in the list
	When I filter by "Completed"
	Then there should be 1 todo item in the list
	And the 1st todo item should be "1"

Scenario: Filter the list by all
	Given there is 1 todo item in the list
	When I filter by "All"
	Then there should be 3 todo items in the list
	And the 1st todo item should be "1"
	And the 2nd todo item should be "2"
	And the 3rd todo item should be "3"

Scenario: Clear completed
	Given there are 3 todo items in the list
	And the clear completed button is present
	When I click the clear completed button
	Then there should be 2 todo items in the list
	And the 1st todo item should be "2"
	And the 2nd todo item should be "3"