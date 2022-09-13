Feature: MyFirstTest
	Simple calculator for adding two numbers

@mytag
Scenario: Non Browser Add two numbers
	Given Non Browser the first number is 50
	And Non Browser the second number is 70
	When Non Browser the two numbers are added
	Then Non Browser the result should be 120