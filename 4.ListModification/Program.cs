using ListModificationChallenge;
using Spectre.Console;

// DO NOT MODIFY THIS METHOD - if something isn't working, it means you haven't completed a method correctly
List<PersonModel> sampleList = CreateSampleList();
List<PersonModel> results;

// Goal Section
Console.WriteLine("Standard Challenge Section");
Console.WriteLine();

results = InsertRecordLastIntoNewList(sampleList);
Console.Write("Insert record Last into new list: ");
if (results.Count > sampleList.Count && results[results.Count - 1].FullName == "Brown, Greg")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

sampleList = CreateSampleList();
results = InsertRecordFirstIntoNewList(sampleList);
Console.Write("Insert record First into new list: ");
if (results.Count > sampleList.Count && results[0].FullName == "Brown, Greg")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

sampleList = CreateSampleList();
results = InsertRecordInTheMiddleIntoNewList(sampleList);
Console.Write("Insert record in the middle into new list: ");
if (results.Count > sampleList.Count && results[3].FullName == "Brown, Greg")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

sampleList = CreateSampleList();
results = SortAndReturnANewList(sampleList);
Console.Write("Sort a list into a new list: ");
if (results[1].LastName == "Jones" && sampleList[1].LastName == "Storm")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

// Bonus Section
Console.WriteLine();
Console.WriteLine("Bonus Challenge Section");
Console.WriteLine();

sampleList = CreateSampleList();
InsertRecordLastIntoList(sampleList);
Console.Write("Insert record Last into existing list: ");
if (sampleList.Count == 6 && sampleList[5].FullName == "Brown, Greg")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

sampleList = CreateSampleList();
InsertRecordFirstIntoList(sampleList);
Console.Write("Insert record First into existing list: ");
if (sampleList.Count == 6 && sampleList[0].FullName == "Brown, Greg")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

sampleList = CreateSampleList();
InsertRecordInTheMiddleOfTheList(sampleList);
Console.Write("Insert record in the middle into existing list: ");
if (sampleList.Count == 6 && sampleList[3].FullName == "Brown, Greg")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

sampleList = CreateSampleList();
SortAList(sampleList);
Console.Write("Sort an existing list: ");
if (sampleList[1].LastName == "Jones")
{
    AnsiConsole.MarkupLine("[green]Passed[/]");
}
else
{
    AnsiConsole.MarkupLine("[red]Failed[/]");
}

// Console.ReadLine();

#region Standard Challenge
List<PersonModel> InsertRecordLastIntoNewList(List<PersonModel> people)
{
    List<PersonModel> output;
    PersonModel newPerson = new() { FirstName = "Greg", LastName = "Brown" };

    output = new List<PersonModel>(people)
    {
        newPerson
    };
    return output;
}

List<PersonModel> InsertRecordFirstIntoNewList(List<PersonModel> people)
{
    List<PersonModel> output;
    PersonModel newPerson = new() { FirstName = "Greg", LastName = "Brown" };

    output = new List<PersonModel>()
    {
        newPerson
    };
    output.AddRange(people);

    return output;
}

List<PersonModel> InsertRecordInTheMiddleIntoNewList(List<PersonModel> people)
{
    List<PersonModel> output;
    PersonModel newPerson = new PersonModel { FirstName = "Greg", LastName = "Brown" };

    // TODO: Add a record after Paul Jones in the incoming list and return a new list that includes newPerson
    // HACK: The following line is incorrect but is used to get this to compile
    var index = people.FindIndex(x => x.FirstName == "Paul" && x.LastName == "Jones");
    output = new(people);
    output.Insert(index + 1, newPerson);

    return output;
}

List<PersonModel> SortAndReturnANewList(List<PersonModel> people)
{
    List<PersonModel> output;

    // TODO: Sort the incoming list values by fullname (ascending) and return a new list
    // HACK: The following line is incorrect but is used to get this to compile
    output = people;

    return output.OrderBy(x => x.FullName).ToList();
}
#endregion

#region Bonus Challenge
void InsertRecordLastIntoList(List<PersonModel> people)
{
    PersonModel newPerson = new() { FirstName = "Greg", LastName = "Brown" };

    // TODO: Add a record to the end of the incoming list
    people.Add(newPerson);

}

void InsertRecordFirstIntoList(List<PersonModel> people)
{
    PersonModel newPerson = new() { FirstName = "Greg", LastName = "Brown" };

    // TODO: Add a record to the beginning of the incoming list
    people.Insert(0, newPerson);

}

void InsertRecordInTheMiddleOfTheList(List<PersonModel> people)
{
    PersonModel newPerson = new() { FirstName = "Greg", LastName = "Brown" };

    // TODO: Add a record after Paul Jones in the incoming list
    var index = people.FindIndex(0, x => x.FirstName == "Paul" && x.LastName == "Jones");
    people.Insert(index + 1, newPerson);

}

void SortAList(List<PersonModel> people)
{
    // TODO: Sort the incoming list values by fullname (ascending)
    people.Sort((x, y) => x.FullName.CompareTo(y.FullName));
}
#endregion

// Leave this method alone. It is used for specific setup.
List<PersonModel> CreateSampleList()
{
    var output = new List<PersonModel>
        {
            new PersonModel{ FirstName = "Tim", LastName = "Corey"},
            new PersonModel{ FirstName = "Sue", LastName = "Storm"},
            new PersonModel{ FirstName = "Paul", LastName = "Jones"},
            new PersonModel{ FirstName = "Jane", LastName = "Smith"},
            new PersonModel{ FirstName = "Betty", LastName = "Smith"}
        };

    return output;
}
