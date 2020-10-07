Feature: Autostore Pick and placing Scan Fields
	As an admin user, I want to verify the focus and availability of pick and placing Scan field in AutoStore Pick

@Pick
@AS_Pick_PickPlaceScanField_WhenOrderlineHasScancode
Scenario: Verify the container scan field is displayed if the orderline has a scancode in Place in Container page
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I verify the focus is on the scan value field in AutoStore Place in Container page
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu should be loaded

@Pick
@AS_Pick_PickPlaceScanField_WhenMoreThanOneOpenContainer
Scenario: Verify the container scan field is displayed if the activity has more than one open container in Place in Container page
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I add 'Box1' container by clicking on New Container button in Autostore Pick Mission page
	Then The successfully added a new container notification is displayed in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I verify the focus is on the scan value field in AutoStore Place in Container page
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu should be loaded

@Pick
@AS_Pick_PickPlaceScanField_WhenPickActivityHasMultipleShipments
Scenario: Verify the placing scan field is displayed if the pick activity has multiple shipments
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I verify the focus is on the scan value field in AutoStore Place in Container page
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore pick mission '2' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore pick mission '3' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore pick mission '4' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu should be loaded

@Pick
@AS_Pick_PickPlaceScanField_WhenPickActivityDoesNotHaveMultipleShipments
Scenario: Verify the Place in Container page is not displayed if the pick activity does not have multiple shipments
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu should be loaded

@Pick
@AS_Pick_PickPlaceScanField_WhenOnlyOneOpenContainer
Scenario: Verify the Place in Container page is not displayed if the activity has only one open container
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu should be loaded