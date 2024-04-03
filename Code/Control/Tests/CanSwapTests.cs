using FluentAssertions;
using Models;
using Xunit;

namespace Control.Tests;

public class CanSwapTests
{
    [Fact]
    public void Owned_items_are_swappable()
    {
        var traveler = new Traveler();
        var anOwnedItem = Item.Water();
        traveler.Owns(anOwnedItem);
        var anotherOwnedItem = Item.Water();
        traveler.Owns(anotherOwnedItem);
        var sut = new Asdflasjdhf(traveler);

        sut.CanSwap(anOwnedItem, anotherOwnedItem).Should().BeTrue();
    }

    [Fact]
    public void Null_items_are_swappable()
    {
        var traveler = new Traveler();
        var anOwnedItem = Item.Water();
        traveler.Owns(anOwnedItem);
        var sut = new Asdflasjdhf(traveler);

        sut.CanSwap(anOwnedItem, Item.Null()).Should().BeTrue();
    }
}