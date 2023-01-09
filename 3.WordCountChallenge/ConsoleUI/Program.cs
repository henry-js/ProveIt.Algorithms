using System.Text.RegularExpressions;
using ConsoleUi;

string[] tests = new string[]
{
        @"The test of the
            best way to handle

multiple lines,   extra spaces and more.",
        @"Using the starter app, create code that will
loop through the strings and identify the total
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
};

/*
    First string (tests[0]) Values:
    Total Words: 14
    Total Characters: 89
    Character count (minus line returns and spaces): 60
    Most used word: the (2 times)
    Most used character: e (10 times)

    Second string (tests[1]) Values:
    Total Words: 45
    Total Characters: 276
    Character count (minus line returns and spaces): 230
    Most used word: the (6 times)
    Most used character: t (24 times)
*/



foreach (var testString in tests)
{
    var stats = GetStatistics(testString);
    Console.WriteLine(stats);
}

StringStats GetStatistics(string testString)
{
    var words = WordRegex().Split(testString).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
    var joinedWords = string.Join(null, words);

    var carriageReturns = CarriageRegex().Count(testString);
    var characterCount = CharacterRegex().Count(testString);
    var whitespaceCount = WhitespaceRegex().Count(testString);
    (string word, int count) mostUsedWord = ("", 0);
    (char character, int count) mostUsedChar = (default, 0);
    Array.ForEach(words, word =>
    {
        var count = words.Count(x => string.Equals(x, word, StringComparison.InvariantCultureIgnoreCase));
        if (mostUsedWord.count < count)
        {
            mostUsedWord.word = word;
            mostUsedWord.count = count;
        }
    });
    Array.ForEach(joinedWords.ToCharArray(), character =>
    {
        var count = joinedWords.Count(x => x == character);
        if (mostUsedChar.count < count)
        {
            mostUsedChar.character = character;
            mostUsedChar.count = count;
        }
    });
    return new StringStats
        (
            Words: words,
            UniqueWords: words.Distinct(),
            TotalWordCount: words.Length,
            TotalCharacterCount: characterCount + whitespaceCount,
            CharacterCount: characterCount,
            MostUsedWord: mostUsedWord,
            MostUsedCharacter: mostUsedChar
        )
    ;
}
Console.ReadLine();

partial class Program
{
    [GeneratedRegex("\\W")]
    private static partial Regex WordRegex();
}

partial class Program
{
    [GeneratedRegex("\\r\\n")]
    private static partial Regex CarriageRegex();
}

partial class Program
{
    [GeneratedRegex("\\S")]
    private static partial Regex CharacterRegex();
}

partial class Program
{
    [GeneratedRegex("[^\\w\\n]")]
    private static partial Regex WhitespaceRegex();
}
