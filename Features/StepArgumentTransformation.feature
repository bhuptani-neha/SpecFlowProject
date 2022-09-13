Feature: StepArgumentTransformation
	Simple calculator for adding two numbers

@mytag
Scenario: Calculate total days between two monthsby converting month to date of current year
	Given the first input is given as June month
	And the second input is given as July month
	Then the total days should be given  61 days
 