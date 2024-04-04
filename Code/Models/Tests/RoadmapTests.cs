using FluentAssertions;
using Xunit;

namespace Models.Tests;

public class RoadmapTests
{
    // y la parametrización de que?

    [Fact]
    public void First_stop_is_the_introduction()
    {
        new Roadmap().NextStop().Should().Be("intro");
    }

    [Fact]
    public void Second_stop_is_preparation()
    {
        var sut = new Roadmap();
        sut.NextStop();
        sut.NextStop().Should().Be("preparation");
    }

    [Fact]
    public void Predefined_stops()
    {
        var sut = new Roadmap();
        sut.NextStop().Should().Be("intro");
        sut.NextStop().Should().Be("preparation");
        sut.NextStop().Should().Be("travelling");
        sut.NextStop().Should().Be("preparation");
        sut.NextStop().Should().Be("travelling");
    }

    [Fact]
    public void New_stops_can_be_defined()
    {
        var sut = new Roadmap();
        sut.AddStop("any");
        sut.LastStop().Should().Be("any");
    }

    [Fact]
    public void Last_stop_is_always_the_end()
    {
        var sut = new Roadmap();
        sut.LastStop().Should().Be("end");
    }
}
