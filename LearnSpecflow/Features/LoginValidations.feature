@Login
Feature: This feature is to validate Login Validations

This feature is to validate the login and logout functionalities and invalid scenarios

Scenario: Login with valid credential to sause demo portal
	Given Navigate to sause demo portal
	When User enter valid "visual_user" and "secret_sauce"
	And User should click on login button
	Then User should see the home page
	And User can logout from the home page


Scenario: Login to sause demo portal with standard user
	Given Navigate to sause demo portal
	When User enter valid "standard_user" and "secret_sauce"
	Then User should see the home page
	And User can logout from the home page