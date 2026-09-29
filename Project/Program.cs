var registry = new Registry();

registry.Add(new GameConsole("Xbox One"));
registry.Add(new GameConsole("PlayStation 5"));
registry.Add(new GameConsole("Nintendo Switch"));

var found = registry.Find("PlayStation 5");
if (found != null)
{
    found.Rename("PS5");
}

registry.Remove("Xbox One");

Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} on file.");
Console.WriteLine();

foreach (var item in registry.All())
{
    Console.WriteLine(item.Name);
}
