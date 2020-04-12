using System;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;
using FluentAssertions;
using Xunit;

namespace Cardano.MarsRover.ConsoleApp.Tests.Navigation.Models
{
    public class CompassTests
    {
        private readonly Compass _compass = new Compass();

        [Fact]
        public void Given_invalid_cardinal_direction_then_throws_ArgumentOutOfRangeException_when_getting_direction_on_left()
        {
            CardinalDirection invalidCardinalDirection = (CardinalDirection)(-999);

            var exception = Record.Exception(() => _compass.GetCardinalDirectionOnLeftSideOf(invalidCardinalDirection));

            exception.Should().NotBeNull()
                .And.BeOfType<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Given_invalid_cardinal_direction_then_throws_ArgumentOutOfRangeException_when_getting_direction_on_right()
        {
            CardinalDirection invalidCardinalDirection = (CardinalDirection)(-999);

            var exception = Record.Exception(() => _compass.GetCardinalDirectionOnRightSideOf(invalidCardinalDirection));

            exception.Should().NotBeNull()
                .And.BeOfType<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(CardinalDirection.North, CardinalDirection.West)]
        [InlineData(CardinalDirection.East, CardinalDirection.North)]
        [InlineData(CardinalDirection.South, CardinalDirection.East)]
        [InlineData(CardinalDirection.West, CardinalDirection.South)]
        public void Given_a_valid_direction_then_returns_expected_direction_on_left(CardinalDirection direction, CardinalDirection expectedDirectionOnLeft)
        {
            CardinalDirection cardinalDirectionOnLeft = _compass.GetCardinalDirectionOnLeftSideOf(direction);

            cardinalDirectionOnLeft.Should().Be(expectedDirectionOnLeft);
        }

        [Theory]
        [InlineData(CardinalDirection.North, CardinalDirection.East)]
        [InlineData(CardinalDirection.East, CardinalDirection.South)]
        [InlineData(CardinalDirection.South, CardinalDirection.West)]
        [InlineData(CardinalDirection.West, CardinalDirection.North)]
        public void Given_a_valid_direction_then_returns_expected_direction_on_right(CardinalDirection direction, CardinalDirection expectedDirectionOnRight)
        {
            CardinalDirection cardinalDirectionOnRight = _compass.GetCardinalDirectionOnRightSideOf(direction);

            cardinalDirectionOnRight.Should().Be(expectedDirectionOnRight);
        }
    }
}
