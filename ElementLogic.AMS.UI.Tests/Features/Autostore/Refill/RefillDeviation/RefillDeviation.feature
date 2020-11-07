Feature: Autostore Refill Deviation
	As an admin user, I want to Verify the Autostore Refill Deviation related Scenarios

Background:
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Refill Order List page
	And I select a trolley from Trolley drop down in Refill Order List page
	And I include the 'ScanCode' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page
	When I click on Activate button in Refill Order List page
	Then The Refill Order List page is loaded with empty records on the fields

@Regression
@Scenario:'1'
@Autostore:Refill:RefillDeviation
Scenario: Verify A New Mission is Created upon Refill Deviation On Last Mission using Existing Locations
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Refill tile in Autostore main menu
	Then I Navigate to refill taskgroup selection page in Autostore
	When I click on Select button from refill taskgroup selection page in Autostore
	Then The Autostore Refill mission '1' is loaded    
	And I check the refill product Id is correct in Autostore Refill mission page
	And I check the Refill Product Quantity is '10' in Autostore Refill mission page
    And I check the proposed refill bin is NOT an empty bin in Autostore Refill mission page
	And I change the refill quantity as '5' in Autostore Refill mission page
	When I click on Confirm button in Autostore Refill mission page
	Then The Change Quantity Dialog is displayed in Autostore Refill mission page
	When I click on Yes button on Change Quantity Dialog in Autostore Refill mission page
	Then The Confirm Remaining Refill Dialog is displayed in Autostore Refill mission page
	When I click on Yes button on Confirm Remaining Refill Dialog in Autostore Refill mission page
	Then The Autostore task Menu is loaded
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Refill Order List page
	And I select a trolley from Trolley drop down in Refill Order List page
	And I include the 'ScanCode' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page
	When I click on Activate button in Refill Order List page
	Then The Refill Order List page is loaded with empty records on the fields
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Refill tile in Autostore main menu
	Then I Navigate to refill taskgroup selection page in Autostore
	When I click on Select button from refill taskgroup selection page in Autostore
	Then The Autostore Refill mission '1' is loaded
	And I check the refill product Id is correct in Autostore Refill mission page
	And I check the Refill Product Quantity is '5' in Autostore Refill mission page
	And I check the proposed refill bin is NOT an empty bin in Autostore Refill mission page
	When I click on Confirm button in Autostore Refill mission page
	Then The Autostore task Menu is loaded

@Regression
@Scenario:'2'
@Autostore:Refill:RefillDeviation
Scenario: Perform a Refill Deviation On Last Mission to an Empty Location
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Refill tile in Autostore main menu
	Then I Navigate to refill taskgroup selection page in Autostore
	When I click on Select button from refill taskgroup selection page in Autostore
	Then The Autostore Refill mission '1' is loaded
	And I check the refill product Id is correct in Autostore Refill mission page
	When I click on Confirm button in Autostore Refill mission page
	Then The Autostore Refill mission '2' is loaded
	And I check the proposed refill bin is an empty bin in Autostore Refill mission page
	And I check the Refill Product Quantity is '20' in Autostore Refill mission page
	And I change the refill quantity as '15' in Autostore Refill mission page
	When I click on Confirm button in Autostore Refill mission page
	Then The Change Quantity Dialog is displayed in Autostore Refill mission page
	When I click on Yes button on Change Quantity Dialog in Autostore Refill mission page
	Then The Confirm Remaining Refill Dialog is displayed in Autostore Refill mission page
	When I click on Yes button on Confirm Remaining Refill Dialog in Autostore Refill mission page
	Then The Autostore task Menu is loaded
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Refill Order List page
	And I select a trolley from Trolley drop down in Refill Order List page
	And I include the 'ScanCode' to the scan Id field in Refill Order List page
	When I click on Confirm button in Refill Order List page
	Then The No. of Items on the Trolley field value is displayed as '1' in Refill Order List page
	When I Click on View Items button in Refill Order List page
	Then The Refill item(s) are listed under the grid in Refill Order List page
	And I check the correct Refill product(s) are displayed in the view item grid in Refill Order List page
	When I click on Activate button in Refill Order List page
	Then The Refill Order List page is loaded with empty records on the fields
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Refill tile in Autostore main menu
	Then I Navigate to refill taskgroup selection page in Autostore
	When I click on Select button from refill taskgroup selection page in Autostore
	Then The Autostore Refill mission '1' is loaded
	And I check the refill product Id is correct in Autostore Refill mission page
	And I check the Refill Product Quantity is '5' in Autostore Refill mission page
	And I check the proposed refill bin is an empty bin in Autostore Refill mission page
	When I click on Confirm button in Autostore Refill mission page
	Then The Autostore task Menu is loaded
