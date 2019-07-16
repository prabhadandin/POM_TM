Feature: TM
	As TurnUp portal admin
	I would like to manage Time and Material records on a single page

@mytag
Scenario: I would like to create a material with valid details
	Given I have logged in to Time and Material portal successfully
	And I have navigated to TM page
	Then I should be able to create material with valid details successfully
