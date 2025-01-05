using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;

        // Act
        var map = new SmallSquareMap(size);

        // Assert
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(5, 5, 10, true)]
    [InlineData(9, 9, 10, true)]
    [InlineData(10, 10, 10, false)]
    [InlineData(-1, -1, 10, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);

        // Act
        var result = map.Exist(point);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 4)]
    [InlineData(5, 5, Direction.Down, 5, 6)]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    public void Next_ShouldReturnCorrectPointWithinBounds(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.Next(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 0)]
    [InlineData(9, 9, Direction.Down, 9, 9)]
    [InlineData(0, 9, Direction.Left, 0, 9)]
    [InlineData(9, 0, Direction.Right, 9, 0)]
    public void Next_ShouldNotMoveOutsideBounds(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.Next(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 4)]
    [InlineData(5, 5, Direction.Down, 6, 6)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    public void NextDiagonal_ShouldReturnCorrectPointWithinBounds(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.NextDiagonal(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
