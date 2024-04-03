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

    [Fact]
    public void Non_owned_but_affordable_items_are_swappable()
    {
        Item affordable = Item.Water();
        var traveler = new Traveler(startingWith: affordable.Cost);
        var sut = new Asdflasjdhf(traveler);

        sut.CanSwap(affordable, Item.Null()).Should().BeTrue();
    }

    [Fact]
    public void Non_owned_and_non_affordable_items_are_not_swappable()
    {
        var traveler = new Traveler();
        var sut = new Asdflasjdhf(traveler);

        sut.CanSwap(Item.CostlyOne(), Item.Null()).Should().BeFalse();
        sut.CanSwap(Item.Null(), Item.CostlyOne()).Should().BeFalse();
    }
}