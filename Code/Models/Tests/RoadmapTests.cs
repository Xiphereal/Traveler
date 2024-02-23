using FluentAssertions;
using Xunit;

namespace Models.Tests
{
    public class RoadmapTests
    {
        [Fact]
        public void First_stop_is_the_introduction()
        {
            new Roadmap().Next().Should().Be("intro");
        }
    }
}
