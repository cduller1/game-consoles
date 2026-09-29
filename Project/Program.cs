var registry = new Registry();

registry.Add(registry.NewItem("Xbox One"));
registry.Add(registry.NewItem("PlayStation 5"));
registry.Add(registry.NewItem("Nintendo Switch"));

Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} on file.");
Console.WriteLine();

// One I know something about.
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

// And one nobody has ever heard of.
GameConsole? missing = registry.Find("something I never added");
Console.WriteLine(missing == null
    ? "Nothing on file by that name."
    : "...found something that shouldn't be there.");

Console.WriteLine();
Console.Write("Take one off the books (Enter to skip): ");
string? name = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine(registry.Remove(name) ? "Removed." : "Nothing by that name.");
}

Console.WriteLine();
foreach (GameConsole item in registry.All())
{
    Console.WriteLine(item.Name);
}
Console.WriteLine($"{registry.Count} on file.");
