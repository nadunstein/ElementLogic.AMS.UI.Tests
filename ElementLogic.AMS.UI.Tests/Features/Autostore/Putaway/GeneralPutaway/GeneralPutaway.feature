Feature: Autostore Putaway General
	As a user, I want to verify the scenarios related to Autostore general putaway

@Regression
@AS_Putaway_GeneralPutaway
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
	When I click on enter button after include max location quantity in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page
	And I check the focus is on quantity field in Autostore putaway mission page
	When I click enter button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page
	And I check the focus is on quantity field in Autostore putaway mission page
	When I click enter button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page

@Regression
@AS_Putaway_VerifyProductImage
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
	When I click on enter button after include max location quantity in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page	
	And I verify the putaway product image is displayed in Autostore putaway mission page
	And I check the focus is on scan field in Autostore putaway mission page
	And I include the scan value to Scan value field in Autostore putaway mission page
	When I click enter button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page
