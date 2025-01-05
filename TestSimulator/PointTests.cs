using Simulator;
using Xunit;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinatesCorrectly()
    {
        var point = new Point(5, 10);
        Assert.Equal(5, point.X);
        Assert.Equal(10, point.Y);
    }

    [Fact]
    public void Next_ShouldMovePointCorrectly()
    {
        var point = new Point(5, 5);
        var nextPoint = point.Next(Direction.Right);
        Assert.Equal(new Point(6, 5), nextPoint);
    }

    [Fact]
    public void NextDiagonal_ShouldMovePointDiagonally()
    {
        var point = new Point(5, 5);
        var nextPoint = point.NextDiagonal(Direction.Right);
        Assert.Equal(new Point(6, 4), nextPoint);
    }
}
