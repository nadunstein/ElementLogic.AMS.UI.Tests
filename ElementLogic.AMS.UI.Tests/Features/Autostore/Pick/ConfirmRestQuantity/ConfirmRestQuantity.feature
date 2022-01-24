Feature: Autostore Pick Confirm Remaining Quantity
	As an admin user, I want to Verify confirming Remaining Quantity while picking

@Pick
@Regression
@Scenario:'1'
@Autostore:Pick:ConfirmRestQuantity
Scenario: Verify the Confirm Quantity popup is not displayed when quantity verification threshold value is less than location quantity
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'2'
@Autostore:Pick:ConfirmRestQuantity
Scenario: Verify confirming the remaining quantity with the correct rest quantity on Confirm Quantity popup 
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Confirm Quantity popup is displayed in Autostore Pick Mission page
	And I include the Quantity as '5' to the quantity field on Confirm Quantity popup in Autostore Pick Mission page
	When I click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'3'
@Autostore:Pick:ConfirmRestQuantity
Scenario: Verify confirming the remaining quantity which differs from expected rest quantity on Confirm Quantity popup
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Confirm Quantity popup is displayed in Autostore Pick Mission page
	And I include the Quantity as '10' to the quantity field on Confirm Quantity popup in Autostore Pick Mission page
	When I click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page
	Then The Remaining Quantity Changed popup is displayed in Autostore Pick Mission page
	And I verify the quantity is '10' on Remaining Quantity Changed popup in Autostore Pick Mission page
	When I click 'Yes' button on Remaining Quantity Changed popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'4'
@Autostore:Pick:ConfirmRestQuantity
Scenario: Verify remaining quantity is displayed in Confirm Quantity popup based on the parameter
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Confirm Quantity popup is displayed in Autostore Pick Mission page
	And I verify the remaining quantity is displayed as '5' on Confirm Quantity popup in Autostore Pick Mission page
	And I include the Quantity as '10' to the quantity field on Confirm Quantity popup in Autostore Pick Mission page
	When I click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'5'
@Autostore:Pick:ConfirmRestQuantity
Scenario: Verify remaining quantity is not displayed in Confirm Quantity popup based on the parameter
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Confirm Quantity popup is displayed in Autostore Pick Mission page
	And I verify the remaining quantity is not displayed on Confirm Quantity popup in Autostore Pick Mission page
	And I include the Quantity as '10' to the quantity field on Confirm Quantity popup in Autostore Pick Mission page
	When I click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page
	Then The Remaining Quantity Changed popup is displayed in Autostore Pick Mission page
	When I click 'No' button on Remaining Quantity Changed popup in Autostore Pick Mission page
	Then The Confirm Quantity popup is displayed in Autostore Pick Mission page
	And I verify the remaining quantity is not displayed on Confirm Quantity popup in Autostore Pick Mission page
	And I include the Quantity as '5' to the quantity field on Confirm Quantity popup in Autostore Pick Mission page
	When I click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded