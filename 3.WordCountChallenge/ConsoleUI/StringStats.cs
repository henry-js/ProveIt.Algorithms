namespace ConsoleUi;
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






public record StringStats(int TotalCharacterCount, int CharacterCount, (string Word, int Count) MostUsedWord, (char Character, int Count) MostUsedCharacter, string[] Words, IEnumerable<string> UniqueWords, int TotalWordCount);
