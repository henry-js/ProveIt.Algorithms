// See https://aka.ms/new-console-template for more information
namespace CalculationChallenge;

public interface ITemperature
{
    int Max { get; }
    int Min { get; }
    double Avg { get; }

    void Insert(int temp);
    void Insert(string temp);

}

public class Temperature : ITemperature
{
    private readonly List<int> _temps;

    public int Max => _temps.Max();
    public int Min => _temps.Min();
    public double Avg => _temps.Average();


    public Temperature()
    {
        _temps = new();
    }

    public void Insert(int temp)
    {
        _temps.Add(temp);
    }
    public void Insert(string temp)
    {
        if (ParseString(temp) is int stringToInt)
        {
            Insert(stringToInt);
        }
    }

    public int? ParseString(string temp) => temp.ToLower() switch
    {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        "ten" => 10,
        _ => null
    };

}
