using System;

public class GameConsole : IListed
{
    public string Name { get; private set; }
    public int TimesVisited { get; private set; }

    public GameConsole(string name)
    {
        Name = name;
        TimesVisited = 0;
    }

    public void Visit()
    {
        TimesVisited++;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(nameof(newName));
        Name = newName;
    }

    // Week 6 additions
    public string Kind => "GAMECONSOLE";

    public string Line() =>
        $"{Name} - visited {TimesVisited}x";
}
