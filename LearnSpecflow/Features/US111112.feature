@FeatureCheckout @US111112
Feature: US111112 - With tags

This feature is to perform the checkout operation in sause demo portal

	@Oder @US111112
	@DataSource:TestData/testData.json
	Scenario: Select the product and place the order
	Given User navigates to sause demo portal
	And User login to the application <UserName>,<Password>
	When User add the product to cart 
	And User perform the checkout 
	And User place the order <FirstName>,<LastName>,<ZipCode>
	Then Order should be placed successfully <Message>


	@Checkout @US111112
	@DataSource:TestData/testData.json
	Scenario: Select the product and add to the cart
	Given User navigates to sause demo portal
	And User login to the application <UserName>,<Password>
	When User add the product to cart 
	And User perform the checkout 