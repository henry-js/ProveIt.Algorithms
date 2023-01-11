int rentForMins = 310;
var fromDate = DateTime.UtcNow;
var toDate = fromDate.AddMinutes(rentForMins);
float cost = CalculateRentalCost(fromDate, toDate);

Console.WriteLine($"Cost to rent truck for {rentForMins} minutes: £{cost}");

float CalculateRentalCost(DateTime From, DateTime To)
{
    var requestedRentalTime = To - From;
    var requestedRentalTimeMins = requestedRentalTime.TotalMinutes;
    var standardPeriodMins = RentalDefaults.standardPeriodMins;
    var initialPeriodCost = RentalDefaults.initialPeriodCost;
    var initialPeriodMins = RentalDefaults.initialPeriodMins;
    var roundUpAfter = RentalDefaults.roundUpAfter;
    var standardPeriodCost = RentalDefaults.standardPeriodCost;
    bool roundUp;
    float finalCost = default;
    double actualRentalTime;
    var leftoverTime = requestedRentalTimeMins % standardPeriodMins;
    roundUp = leftoverTime >= roundUpAfter;

    if (roundUp)
    {
        actualRentalTime = requestedRentalTimeMins - leftoverTime + standardPeriodMins;
    }
    else
    {
        actualRentalTime = requestedRentalTimeMins;
    }
    finalCost += initialPeriodCost;
    actualRentalTime -= initialPeriodMins;
    while (actualRentalTime != 0)
    {
        actualRentalTime -= standardPeriodMins;
        finalCost += standardPeriodCost;
    }

    return finalCost;
}
public static class RentalDefaults
{
    public static readonly int initialPeriodCost = 25;
    public static readonly int initialPeriodMins = 60;
    public static readonly int standardPeriodCost = 50;
    public static readonly int standardPeriodMins = 60;
    public static readonly int roundUpAfter = 10;
}
