Feature: Autostore Pick Finish Orders
	As an admin user, I want to verify finishing autostore pick orders related Scenarios

@Pick
@Scenario:'1'
@Autostore:Pick:FinishOrders
Scenario: Verify pick order in Ready state can be finished from Picklist Search page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Picklist Search page
	Then The Picklist Search page is loaded
	Then I include a picklist Id to the picklistId field in Picklist Search page
	When I click on Search button in Picklist Search page
	Then The pick order is displayed in the search grid in Picklist Search page
	When I click on 'Finish' option by selecting the gear icon of the pick order in the search grid in Picklist Search page
	Then I verify the order status is '17 - Complete' for the pick order in the search grid in Picklist Search page

@Pick
@Scenario:'2'
@Autostore:Pick:FinishOrders
Scenario: Verify pick order with more than one mission in Ready state can be finished from Picklist Search page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Picklist Search page
	Then The Picklist Search page is loaded
	Then I include a picklist Id to the picklistId field in Picklist Search page
	When I click on Search button in Picklist Search page
	Then The pick order is displayed in the search grid in Picklist Search page
	When I click on 'Finish' option by selecting the gear icon of the pick order in the search grid in Picklist Search page
	Then I verify the order status is '17 - Complete' for the pick order in the search grid in Picklist Search page

@Pick
@Scenario:'3'
@Autostore:Pick:FinishOrders
Scenario: Verify pick order in Prepared state can be finished from Picklist Search page
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	When I click on Exit button in Autostore Pick Mission page
	Then The Autostore task Menu is displayed
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Picklist Search page
	Then The Picklist Search page is loaded
	And I include a picklist Id to the picklistId field in Picklist Search page
	When I click on Search button in Picklist Search page
	Then The pick order is displayed in the search grid in Picklist Search page
	When I click on 'Finish' option by selecting the gear icon of the pick order in the search grid in Picklist Search page
	Then I verify the order status is '17 - Complete' for the pick order in the search grid in Picklist Search page

@Pick
@Scenario:'4'
@Autostore:Pick:FinishOrders
Scenario: Verify pick mission in AssignedUser state can be finished from User Activity page
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	When I click on Exit button in Autostore Pick Mission page
	Then The Confirm Task Exit popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Confirm Task Exit popup in Autostore Pick Mission page
	Then The Autostore task Menu is displayed
	Given I navigate to User Activity page
	Then The User Activity page is loaded
	And I include Taskgroup id to the Task group ID field in User Activity page
	When I click on Search button in User Activity page
	Then The user activity is displayed in the search grid in User Activity page
	When I click on 'Finish' option by selecting the gear icon of the mission for the user activity in status '03 - Assigned user' in User Activity page
	Then The Started Missions popup is displayed in User Activity Page
	When I click on 'Yes' button on Started Missions popup in User Activity Page
	Then I verify the mission statuses are correct in User Activity page