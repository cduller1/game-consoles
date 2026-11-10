var registry = new Registry();

ProjectContext db = new ProjectContext();

registry.Add(registry.NewItem("Xbox One"));
registry.Add(registry.NewItem("PlayStation 5"));
registry.Add(registry.NewItem("Nintendo Switch"));

registry.Load(db);

Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} on file.");
Console.WriteLine();

GameConsole? known = registry.Find("PlayStation 5");
if (known == null)
{
    Console.WriteLine("Nothing on file by that name.");
}
else
{
    known.Visit();
    Console.WriteLine($"{known.Name} - visited {known.TimesVisited}x");
}

GameConsole? missing = registry.Find("something I never added");
Console.WriteLine(missing == null
    ? "Nothing on file by that name."
    : "...found something that shouldn't be there.");

Console.WriteLine();
Console.Write("Take one off the books (Enter to skip): ");
string? name = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine(registry.Remove(name)
        ? "Removed."
        : "Nothing by that name.");
}

Console.WriteLine();

foreach (GameConsole item in registry.All())
{
    Console.WriteLine(item.Name);
}

Console.WriteLine($"{registry.Count} on file.");

registry.Save(db);

Console.WriteLine($"{registry.Count} on file, saved to the database.");

Console.WriteLine();
Console.Write("Search (a word, or Enter to skip): ");

string? term = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(term))
{
    var found = registry.Matching(term.Trim());

    Console.WriteLine(found.Count == 0
        ? $"  Nothing on file with \"{term.Trim()}\" in it."
        : $"  {found.Count} on file with \"{term.Trim()}\" in it.");
}

Console.WriteLine();
Console.WriteLine($"On the books, as they arrived: {string.Join(", ", registry.Names())}");

Console.WriteLine();
Console.WriteLine("In order:");

foreach (var record in registry.Sorted())
{
    Console.WriteLine($"  {record.Name}");
}