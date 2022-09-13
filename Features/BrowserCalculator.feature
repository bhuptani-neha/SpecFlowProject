Feature: BrowserCalculator
	Simple calculator for adding two numbers online using Selenium

@Calculator @Web
Scenario Outline: Add two numbers permutations
	Given the first number is <First number>
	And the second number is <Second number>
	When the two numbers are added
	Then the result should be <Expected result>

Examples:
	| First number | Second number | Expected result |
	| 0            | 0             | 0               |
	| -1           | 10            | 9               |
	| 6            | 9             | 15              |

@Calculator @Web
Scenario Outline: Reset Number functionality
	Given the first number is <First number>
	And the second number is <Second number>
	When the two numbers are reset
	Then the first number should be empty
	And the second number should be empty
	And the result should get empty

Examples:
	| First number | Second number |
	| 0            | 0             |
