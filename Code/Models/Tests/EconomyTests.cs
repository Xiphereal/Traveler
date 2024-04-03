using FluentAssertions;
using Xunit;

namespace Models.Tests
{
    public class EconomyTests
    {
        [Fact]
        public void Traveler_starts_without_money()
        {
            new Traveler().Coins.Should().Be(0);
        }

        [Fact]
        public void but_can_receive_a_starting_amount()
        {
            new Traveler(startingWith: 1).Coins.Should().Be(1);
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

        [Fact]
        public void Supplies_have_cost()
        {
            Item.Water().Cost.Should().BeGreaterThan(0);
            Item.Food().Cost.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Traveler_can_buy_items()
        {
            const int startingCoins = 5;
            var traveler = new Traveler(startingWith: startingCoins);

            traveler.Buy(Item.Water());

            traveler.Coins.Should().Be(startingCoins - Item.Water().Cost);
        }

        [Fact]
        public void Traveler_can_only_buy_if_has_enough_coins()
        {
            const int startingCoins = 1;
            var traveler = new Traveler(startingWith: startingCoins);

            traveler.Buy(Item.CostlyOne());

            traveler.Coins.Should().Be(startingCoins);
        }

        [Fact]
        public void Traveler_can_be_asked_if_they_can_affort_something()
        {
            new Traveler(startingWith: Item.Water().Cost)
                .CanAfford(Item.Water())
                .Should().BeTrue();

            new Traveler(startingWith: 1)
                .CanAfford(Item.CostlyOne())
                .Should().BeFalse();
        }

        [Fact]
        public void Traveler_can_carry_bought_items()
        {
            var traveler = new Traveler(startingWith: 5);
            Item item = Item.Water();

            traveler.Carries(item).Should().BeFalse();
            traveler.Buy(item);
            traveler.Carries(item).Should().BeTrue();
        }

        [Fact]
        public void Traveler_can_not_carry_duplicates()
        {
            var traveler = new Traveler(startingWith: 5);
            var item = Item.Map();

            traveler.Owns(item);
            traveler.Carries(item).Should().BeTrue();

            traveler.Owns(item);
            traveler.backpack.Should().ContainSingle();
        }

        [Fact]
        public void Items_identity_is_defined_by_id()
        {
            Item.Water()
                .Should().NotBe(Item.Water());
        }

        [Fact]
        public void Traveler_always_carries_null_items()
        {
            var sut = new Traveler();

            sut.Carries(Item.Null()).Should().BeTrue();
        }

        [Fact]
        public void Traveler_cannot_afford_null_items()
        {
            var sut = new Traveler(startingWith: 9999);

            sut.CanAfford(Item.Null()).Should().BeFalse();
        }
    }
}