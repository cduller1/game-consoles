using System;
using System.IO;
using Xunit;

public class RegistryTests
{
    [Fact]
    public void Check1_WeeksFourToSevenStillHold()
    {
        var registry = new Registry();
        registry.Add(registry.NewItem("A"));
        registry.Add(registry.NewItem("B"));
        Assert.Equal(2, registry.Count);
    }

    [Fact]
    public void Check2_TheRegistryWritesItselfDown()
    {
        var path = Path.Combine(Path.GetTempPath(), "week8_test_save.json");
        File.Delete(path);

        var registry = new Registry();
        registry.Add(registry.NewItem("A"));
        registry.Save(path);

        Assert.True(File.Exists(path));
    }

    [Fact]
    public void Check3_TheRegistrySurvivesARestart()
    {
        var path = Path.Combine(Path.GetTempPath(), "week8_test_load.json");
        File.Delete(path);

        var registry = new Registry();
        registry.Add(registry.NewItem("A"));
        registry.Save(path);

        var reopened = new Registry();
        reopened.Load(path);

        Assert.Equal(1, reopened.Count);
        Assert.Equal("A", reopened.All()[0].Name);
    }

    [Fact]
    public void Check4_ARecordKeepsItsOwnFacts()
    {
        var path = Path.Combine(Path.GetTempPath(), "week8_test_private.json");
        File.Delete(path);

        var registry = new Registry();
        var item = registry.NewItem("A");
        registry.Add(item);
        item.Visit(); // TimesVisited = 1
        registry.Save(path);

        var reopened = new Registry();
        reopened.Load(path);

        Assert.Equal(1, reopened.Count);
        Assert.Equal(1, reopened.All()[0].TimesVisited);
    }

    [Fact]
    public void Week8_TheRegistrySurvivesARestart()
    {
        var path = Path.Combine(Path.GetTempPath(), "something-yours.json");
        File.Delete(path);

        var registry = new Registry();
        var item = registry.NewItem("Console");
        registry.Add(item);

        item.Visit(); // TimesVisited = 1

        registry.Save(path);

        var reopened = new Registry();
        reopened.Load(path);

        Assert.Equal(1, reopened.Count);
        Assert.Equal(1, reopened.All()[0].TimesVisited);
    }
}
