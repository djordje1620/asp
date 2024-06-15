namespace Rentaly.Domain.Entities;
public enum BookingStatus
{
    Canceled = 0,
    Upcoming = 1,
    InProgres = 2,
    Completed = 3
}

public enum ServiceType
{
    OilChange = 0,
    FilterReplacement = 1,
    WheelBalancing = 2,
    TireReplacement = 3,
    BrakeAdjustment = 4,
    EngineRepair = 5
}