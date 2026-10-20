namespace Project.Tests;

public class RegistryTests
{
    [Fact]
    public void Check2_AddingGrowsTheCount()
    {
        var registry = new Registry();

        registry.Add(registry.NewItem("A"));
        registry.Add(registry.NewItem("B"));

        Assert.Equal(2, registry.Count);
    }

    [Fact]
    public void Check3_FindHandsBackTheRecordItHolds()
    {
        var registry = new Registry();

        var depot = registry.NewItem("Depot");
        registry.Add(depot);

        var found = registry.Find("Depot");

        Assert.Same(depot, found);
    }

    [Fact]
    public void Check4_RemovingAStrangerSaysNo()
    {
        var registry = new Registry();
        registry.Add(registry.NewItem("Known"));

        bool result = registry.Remove("Stranger");

        Assert.False(result);
        Assert.Equal(1, registry.Count);
    }

    [Fact]
    public void Check5_TheSameNameCannotRegisterTwice()
    {
        var registry = new Registry();

        registry.Add(registry.NewItem("Repeat"));
        registry.Add(registry.NewItem("Repeat"));

        Assert.Equal(1, registry.Count);
    }
}
