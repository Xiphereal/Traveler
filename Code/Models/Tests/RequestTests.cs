using FluentAssertions;
using Xunit;

namespace Models.Tests
{
    public class RequestTests
    {
        [Fact]
        public void Villagers_give_deliveries_to_traveler()
        {
            var traveler = new Traveler();

            Villager.GiveDelivery(to: traveler);

            traveler.Carries(Item.Delivery()).Should().BeTrue();
        }

        [Fact]
        public void Villagers_accept_deliveries_from_traveler()
        {
            var traveler = new Traveler();
            Villager.GiveDelivery(to: traveler);

            Villager.AcceptDelivery(from: traveler);

            traveler.Carries(Item.Delivery()).Should().BeFalse();
        }
    }
}