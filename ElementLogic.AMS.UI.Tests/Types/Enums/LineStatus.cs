namespace AutoStoreManagementSystem.UITests.Types.Enums
{
    public enum LineStatus
    {
        None = -1,
        WithoutLocation = 0,
        AssignedLocation = 1,
        Prepared = 2,
        AssignedUser = 3,
        RetrievedFromLocation = 4,
        PutInBox = 5,
        Controller = 6,
        PreConfiguration = 7,
        ReadyForConsolidation = 8,
        DeliveredToConsolidation = 9,
        PostConfiguration = 10,
        ReadyForPacking = 11,
        DeliveredPack = 12,
        Putaway = 14,
        Completed = 17
    }
}
