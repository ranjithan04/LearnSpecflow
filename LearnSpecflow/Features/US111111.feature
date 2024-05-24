Feature: #US111111 Checkout operation with table data

This feature is to perform the checkout operation in sause demo portal

@DataSource:TestData/testData.json
Scenario: Select the product and add to the cart with dable and data source
	Given User navigates to sause demo portal
	And User login to the application <UserName>,<Password>
	When User add the product to cart 
	And User perform the checkout 
	And User place the order with details as
	| FirstName | LastName | ZipCode |  
	| Ranjith   | Kumar    | 123456  |
	Then Order should be placed successfully <Message>