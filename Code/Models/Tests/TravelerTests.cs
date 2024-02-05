using FluentAssertions;
using Xunit;

namespace Models.Tests
{
    public class TravelerTests
    {
        [Fact]
        public void Starts_without_money()
        {
            new Traveler().Coins.Should().Be(0);
        }

        [Fact]
        public void Can_earn_coins()
        {
            var traveler = new Traveler();

            traveler.Earn(coins: 1);

            traveler.Coins.Should().Be(1);
        }

        [Fact]
        public void Accumulates_wealth()
        {
            var traveler = new Traveler();

            traveler.Earn(coins: 1);
            traveler.Earn(coins: 2);

            traveler.Coins.Should().Be(1 + 2);
        }

        [Fact]
        public void Can_spend_coins()
        {
            var traveler = new Traveler();
            traveler.Earn(coins: 5);

            traveler.Spend(coins: 2);

            traveler.Coins.Should().Be(5 - 2);
        }
    }
}