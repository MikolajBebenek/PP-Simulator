using Xunit;
using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinatesCorrectly()
    {
        var rect = new Rectangle(1, 1, 4, 4);
        Assert.Equal("(1, 1):(4, 4)", rect.ToString());
    }

    [Fact]
    public void Contains_ShouldReturnTrueForPointInside()
    {
        var rect = new Rectangle(1, 1, 4, 4);
        var point = new Point(2, 2);
        Assert.True(rect.Contains(point));
    }

    [Fact]
    public void Contains_ShouldReturnFalseForPointOutside()
    {
        var rect = new Rectangle(1, 1, 4, 4);
        var point = new Point(5, 5);
        Assert.False(rect.Contains(point));
    }
}
