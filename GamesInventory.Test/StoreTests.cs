using FluentAssertions;
using GamesInventory.Models;

namespace GamesInventory.Test
{
    public class StoreTests
    {
        [Fact]
        public void Test1()
        {
            Action action = () => new Store(" ");
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("Steam", "Steam")]
        [InlineData(" Steam ", "Steam")]
        [InlineData("\tEpic Games","Epic Games")]
        public void Story_With_NoEmpty_Names_Should_Work(string name, string expected)
        { 
            Store store = new Store(name);
            store.Name.Should().Be(expected);
        }

        [Theory]
        [InlineData("Steam", "Steam",true)]
        [InlineData(" Steam ", "Steam", true)]
        [InlineData("\tEpic Games", "Epic Games", true)]
        [InlineData(" stEam ", "Steam", true)]
        [InlineData("Epic Game", "Epic Games", false)]
        public void Store_Should_be_equals(string name1, string name2, bool expected)
        {
            Store store1 = new Store(name1);
            Store store2 = new Store(name2);
            store1.Equals(store2).Should().Be(expected);
        }

    }// class
}