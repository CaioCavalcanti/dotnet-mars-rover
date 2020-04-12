using Cardano.MarsRover.ConsoleApp.Models;
using FluentAssertions;
using Xunit;

namespace Cardano.MarsRover.ConsoleApp.Tests.Models
{
    public class PointTests
    {
        [Fact]
        public void Given_a_point_then_returns_x_and_y_when_converted_to_string()
        {
            int givenX = 1;
            int givenY = 2;
            var point = new Point(givenX, givenY);

            point.ToString().Should().Be($"({givenX}, {givenY})");
        }
    }
}
