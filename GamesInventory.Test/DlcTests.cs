using FluentAssertions;
using GamesInventory.Models;

namespace GamesInventory.Test;

public class DlcTests
{
    [Fact]
    public void IsDlc_For_Game_should_be_false()
    {
        Game eldenRing = new Game("Elden Ring");
        eldenRing.IsDlc.Should().BeFalse();
    }

    [Fact]
    public void IsDlc_Dlc_Game_For_Game_should_be_True()
    {
        Game eldenRing = new Game("Elden Ring");
        Dlc shadowOfTheErdtree = new Dlc("Shadow Of The Erdtree", eldenRing);
        shadowOfTheErdtree.IsDlc.Should().BeTrue();
    }

    [Fact]
    public void Dlc_Game_Is_Nul_Should_Be_Throw()
    {
        Action action = () => new Dlc("Elden Ring", null);
        action.Should().Throw<ArgumentException>();
    }
    [Fact]
    public void Dlc_Is_Game_Is_Dlc_Should_Be_Throw()
    {
        Game eldenRing = new Game("Elden Ring");
        Dlc shadowOfTheErdtree = new Dlc("Shadow Of The Erdtree", eldenRing);
        Action action = () => new Dlc("Elden Ring", shadowOfTheErdtree);
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Equals_Should_Be_True_For_Dlc_With_Same_Title_And_MainGame()
    {
        Game eldenRing = new Game("Elden Ring");
        Dlc dlc1 = new Dlc("Hearts of Stone", eldenRing);
        Game dlc2 = new Dlc("Hearts of Stone", eldenRing);

        dlc1.Equals(dlc2).Should().BeTrue();
    }

    [Fact]
    public void Equals_Should_Be_False_For_Dlc_With_Same_Title_And_MainGame()
    {
        Game eldenRing = new Game("Elden Ring");
        Game shadowOfTheErdtree = new Game("Shadow Of The Erdtree");

        Dlc dlc1 = new Dlc("Hearts of Stone", eldenRing);
        Game dlc2 = new Dlc("Hearts of Stone", shadowOfTheErdtree);

        dlc1.Equals(dlc2).Should().BeFalse();
    }

    [Fact]
    public void Equals_Should_Be_False_For_Dlc_With_Same_Diferent_Title()
    {
        Game shadowOfTheErdtree = new Game("Shadow Of The Erdtree");

        Dlc dlc1 = new Dlc("Hearts of Stone", shadowOfTheErdtree);
        Game dlc2 = new Dlc("Hearts Stone", shadowOfTheErdtree);

        dlc1.Equals(dlc2).Should().BeFalse();
    }

    [Fact]
    public void Should_Be_Same_Hash_For_Dlc_Witch_Same_Title_And_Main_Game()
    {
        Game mainGame = new Game("Shadow Of The Erdtree");
        Game dlc1 = new Dlc("Elden Ring", mainGame);
        Game dlc2 = new Dlc("Elden Ring", mainGame);

        dlc1.GetHashCode().Equals(dlc2.GetHashCode()).Should().BeTrue();
    }



}
