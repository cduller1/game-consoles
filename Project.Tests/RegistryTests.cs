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
        // set the scene: a fresh registry
        var registry = new Registry();

        // keep a reference to the actual record
        var depot = registry.NewItem("Depot");

        // add it
        registry.Add(depot);

        // do the thing: find it
        var found = registry.Find("Depot");

        // check: SAME object, not a lookalike
        Assert.Same(depot, found);
    }
}
