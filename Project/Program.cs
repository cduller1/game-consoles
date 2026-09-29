var registry = new Registry();

registry.Add(new GameConsole("Xbox One"));
registry.Add(new GameConsole("PlayStation 5"));
registry.Add(new GameConsole("Nintendo Switch"));

Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} on file.");
Console.WriteLine();

foreach (GameConsole item in registry.All())
{
    Console.WriteLine(item.Name);
}
