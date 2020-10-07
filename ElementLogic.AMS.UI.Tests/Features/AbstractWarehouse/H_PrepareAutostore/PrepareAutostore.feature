Feature: Admin Prepare Autostore
	As an admin user, I want to verify the scenarios related to Prepare Autostore

@Regression
@WarehouseImplementationTest
Scenario: (A) Change the Required Parameters
	Given I login to the AdminModule as 'Admin' user
	And I change the 'AutostoreUrl' parameter value as 'http://localhost:81/AsInterfaceHttp/AutoStoreHttpInterface.aspx'
	And I change the 'Import.Transport' parameter value as 'Fileshare'
	And I change the 'SYS_ALWAYS_ASK_MAXBINQTY' parameter value as '1'
	And I change the 'AutoStore.ShowMessageOnPickNewOrderStart' parameter value as '1'
	And I change the 'Picking.AutoStore.DisplayNewContainer' parameter value as '1'
	And I change the 'PickingAutoPlaceOnTrolleyAfterPick' parameter value as '1'
	And I change the 'MinimumLocationsPerBinForLocationScanningForPicking' parameter value as '1'

@Regression
@WarehouseImplementationTest
Scenario: (B) Reset for Internet Information Services(IIS) Manager 
	Given I Perform a Reset for Internet Information Services(IIS) Manager

@Regression
@WarehouseImplementationTest
Scenario: (C) Perform Autostore Bin synchronization
	Given I login to the AdminModule as 'Admin' user
    And I navigate to Live feed status page
	When I select 'Synchronize bin contents' option from the Gear action menu in Live feed status page
	Then The Synchronize bin contents popup is displayed in Live feed status page
	And I click on Synchronize button on Synchronize bin contents popup in Live feed status page

