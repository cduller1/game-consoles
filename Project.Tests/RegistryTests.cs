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
        // set the scene: a registry with one record
        var registry = new Registry();
        registry.Add(registry.NewItem("Known"));

        // do the thing: remove a name that is NOT on file
        bool result = registry.Remove("Stranger");

        // check: Remove says false
        Assert.False(result);

        // check: Count stays the same
        Assert.Equal(1, registry.Count);
    }
}
