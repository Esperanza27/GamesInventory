using FluentAssertions;
using GamesInventory.Models;
using System.Net.NetworkInformation;

namespace GamesInventory.Test;

public class GameTests
{
    [Theory]
    [InlineData("Elden Ring", "elden-ring")]
    [InlineData(" Elden Ring ", "elden-ring")]
    [InlineData("Elden Ring 2 ", "elden-ring-2")]
    public void Test_Title_And_Slug(String title, string slug)
    {
        Game eldenRing = new Game(title);
        eldenRing.Slug.Should().Be(slug);
    }

    [Fact]
    public void IsDlc_Should_Return_False_For_Base_Game()
    {
        Game game = new Game("The Witcher 3");
        game.IsDlc.Should().BeFalse();
    }

    [Theory]
    [InlineData(" Elden Ring " , "Elden Ring", true)]
    [InlineData(" Elden Ring ", "Elden Ring 4", false)]
    [InlineData("ELDEN RING ", "elden ring", true)]
    public void Game_Equals_Should_Return_Expected_Result( string title1, string title2, bool expected )
    {
        Game game1 = new Game(title1);
        Game game2 = new Game(title2);

        game1.Equals(game2).Should().Be(expected);

    }


}
