using System.Collections;
using System.Text;

var unorderedString = "Hello World";

var result = unorderedString.Select(x => x.ToString()).Order();
var strings = result.Where(a => !a.Equals(" "));
var grouped = from letter in strings
              group letter by letter.ToLowerInvariant() into newList
              orderby newList.Count() descending
              select (new { Letter = newList.Key, Count = newList.Count() });

Console.WriteLine($"Started with: {unorderedString}");
foreach (var val in grouped)
{
    Console.WriteLine($"Letter: {val.Letter}, Count: {val.Count}");
    Console.WriteLine($"");
}
