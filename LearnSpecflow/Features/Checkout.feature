Feature: Checkout operation

This feature is to perform the checkout operation in sause demo portal

@DataSource:TestData/testData.json
Scenario: Select the product and add to the cart
	Given User navigates to sause demo portal
	And User login to the application <UserName>,<Password>
	When User add the product to cart 
	And User perform the checkout 
	And User place the order <FirstName>,<LastName>,<ZipCode>
	Then Order should be placed successfully <Message>
	Then User should see the home page