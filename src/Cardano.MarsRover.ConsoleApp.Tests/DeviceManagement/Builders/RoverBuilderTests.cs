using Cardano.MarsRover.ConsoleApp.DeviceManagement.Builders;
using Cardano.MarsRover.ConsoleApp.DeviceManagement.Models;
using Cardano.MarsRover.ConsoleApp.Navigation.Exceptions;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;
using FluentAssertions;
using Xunit;

namespace Cardano.MarsRover.ConsoleApp.Tests.DeviceManagement.Builders
{
    public class RoverBuilderTests
    {
        [Fact]
        public void Given_no_position_then_throw_InvalidPointException()
        {
            var builder = new RoverBuilder().PointingTo(CardinalDirection.North);
            var exception = Record.Exception(() => builder.Build());

            exception.Should().NotBeNull()
                .And.BeOfType<InvalidPointException>();
        }

        [Fact]
        public void Given_no_direction_then_throw_InvalidCardinalDirectionException()
        {
            var builder = new RoverBuilder().LandingOn(new Point(0, 0));
            var exception = Record.Exception(() => builder.Build());

            exception.Should().NotBeNull()
                .And.BeOfType<InvalidCardinalDirectionException>();
        }

        [Fact]
        public void Given_direction_then_rover_is_built_pointing_to_it()
        {
            var expectedDirection = CardinalDirection.West;

            Rover rover = new RoverBuilder()
                .LandingOn(new Point(0, 0))
                .PointingTo(expectedDirection)
                .Build();

            rover.PointingDirection.Should().Be(expectedDirection);
        }

        [Fact]
        public void Given_position_then_rover_is_built_using_it()
        {
            var expectedPosition = new Point(0, 0);

            Rover rover = new RoverBuilder()
                .LandingOn(expectedPosition)
                .PointingTo(CardinalDirection.North)
                .Build();

            rover.Position.Should().Be(expectedPosition);
        }
    }
}
