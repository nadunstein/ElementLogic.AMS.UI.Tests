Feature: Autostore Pick Deviation
	As an admin user, I want to verify Autostore Pick Deviation related scenarios

@Pick
@Regression
@Scenario:'1'
@Autostore:Pick:PickDeviation
Scenario: Verify the pick deviation on the last mission adds new mission to the taskgroup
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I change the quantity of the Quantity field as '15' in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The pick Change Quantity popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Change Quantity popup in Autostore Pick Mission page
	Then The Empty location popup is displayed In Autostore Pick Mission page
	When I click on 'Yes' button on Empty location popup in Autostore Pick Mission page
	Then The Autostore pick mission '3' is loaded
	And I verify the Quantity field value is '5' in Autostore Pick Mission page
	And The possible delay notification is displayed in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'2'
@Autostore:Pick:PickDeviation
Scenario: Verify the pick deviation on the last mission with a zero pick adds new mission to the taskgroup
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I change the quantity of the Quantity field as '0' in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The pick Change Quantity popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Change Quantity popup in Autostore Pick Mission page
	Then The Empty location popup is displayed In Autostore Pick Mission page
	When I click on 'Yes' button on Empty location popup in Autostore Pick Mission page
	Then The Autostore pick mission '3' is loaded
	And I verify the Quantity field value is '20' in Autostore Pick Mission page
	And The possible delay notification is displayed in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded