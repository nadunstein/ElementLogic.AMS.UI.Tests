Feature: Admin Refill Trolley TakeOver
	As an admin user, I want to verify the taking over refill trolley related scenarios

@Regression
@Scenario:'1'
@AdminModule:Activity:Refill:TrolleyTakeOver
Scenario: Verify the refill trolley can be taken over by another user
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Refill Order List page in Admin Module
	And I select a trolley from Trolley drop down in Refill Order List page
	And I include the 'ScanCode' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page
	When I Click on Log Out option on Hamburger menu in admin module page
	Then The Admin module login page is loaded
	Then I Import and create a GR order with following data
	| OrderLineId | ProductId | ProductName       | Scancode     | Quantity |
	| 1           | ASRP15    | ASRefillProduct15 | RefillProd15 | 1        |
	Given I login to the AdminModule as 'UserOne' user
	And I navigate to Refill Order List page in Admin Module
	And I select the same trolley from Trolley drop down in Refill Order List page
	And The Take over trolley popup is displayed in Refill Order List page
	When I click on YES button on Take over trolley popup in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page	
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page
	And I include the 'ScanCode' of the newly created GR order to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '2' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page
