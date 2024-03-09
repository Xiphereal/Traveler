using FluentAssertions;
using Xunit;

namespace Models.Tests;

public class TravellingTests
{
    [Fact]
    public void Travelling_consumes_supplies()
    {
        var sut = new Traveler();
        Item water = Item.Water();
        sut.Owns(water);
        Item food = Item.Food();
        sut.Owns(food);

        sut.Travel();

        sut.Carries(water).Should().BeFalse();
        sut.Carries(food).Should().BeFalse();
    }

    [Fact]
    public void Items_that_are_not_supplies_are_not_consumed()
    {
        var sut = new Traveler();
        Item water = Item.Water();
        sut.Owns(water);
        Item map = Item.Map();
        sut.Owns(map);

        sut.Travel();

        sut.Carries(water).Should().BeFalse();
        sut.Carries(map).Should().BeTrue();
    }
}
