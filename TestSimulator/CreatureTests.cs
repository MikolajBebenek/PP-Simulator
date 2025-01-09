using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator;

public class CreatureTests
{
    [Fact]
    public void AssignToMap_ShouldAssignCreatureToMapAndSetPosition()
    {
        // Arrange
        var map = new TestSmallMap(10, 10);
        var creature = new TestCreature("Test", 1);
        var point = new Point(5, 5);

        // Act
        creature.AssignToMap(map, point);

        // Assert
        Assert.Equal(map, creature.CurrentMap);
        Assert.Equal(point, creature.CurrentPosition);
    }

    [Fact]
    public void Move_ShouldMoveCreatureToNewPosition()
    {
        // Arrange
        var map = new TestSmallMap(10, 10);
        var creature = new TestCreature("Test", 1);
        var start = new Point(5, 5);
        creature.AssignToMap(map, start);

        // Act
        creature.Move(Direction.Up);

        // Assert
        Assert.Equal(new Point(5, 4), creature.CurrentPosition);
    }

    [Fact]
    public void Move_ShouldNotMoveCreatureIfNoMapAssigned()
    {
        // Arrange
        var creature = new TestCreature("Test", 1);

        // Act
        creature.Move(Direction.Up);

        // Assert
        Assert.Null(creature.CurrentMap);
    }
}

// Test implementation of Creature
public class TestCreature : Creature
{
    public TestCreature(string name, int level) : base(name, level) { }

    public override string Info => "Test creature";
    public override string Greeting() => "Hello!";
    public override int Power => Level * 10;
}
