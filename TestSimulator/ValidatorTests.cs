using Xunit;
using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Fact]
    public void Limiter_ShouldClampValueCorrectly()
    {
        Assert.Equal(10, Validator.Limiter(15, 0, 10));
        Assert.Equal(0, Validator.Limiter(-5, 0, 10));
        Assert.Equal(5, Validator.Limiter(5, 0, 10));
    }

    [Fact]
    public void Shortener_ShouldAdjustLengthCorrectly()
    {
        Assert.Equal("Abc", Validator.Shortener("abc", 3, 5, '#'));
        Assert.Equal("Abc##", Validator.Shortener("abc", 5, 5, '#'));
        Assert.Equal("Abcde", Validator.Shortener("abcdefgh", 3, 5, '#'));
    }
}
