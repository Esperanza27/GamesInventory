using FluentAssertions;
using GamesInventory.Models;

namespace GamesInventory.Test;

public class PlatformTest
{
    [Fact]
    public void Test1()
    {
        Action action = () => new Platform(" ");
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("Pc", "Pc")]
    [InlineData(" Pc ", "Pc")]
    [InlineData("\tPc", "Pc")]
    public void Platform_With_NoEmpty_Names_Should_Work(string name, string expected)
    {
        Platform platform = new Platform(name);
        platform.Name.Should().Be(expected);
    }

    [Theory]
    [InlineData("Pc", "Pc", true)]
    [InlineData(" Pc ", "Pc", true)]
    [InlineData("\tPc ", "Pc", true)]
    [InlineData(" PC ", "pc", true)]
    [InlineData("Pcs.", "Pc", false)]
    public void Platform_Should_be_equals(string name1, string name2, bool expected)
    {
        Platform platform1 = new Platform(name1);
        Platform platform2 = new Platform(name2);
        platform1.Equals(platform2).Should().Be(expected);
    }

}
