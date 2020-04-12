using Cardano.MarsRover.ConsoleApp.Navigation.Exceptions;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;
using FluentAssertions;
using Xunit;

namespace Cardano.MarsRover.ConsoleApp.Tests.Navigation.Models
{
    public class NavigationSystemTests
    {
        [Fact]
        public void Given_invalid_pointing_direction_then_throws_InvalidCardinalDirectionException()
        {
            var point = new Point(1, 1);
            var invalidCardinalDirection = (CardinalDirection)(-1);
            var navigationSystem = new NavigationSystem();

            var exception = Record.Exception(() => navigationSystem.GetNextPointOnDirection(point, invalidCardinalDirection));

            exception.Should().NotBeNull()
                .And.BeOfType<InvalidCardinalDirectionException>();
        }

        [Theory]
        [InlineData(1, 1, CardinalDirection.North, 1, 2)]
        [InlineData(1, 1, CardinalDirection.East, 2, 1)]
        [InlineData(1, 1, CardinalDirection.South, 1, 0)]
        [InlineData(1, 1, CardinalDirection.West, 0, 1)]
        public void Given_a_point_and_direction_then_returns_expected_neighbour_point_on_direction(
            int givenX,
            int givenY,
            CardinalDirection givenPointingDirection,
            int expectedX,
            int expectedY
        )
        {
            var givenPoint = new Point(givenX, givenY);
            var navigationSystem = new NavigationSystem();

            Point neighbourPointOnDirection = navigationSystem.GetNextPointOnDirection(givenPoint, givenPointingDirection);

            neighbourPointOnDirection.X.Should().Be(expectedX);
            neighbourPointOnDirection.Y.Should().Be(expectedY);
        }
    }
}
