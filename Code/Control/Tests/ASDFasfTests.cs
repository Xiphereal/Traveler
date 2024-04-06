using FluentAssertions;
using Models;
using Xunit;

namespace Control.Tests;

public class ASDFasfTests
{
    [Fact]
    public void Has_nothing_to_deliver()
    {
        var traveler = new Traveler();
        var sut = new Asdflasjdhf(traveler);

        sut.DoYouHaveSomethingToDeliver()
            .Should().Be("... but you find nothing.");
    }

    [Fact]
    public void Has_a_delivery_for_the_villager()
    {
        var traveler = new Traveler();
        traveler.Owns(Item.Delivery());
        var sut = new Asdflasjdhf(traveler);

        sut.DoYouHaveSomethingToDeliver()
            .Should().Be(
                "... and you hand the villager the delivery.");
    }
}