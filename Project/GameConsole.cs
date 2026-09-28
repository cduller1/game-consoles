public class GameConsole
{
    public string Name { get; set; }
    public string Note { get; set; }
    public int Number { get; set; }

    public GameConsole(string name)
    {
        Name = name;
        Note = "";
        Number = 0;
    }
}
