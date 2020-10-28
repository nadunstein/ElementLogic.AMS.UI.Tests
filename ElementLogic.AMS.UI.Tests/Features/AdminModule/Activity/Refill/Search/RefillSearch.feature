Feature: Admin Refill Search
	As an admin user, I want to Verify the item can be scanned to the refill trolley
	with Product Id, Producer Product Id, Vendor Product Id, EAN Id and Purchase Id

Background:
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Refill Order List page in Admin Module
	And I select a trolley from Trolley drop down in Refill Order List page

@Regression
@Scenario:'1'
@AdminModule:Activity:Refill:Search
Scenario: Verify refill item can be searched by Product Id
	Given I include the 'Product Id' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page

@Regression
@Scenario:'2'
@AdminModule:Activity:Refill:Search
Scenario: Verify refill item can be searched by Producer Product Id
	Given I include the 'Producer Product Id' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page

@Regression
@Scenario:'3'
@AdminModule:Activity:Refill:Search
Scenario: Verify refill item can be searched by Vendor Product Id
	Given I include the 'Vendor Product Id' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page

@Regression
@Scenario:'4'
@AdminModule:Activity:Refill:Search
Scenario: Verify refill item can be searched by EAN Id
	Given I include the 'EAN Id' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page

@Regression
@Scenario:'5'
@AdminModule:Activity:Refill:Search
Scenario: Verify refill item can be searched by Purchase Id
	Given I include the 'Purchase Id' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page
