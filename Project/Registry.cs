public class Registry
{
    private readonly List<GameConsole> _items = new List<GameConsole>();

    public static string Topic => "This project is about managing a collection of game consoles.";

    public GameConsole NewItem(string name) => new GameConsole(name);

    public void Add(GameConsole item)
    {
        _items.Add(item);
    }

    public int Count => _items.Count;

    public List<GameConsole> All()
    {
        return _items;
    }
}
