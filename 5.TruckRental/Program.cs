// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int rentForMins = 310;
float cost = CalculateRentalCost(requestedRentalTimeMins: rentForMins);

Console.WriteLine($"Cost to rent truck for {rentForMins} minutes: £{cost}");

float CalculateRentalCost(int requestedRentalTimeMins, int initialPeriodCost = 25, int initialPeriodMins = 60, int chargePerPeriod = 50, int rentalPeriodMins = 60, int roundUpAfter = 10)
{
    bool roundUp;
    float finalCost = default;
    int actualRentalTime;
    var leftoverTime = requestedRentalTimeMins % rentalPeriodMins;
    roundUp = leftoverTime >= roundUpAfter;

    if (roundUp)
    {
        actualRentalTime = requestedRentalTimeMins - leftoverTime + rentalPeriodMins;
    }
    else
    {
        actualRentalTime = requestedRentalTimeMins;
    }
    finalCost += initialPeriodCost;
    actualRentalTime -= initialPeriodMins;
    while (actualRentalTime != 0)
    {
        actualRentalTime -= rentalPeriodMins;
        finalCost += chargePerPeriod;
    }

    return finalCost;
}
