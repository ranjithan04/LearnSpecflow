Feature: This feature is to perform checkout operation

This feature is to perform the checkout operation in sause demo portal

Scenario: Select the product and add to the cart
	Given User navigates to sause demo portal
	And User login to the application <userName>
	When User add the product to cart
	And User perform the checkout
	And User place the order
	Then Order should be placed successfully

	

