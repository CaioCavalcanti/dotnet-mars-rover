using Cardano.MarsRover.ConsoleApp.Models;
using FluentAssertions;
using Xunit;

namespace Cardano.MarsRover.ConsoleApp.Tests.Models
{
    public class PlateauTests
    {
        [Fact]
        public void Given_a_size_then_return_its_area()
        {
            var size = new Size(5, 5);

            var plateau = new Plateau(size);
            int area = plateau.GetArea();

            area.Should().Be(size.Width * size.Height);
        }

        [Theory]
        [InlineData(-1, -2)]
        [InlineData(-1, 2)]
        [InlineData(1, -2)]
        [InlineData(6, 6)]
        [InlineData(6, 3)]
        [InlineData(4, 7)]
        public void Given_a_point_out_of_boundaries_then_return_point_not_valid(int pointX, int pointY)
        {
            var size = new Size(5, 5);
            var pointToCheck = new Point(pointX, pointY);

            var plateau = new Plateau(size);

            bool pointIsValid = plateau.IsPointWithinBoundaries(pointToCheck);

            pointIsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 5)]
        [InlineData(0, 2)]
        [InlineData(2, 0)]
        [InlineData(5, 3)]
        [InlineData(4, 5)]
        public void Given_a_point_within_boundaries_then_return_point_is_valid(int pointX, int pointY)
        {
            var size = new Size(5, 5);
            var pointToCheck = new Point(pointX, pointY);

            var plateau = new Plateau(size);

            bool pointIsValid = plateau.IsPointWithinBoundaries(pointToCheck);

            pointIsValid.Should().BeTrue();
        }
    }
}
