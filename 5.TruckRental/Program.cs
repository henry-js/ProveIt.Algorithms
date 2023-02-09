int rentForMins = 190;
var fromDate = DateTime.UtcNow;
var toDate = fromDate.AddMinutes(rentForMins);
decimal cost = CalculateRentalCost(fromDate, toDate);

Console.WriteLine($"Cost to rent truck for {rentForMins} minutes: {cost:C}");

decimal CalculateRentalCost(DateTime From, DateTime To)
{
    decimal finalCost = 0;
    var requestedRentalTime = To - From;
    var remainingTime = requestedRentalTime.Subtract(new TimeSpan(0, RentalDefaults.initialPeriodMins, 0));
    finalCost += RentalDefaults.initialPeriodCost;
    if (remainingTime.TotalMinutes <= 0)
    {
        return finalCost;
    }
    while (remainingTime.TotalMinutes > 0)
    {
        if (remainingTime.TotalMinutes >= 10)
        {
            remainingTime = remainingTime.Subtract(new TimeSpan(0, RentalDefaults.standardPeriodMins, 0));
            finalCost += RentalDefaults.standardPeriodCost;
        }
        else
        {
            return finalCost;
        }

    }
    // finalCost
    // var standardPeriodMins = RentalDefaults.standardPeriodMins;
    // var initialPeriodCost = RentalDefaults.initialPeriodCost;
    // var initialPeriodMins = RentalDefaults.initialPeriodMins;
    // var roundUpAfter = RentalDefaults.roundUpAfter;
    // var standardPeriodCost = RentalDefaults.standardPeriodCost;
    // bool roundUp;
    // double actualRentalTime;
    // var leftoverTime = requestedRentalTime.Minutes % standardPeriodMins;
    // roundUp = leftoverTime >= roundUpAfter;

    // actualRentalTime = roundUp ? requestedRentalTime.Minutes - leftoverTime + standardPeriodMins : requestedRentalTime.Minutes;
    // finalCost += initialPeriodCost;
    // actualRentalTime -= initialPeriodMins;
    // while (actualRentalTime != 0)
    // {
    //     actualRentalTime -= standardPeriodMins;
    //     finalCost += standardPeriodCost;
    // }

    return finalCost;
}
public static class RentalDefaults
{
    public static readonly decimal initialPeriodCost = 25M;
    public static readonly decimal standardPeriodCost = 50M;
    public static readonly int initialPeriodMins = 60;
    public static readonly int standardPeriodMins = 60;
    public static readonly int roundUpAfter = 10;
}
