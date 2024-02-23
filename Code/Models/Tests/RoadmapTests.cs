using FluentAssertions;
using Xunit;

namespace Models.Tests;

public class RoadmapTests
{
    // Tener una baseline por defecto del roadmap
    // añadir siguientes paradas del viaje
    // que devuelva las paradas en forma de nombres de escenas
    // y la parametrización que?

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
}
