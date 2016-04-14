Feature: Add, Remove, and Edit todo items
	In order to remember what I need to do
	As a user
	I want to be able to add todo items to the list

Scenario: Add a todo with no text
	When I press enter
	Then there should be no todo list shown

Scenario: Add one todo item
	When I enter "One" into the text field
	And I press enter
	Then there should be 1 todo item in the list
	And the 1st todo item should be "One"

Scenario: Add two todo items
	Given there is 1 todo item in the list
	And the 1st todo item is "One"
	When I enter "Two" into the text field
	And I press enter
	Then there should be 2 todo items in the list
	And the 1st todo item should be "One"
	And the 2nd todo item should be "Two"

Scenario: Add three todo items
	Given there are 2 todo items in the list
	When I enter "Three" into the text field
	And I press enter
	Then there should be 3 todo items in the list
	And the 1st todo item should be "One"
	And the 2nd todo item should be "Two"
	And the 3rd todo item should be "Three"

Scenario: Edit the 2nd todo item
	Given there are 3 todo items in the list
	When I double click the 2nd item label
	And delete the contents
	And type "2"
	And I press enter
	Then there should be 3 todo items in the list
	And the 1st todo item should be "One"
	And the 2nd todo item should be "2"
	And the 3rd todo item should be "Three" 

Scenario: Edit the 1st todo item
	Given there are 3 todo items in the list
	When I double click the 1st item label
	And delete the contents
	And type "1"
	And I press enter
	Then there should be 3 todo items in the list
	And the 1st todo item should be "1"
	And the 2nd todo item should be "2"
	And the 3rd todo item should be "Three" 

Scenario: Remove the 3rd todo item
	Given there are 3 todo items in the list
	When I hover over the 3rd item
	And I click the remove button for the 3rd item
	Then there should be 2 todo items in the list
	And the 1st todo item should be "1"
	And the 2nd todo item should be "2"

Scenario: Remove the 2nd todo item
	Given there are 2 todo items in the list
	When I hover over the 2nd item
	And I click the remove button for the 2nd item
	Then there should be 1 todo item in the list
	And the 1st todo item should be "1"

Scenario: Remove the 1st todo item
	Given there is 1 todo item in the list
	When I hover over the 1st item
	And I click the remove button for the 1st item
	Then there should be no todo list shown