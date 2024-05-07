Feature: This feature is to validate the invalid Login credentials

This feature is to validate the login functionatlity with invalid credentials

Scenario Outline: Login with invalid credential to sause demo portal
	
	Given Navigate to sause demo portal 
	When User enter valid "<userName>" and "<password>"
	Then User should see error message as "<errorMessage>"
	
	Examples: 

	| userName        | password     | errorMessage                                                              |
	| locked_out_user | secret_sauce | Epic sadface: Sorry, this user has been locked out                        |
	| abcduser        | secret_sauce | Epic sadface: Username and password do not match any user in this service |