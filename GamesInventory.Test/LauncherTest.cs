using FluentAssertions;
using GamesInventory.Models;

namespace GamesInventory.Test;

public class LauncherTest
{
    [Fact]
    public void Test1()
    {
        Action action = () => new Launcher(" ");
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("Steam", "Steam")]
    [InlineData(" Steam ", "Steam")]
    [InlineData("\tEpic Games", "Epic Games")]
    public void Launcher_With_NoEmpty_Names_Should_Work(string name, string expected)
    {
        Launcher launcher = new Launcher(name);
        launcher.Name.Should().Be(expected);
    }
   
    [Theory]
    [InlineData("Steam", "Steam", true)]
    [InlineData(" Steam ", "Steam", true)]
    [InlineData("\tEpic Games", "Epic Games", true)]
    [InlineData(" stEam ", "Steam", true)]
    [InlineData("Epic Game", "Epic Games", false)]
    public void launcher_Should_be_equals(string name1, string name2, bool expected)
    {
        Launcher launcher1 = new Launcher(name1);
        Launcher launcher2 = new Launcher(name2);
        launcher1.Equals(launcher2).Should().Be(expected);
    }
}
