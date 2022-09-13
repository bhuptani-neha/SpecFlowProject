Feature: SeleniumGoogleSearch
	GoogleSearch Tests

@Google
Scenario: Search Selenium in Google and verify first result
	Given Go to Google
	When Search "Selenium" in Goolge 
	Then first result has selenium in url

@Google
Scenario: Search Google in Google and verify first result
	Given Go to Google
	When Search "Google" in Goolge 
	Then first result has selenium in url