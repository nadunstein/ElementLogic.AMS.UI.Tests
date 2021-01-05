Feature: Autostore Putaway General
	As a user, I want to verify the scenarios related to Autostore general putaway

@Regression
@Scenario:'1'
@Autostore:Putaway:GeneralPutaway
Scenario: Verify normal autostore putaway with multiple missions
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And The quantity field value should be '15' in Autostore putaway quantity confirm popup
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page
	And I check the focus is on quantity field in Autostore putaway mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page
	And I check the focus is on quantity field in Autostore putaway mission page
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page

@Regression
@Scenario:'2'
@Autostore:Putaway:GeneralPutaway
Scenario: Verify user can view the product image by performing Putaway with multi location bin
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'B 1/2 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASVIP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And The quantity field value should be '10' in Autostore putaway quantity confirm popup
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page	
	And I verify the putaway product image is displayed in Autostore putaway mission page
	And I verify the scan field is displayed in AutoStore putaway mission page
	And I verify the focus is on scan field in Autostore putaway mission page
	And I include the product scan value to scan field in Autostore putaway mission page
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page

@Regression
@Scenario:'3'
@Autostore:Putaway:GeneralPutaway
Scenario: Verify Autostore putaway for same product with multiple taskgroups
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'B 1/2 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASMOPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The '2' putaway orders are listed for product in Autostore Putaway Selection page
	When I click on first Select button of the product 'ASMOPP01' from order list in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page
	And I Include Product Id as 'ASMOPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I verify max location quantity value is '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page
