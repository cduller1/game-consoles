using System;
using Microsoft.EntityFrameworkCore;
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
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var registry = new Registry();
        registry.Add(registry.NewItem("A"));

        registry.Save(new ProjectContext(options));

        Assert.Equal(1, new ProjectContext(options).GameConsoles.CountAsync().Result);
    }

    [Fact]
    public void Check3_TheRegistrySurvivesARestart()
    {
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var registry = new Registry();
        registry.Add(registry.NewItem("A"));

        registry.Save(new ProjectContext(options));

        var reopened = new Registry();
        reopened.Load(new ProjectContext(options));

        Assert.Equal(1, reopened.Count);
        Assert.Equal("A", reopened.All()[0].Name);
    }

    [Fact]
    public void Check4_ARecordKeepsItsOwnFacts()
    {
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var registry = new Registry();
        var item = registry.NewItem("A");

        registry.Add(item);

        item.Visit();

        registry.Save(new ProjectContext(options));

        var reopened = new Registry();
        reopened.Load(new ProjectContext(options));

        Assert.Equal(1, reopened.Count);
        Assert.Equal(1, reopened.All()[0].TimesVisited);
    }

    [Fact]
    public void Week8_TheRegistrySurvivesARestart()
    {
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var registry = new Registry();
        var item = registry.NewItem("Console");

        registry.Add(item);

        item.Visit();

        registry.Save(new ProjectContext(options));

        var reopened = new Registry();
        reopened.Load(new ProjectContext(options));

        Assert.Equal(1, reopened.Count);
        Assert.Equal(1, reopened.All()[0].TimesVisited);
    }

    [Fact]
    public void Week9_FindComesBackEmptyHanded()
    {
        var registry = new Registry();
        var item = registry.NewItem("TestConsole");

        registry.Add(item);

        Assert.Same(item, registry.Find("TestConsole"));
        Assert.Null(registry.Find("NoSuchName"));
    }
}