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
    }
}
