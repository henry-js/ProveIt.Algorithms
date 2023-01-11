using System.Diagnostics;

var numbers = Enumerable.Range(1, 5000).ToArray();
var primeFactors = new List<int>();
Stopwatch stopwatch = new();


stopwatch.Start();
numbers = numbers.Where(x => isPrime(x)).ToArray();
stopwatch.Stop();
Array.ForEach(numbers, x =>
{
    Console.WriteLine($"""Is {x} prime? yes""");
});
Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalSeconds}");

bool isPrime(int n)
{
    if (n == 2 || n == 3) return true;
    if (n % 2 == 0 || n % 3 == 0 || n <= 1) return false;
    int divisor = n - 1;
    for (int i = 5; i * i <= n; i += 6)
    {
        if (n % i == 0 || n % (i + 2) == 0) return false;
    }
    return true;
}
