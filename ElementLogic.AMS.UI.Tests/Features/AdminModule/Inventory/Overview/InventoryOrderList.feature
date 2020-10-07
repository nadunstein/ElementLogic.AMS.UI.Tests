Feature: Admin Inventory Order List
	As an admin user, I want to verify the scenarios related to Admin Inventory Order List page

@Regression
@Admin_InventoryOrderList_MaxLocationInTaskgroup_Scenario01
Scenario: Verify Inventory taskgroup preparation when Product location count is less than MaxlocationInTaskgroup value
	Given I login to the AdminModule as 'Admin' user
	And I navigate to the Inventory order list page
	When I click on the inventory add button of the Inventory order list page
	Then The Inventory details page is loaded
	And I verify Maximum lines per taskgroup field value is '10' in the Inventory details page
	And I include the productId as 'ASINVP01' to the FromProductId field in the Inventory details page
	When I click on the Add button in the Inventory details page
	Then The Inventory count confirmation dialog is displayed in the Inventory details page
	And I verify the Total taskgroup count is '1' on inventory count confirmation dialog in the Inventory details page
	When I click on the Yes button on inventory count confirmation dialog in the Inventory details page
	Then The inventory record is added to the inventory details grid in the Inventory details page
	And I verify '1' inventory task groups have been created and added to the inventory details grid in the Inventory details page
	When I click on Taskgroup expander for the inventory taskgroup on inventory details grid in the Inventory details page
	Then Inventory missions belongs to the taskgroup are listed on inventory details grid in the Inventory details page
	And  I verify '2' inventory missions are listed on inventory details grid in the Inventory details page
	And I click on Remove button in the Inventory details page
	Then The Inventory order list page is loaded

@Regression
@Admin_InventoryOrderList_MaxLocationInTaskgroup_Scenario02
Scenario:  Verify Inventory taskgroup preparation when Product location count is grater than MaxlocationInTaskgroup value
	Given I login to the AdminModule as 'Admin' user	
	And I navigate to the Inventory order list page
	When I click on the inventory add button of the Inventory order list page
	Then The Inventory details page is loaded
	And I verify Maximum lines per taskgroup field value is '2' in the Inventory details page
	And I include the productId as 'ASINVP02' to the FromProductId field in the Inventory details page
	When I click on the Add button in the Inventory details page
	Then The Inventory count confirmation dialog is displayed in the Inventory details page
	And I verify the Total taskgroup count is '2' on inventory count confirmation dialog in the Inventory details page
	When I click on the Yes button on inventory count confirmation dialog in the Inventory details page
	Then The inventory record is added to the inventory details grid in the Inventory details page
	Then I verify '2' inventory task groups have been created and added to the inventory details grid in the Inventory details page
	And I click on Remove button in the Inventory details page
	Then The Inventory order list page is loaded