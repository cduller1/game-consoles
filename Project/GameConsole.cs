using System;

public class GameConsole
{
    public string Name { get; private set; }
    public string Note { get; set; }

    private int _number = 0;
    public int Number
    {
        get => _number;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            _number = value;
        }
    }

    public GameConsole(string name)
    {
        Name = name;
        Note = "";
        Number = 0;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(nameof(newName));
        Name = newName;
    }
}
