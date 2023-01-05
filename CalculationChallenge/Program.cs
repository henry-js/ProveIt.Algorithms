// See https://aka.ms/new-console-template for more information
using CalculationChallenge;

ITemperature tempReader = new Temperature();
// var randomizer = new Random();
// var temps = Enumerable.Range(1, 100).Select(x => randomizer.Next(0, 101)).ToArray();
// Array.ForEach(temps, tempReader.Insert);

tempReader.Insert("invalid");
tempReader.Insert("invalid");
tempReader.Insert("invalid");
tempReader.Insert("invalid");
Console.WriteLine($"{"Average:",-9} {tempReader.Avg}");
Console.WriteLine($"{"Max:",-9} {tempReader.Max}");
Console.WriteLine($"{"Min:",-9} {tempReader.Min}");
