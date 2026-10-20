using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

public class Registry : IListed
{
    private readonly List<GameConsole> _items = new List<GameConsole>();

    public static string Topic => "This project is about managing a collection of game consoles.";

    public GameConsole NewItem(string name) => new GameConsole(name);

    public void Add(GameConsole item)
    {
        if (Find(item.Name) != null)
            return;

        _items.Add(item);
    }

    public int Count => _items.Count;

    public List<GameConsole> All()
    {
        return new List<GameConsole>(_items);
    }

    public GameConsole? Find(string name)
    {
        return _items.FirstOrDefault(i => i.Name == name);
    }

    public bool Remove(string name)
    {
        var item = Find(name);
        if (item == null)
            return false;

        _items.Remove(item);
        return true;
    }

    public string Kind => "REGISTRY";

    public string Line() =>
        $"{Topic} - {Count} on file";

    public List<IListed> Everything()
    {
        var list = new List<IListed>();
        list.Add(this);

        foreach (var item in _items)
            list.Add(item);

        return list;
    }

    public void Save(string path)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string text = JsonSerializer.Serialize(_items, options);
        File.WriteAllText(path, text);
    }
}
