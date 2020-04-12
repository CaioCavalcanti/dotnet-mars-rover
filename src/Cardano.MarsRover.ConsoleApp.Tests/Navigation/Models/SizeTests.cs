using System;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;
using FluentAssertions;
using Xunit;

namespace Cardano.MarsRover.ConsoleApp.Tests.Navigation.Models
{
    public class SizeTests
    {
        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(1, -1)]
        [InlineData(-1, 1)]
        public void Given_a_non_positive_width_or_area_then_throws_ArgumentOutOfRangeException(int givenWidth, int givenHeight)
        {
            var exception = Record.Exception(() => new Size(givenWidth, givenHeight));

            exception.Should().NotBeNull()
                .And.BeOfType<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Given_a_size_then_returns_width_and_height_as_string()
        {
            int givenWidth = 5;
            int givenHeight = 3;

            var size = new Size(givenWidth, givenHeight);

            size.ToString().Should().Be($"{givenWidth} {givenHeight}");

        }
    }
}
