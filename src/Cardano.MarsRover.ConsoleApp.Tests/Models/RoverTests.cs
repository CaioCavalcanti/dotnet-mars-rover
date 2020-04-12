using System;
using Cardano.MarsRover.ConsoleApp.Exceptions;
using Cardano.MarsRover.ConsoleApp.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace Cardano.MarsRover.ConsoleApp.Tests.Models
{
    public class RoverTests
    {
        private readonly Mock<ICompass> _compassMock = new Mock<ICompass>();
        private readonly Mock<INavigationSystem> _navigationSystemMock = new Mock<INavigationSystem>();
        private Rover _roverUnderTest;

        [Fact]
        public void Given_a_rover_not_deployed_then_throws_RemoteDeviceNotDeployedException_when_TurnLeft_is_called()
        {
            CreateRover();

            var exception = Record.Exception(() => _roverUnderTest.TurnLeft());

            exception.Should().NotBeNull()
                .And.BeOfType<RemoteDeviceNotDeployedException>();
        }

        [Fact]
        public void Given_a_rover_not_deployed_then_throws_RemoteDeviceNotDeployedException_when_TurnRight_is_called()
        {
            CreateRover();

            var exception = Record.Exception(() => _roverUnderTest.TurnRight());

            exception.Should().NotBeNull()
                .And.BeOfType<RemoteDeviceNotDeployedException>();
        }

        [Fact]
        public void Given_a_rover_not_deployed_then_throws_RemoteDeviceNotDeployedException_when_MoveForward_is_called()
        {
            CreateRover();

            var exception = Record.Exception(() => _roverUnderTest.MoveForward());

            exception.Should().NotBeNull()
                .And.BeOfType<RemoteDeviceNotDeployedException>();
        }

        [Fact]
        public void Given_an_initial_pointing_direction_then_points_to_expected_direction_using_compass_when_turning_left()
        {
            var landingSurfaceMock = Mock.Of<ILandingSurface>();
            var initialPosition = new Point(1, 1);
            var initialPointingDirection = CardinalDirection.North;
            var expectedPointingDirectionAfterTurningLeft = CardinalDirection.West;

            _compassMock
                .Setup(compass => compass.GetCardinalDirectionOnLeftSideOf(It.IsAny<CardinalDirection>()))
                .Returns(expectedPointingDirectionAfterTurningLeft);

            CreateRover();
            _roverUnderTest.Deploy(landingSurfaceMock, initialPosition, initialPointingDirection);

            _roverUnderTest.TurnLeft();

            _roverUnderTest.PointingDirection.Should().Be(expectedPointingDirectionAfterTurningLeft);
        }

        [Fact]
        public void Given_an_initial_pointing_direction_then_points_to_expected_direction_using_compass_when_turning_right()
        {
            var landingSurfaceMock = Mock.Of<ILandingSurface>();
            var initialPosition = new Point(1, 1);
            var initialPointingDirection = CardinalDirection.South;
            var expectedPointingDirectionAfterTurningRight = CardinalDirection.East;

            _compassMock
                .Setup(compass => compass.GetCardinalDirectionOnRightSideOf(It.IsAny<CardinalDirection>()))
                .Returns(expectedPointingDirectionAfterTurningRight);

            CreateRover();
            _roverUnderTest.Deploy(landingSurfaceMock, initialPosition, initialPointingDirection);

            _roverUnderTest.TurnRight();

            _compassMock.Verify(compass =>
                compass.GetCardinalDirectionOnRightSideOf(
                    It.Is<CardinalDirection>(directionCalled => directionCalled == initialPointingDirection)
                ),
                Times.Once
            );
            _compassMock.VerifyNoOtherCalls();

            _roverUnderTest.PointingDirection.Should().Be(expectedPointingDirectionAfterTurningRight);
        }

        [Fact]
        public void Given_a_command_to_MoveForward_then_get_next_position_and_check_if_is_within_plateau_boundaries()
        {
            var initialPosition = new Point(0, 0);
            var initialPointingDirection = CardinalDirection.North;
            var landingSurfaceMock = new Mock<ILandingSurface>();
            var expectedNextPosition = new Point(0, 1);

            landingSurfaceMock
                .Setup(surface => surface.IsPointWithinBoundaries(It.IsAny<Point>()))
                .Returns(true);

            _navigationSystemMock
                .Setup(setup => setup.GetNextPointOnDirection(initialPosition, initialPointingDirection))
                .Returns(expectedNextPosition);

            CreateRover();
            _roverUnderTest.Deploy(landingSurfaceMock.Object, initialPosition, initialPointingDirection);

            _roverUnderTest.MoveForward();

            _navigationSystemMock.Verify(nav => nav.GetNextPointOnDirection(initialPosition, initialPointingDirection), Times.Once);
            landingSurfaceMock.Verify(surface => surface.IsPointWithinBoundaries(expectedNextPosition), Times.Once);
        }

        [Fact]
        public void Given_a_command_to_move_off_the_plateau_then_do_not_MoveForward_and_throw_InvalidOperationException()
        {
            var initialPosition = new Point(0, 0);
            var initialPointingDirection = CardinalDirection.South;
            var landingSurfaceMock = new Mock<ILandingSurface>();

            landingSurfaceMock
                .Setup(surface => surface.IsPointWithinBoundaries(It.IsAny<Point>()))
                .Returns(false);

            CreateRover();
            _roverUnderTest.Deploy(landingSurfaceMock.Object, initialPosition, initialPointingDirection);

            var exception = Record.Exception(() => _roverUnderTest.MoveForward());

            exception.Should().NotBeNull()
                .And.BeOfType<InvalidOperationException>();
            _roverUnderTest.Position.Should().Be(initialPosition);
        }

        [Fact]
        public void Given_a_command_to_move_within_the_plateau_then_move_to_next_position()
        {
            var initialPosition = new Point(0, 0);
            var initialPointingDirection = CardinalDirection.North;
            var landingSurfaceMock = new Mock<ILandingSurface>();
            var expectedNextPosition = new Point(0, 1);

            landingSurfaceMock
                .Setup(surface => surface.IsPointWithinBoundaries(It.IsAny<Point>()))
                .Returns(true);

            _navigationSystemMock
                .Setup(setup => setup.GetNextPointOnDirection(initialPosition, initialPointingDirection))
                .Returns(expectedNextPosition);

            CreateRover();
            _roverUnderTest.Deploy(landingSurfaceMock.Object, initialPosition, initialPointingDirection);

            _roverUnderTest.MoveForward();

            _roverUnderTest.Position.Should().Be(expectedNextPosition);
        }

        private void CreateRover()
        {
            _roverUnderTest = new Rover(1, _compassMock.Object, _navigationSystemMock.Object);
        }
    }
}
