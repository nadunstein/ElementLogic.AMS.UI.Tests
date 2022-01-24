Feature: Autostore Inventory with HandlingUnit
	As an admin user, I want to verify the scenarios related to Autostore Inventory with HandlingUnit

Background: 
	Given I login to the AdminModule as 'Admin' user
	And I navigate to the Inventory order list page
	When I click on Search button in Inventory order list page
	Then The inventory record is listed on the inventory details grid in Inventory order list page
	And I verify the taskgroup count for the inventory order list is correct on the inventory details grid in Inventory order list page
	And I click on the Activate menu item for the inventory activity in Inventory order list page

@Regression
@Inventory
@Scenario:'1'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (A)Perform an Autostore Inventory with Handling Units which physically on location, known to eManager and in HU counting list
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T100001' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T100001' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T100002' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded

@Regression
@Inventory
@Scenario:'2'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (B)Perform an Autostore Inventory with Handling Units which physically on location, known to eManager and not in HU counting list
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T200001' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T200001' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T200002' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Unexpected Handling Unit popup is displayed in Autostore inventory mission page
	When I click on 'Remove from bin' button on Unexpected Handling Unit popup in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded

@Regression
@Inventory
@Scenario:'3'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (C)Perform an Autostore Inventory with Handling Units which physically on location, unknown to eManager and not in HU counting list
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T300001' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T300001' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T300002' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Unexpected Handling Unit popup is displayed in Autostore inventory mission page
	When I click on 'Remove from bin' button on Unexpected Handling Unit popup in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded

@Regression
@Inventory
@Scenario:'4'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (D)Perform an Autostore Inventory with Handling Units which physically on location, unknown to eManager and in HU counting list
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T400001' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T400001' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T400002' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T400002' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded

@Regression
@Inventory
@Scenario:'5'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (E)Perform an Autostore Inventory with Handling Units which physically not on location, known to eManager and in HU counting list
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T500001' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T500001' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then The Handling Units Missing popup is displayed in Autostore inventory mission page with following details
	| HandlingUnitScanCode	| Quantity	|
	|HU-T500002				|20			|
	When I click on 'Confirm Missing' button on Handling Units Missing popup in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded

@Regression
@Inventory
@Scenario:'6'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (F)Perform an Autostore Inventory with Handling Units which physically not on location, known to eManager and not in HU counting list
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T600001' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T600001' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then The Handling Units Missing popup is displayed in Autostore inventory mission page with following details
	| HandlingUnitScanCode	| Quantity	|
	|HU-T600002				|20			|
	When I click on 'Confirm Missing' button on Handling Units Missing popup in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded 

@Regression
@Inventory
@Scenario:'7'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (G)Perform an Autostore Inventory with Handling Units which physically not on location, unknown to eManager and in HU counting list
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the Handling unit scan code as 'HU-T700001' to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	And I verify the confirmed handling unit is displayed as 'HU-T700001' in Autostore inventory mission page
	#And I include the Handling Unit quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded 

@Regression
@Inventory
@Scenario:'8'
@InventoryTaskgroupCount:'1'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (H)Perform an Autostore Inventory with Handling Units which one Handling Unit found in a different bin for the product
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I scan all the Handling units except one in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page
	When I click on Location Complete button in Autostore inventory mission page
	Then The Handling Units Missing popup is displayed in Autostore inventory mission page
	When I click on 'Confirm Missing' button on Handling Units Missing popup in Autostore inventory mission page
	Then The Autostore inventory mission '2' is loaded
	And I scan all the Handling units in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page
	And I include the Handling unit which was missing in previous bin to the Handling unit scan code field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Handling Unit quantity field is displayed in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '2' is loaded
	When I click on Location Complete button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded

@Regression
@Inventory
@Scenario:'9'
@InventoryTaskgroupCount:'2'
@Autostore:Inventory:InventoryHandlingUnit
Scenario: (I)Verify the inventory taskgroups are prepared according to the MaxLocationsInTaskgroup parameter
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I scan all the Handling units in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page
	When I click on Location Complete button in Autostore inventory mission page
	Then The Autostore inventory mission '2' is loaded
	And I scan all the Handling units in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page
	When I click on Location Complete button in Autostore inventory mission page
	Then The Autostore inventory mission '1' is loaded
	And I scan all the Handling units in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page
	When I click on Location Complete button in Autostore inventory mission page
	Then The Autostore inventory mission '2' is loaded
	And I scan all the Handling units in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page
	When I click on Location Complete button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded