using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator;

public class SmallMapTests
{
    [Fact]
    public void Add_ShouldAddCreatureToPosition()
    {
        // Arrange
        var map = new TestSmallMap(10, 10);
        var creature = new TestCreature("Test", 1);
        var point = new Point(5, 5);

        // Act
        map.Add(creature, point);

        // Assert
        Assert.Contains(creature, map.At(point));
    }

    [Fact]
    public void Remove_ShouldRemoveCreatureFromPosition()
    {
        // Arrange
        var map = new TestSmallMap(10, 10);
        var creature = new TestCreature("Test", 1);
        var point = new Point(5, 5);
        map.Add(creature, point);

        // Act
        map.Remove(creature, point);

        // Assert
        Assert.DoesNotContain(creature, map.At(point));
    }

    [Fact]
    public void Move_ShouldMoveCreatureToNewPosition()
    {
        // Arrange
        var map = new TestSmallMap(10, 10);
        var creature = new TestCreature("Test", 1);
        var start = new Point(5, 5);
        var destination = new Point(6, 6);
        map.Add(creature, start);

        // Act
        map.Move(creature, start, destination);

        // Assert
        Assert.DoesNotContain(creature, map.At(start));
        Assert.Contains(creature, map.At(destination));
    }

    [Fact]
    public void At_ShouldReturnEmptyListIfNoCreatures()
    {
        // Arrange
        var map = new TestSmallMap(10, 10);
        var point = new Point(5, 5);

        // Act
        var creatures = map.At(point);

        // Assert
        Assert.Empty(creatures);
    }
}

public class TestSmallMap : SmallMap
{
    public TestSmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d) => p.Next(d);

    public override Point NextDiagonal(Point p, Direction d) => p.NextDiagonal(d);

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }
}
