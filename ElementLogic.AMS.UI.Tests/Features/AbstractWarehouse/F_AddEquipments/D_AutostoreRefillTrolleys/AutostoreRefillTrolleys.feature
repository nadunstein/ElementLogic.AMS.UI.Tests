Feature: Admin Add Autostore Refill Trolleys
	As an admin user, I want to verify the scenarios related to Add Autostore Refill Trolleys

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 01 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT1               |
	| Name                | Refill Trolley 01 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 01' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 02 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT2               |
	| Name                | Refill Trolley 02 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 02' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 03 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT3               |
	| Name                | Refill Trolley 03 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 03' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 04 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT4               |
	| Name                | Refill Trolley 04 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 04' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 05 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT5               |
	| Name                | Refill Trolley 05 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 05' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 06 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT6               |
	| Name                | Refill Trolley 06 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 06' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 07 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT7               |
	| Name                | Refill Trolley 07 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 07' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 08 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT8               |
	| Name                | Refill Trolley 08 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 08' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 09 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT9               |
	| Name                | Refill Trolley 09 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 09' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 10 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT10              |
	| Name                | Refill Trolley 10 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 10' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 11 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT11              |
	| Name                | Refill Trolley 11 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 11' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 12 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT12              |
	| Name                | Refill Trolley 12 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 12' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for Refill Trolley 13 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | RT13              |
	| Name                | Refill Trolley 13 |
	| Warehouse zone      | Transport Putaway |
	| Type                | Refill            |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	| Task type           | Refill            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value     |
	| Shelves       | 10        |
	| Type          | Transport |
	| Location size | Refill    |
	| Positions     | 1         |
	| Depths        | 1         |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'Refill Trolley 13' Equipment is listed in the search result grid in Equipment list page