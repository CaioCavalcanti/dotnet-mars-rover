using System.Collections.Generic;
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
        public void Given_a_movement_sequence_then_update_rover_movement_sequence()
        {
            var givenMovementSequence = new Queue<RoverMovement>();
            givenMovementSequence.Enqueue(RoverMovement.MoveForward);
            givenMovementSequence.Enqueue(RoverMovement.TurnLeft);

            CreateRover();

            _roverUnderTest.SetMovementSequence(givenMovementSequence);

            _roverUnderTest.MovementSequence.Should().BeEquivalentTo(givenMovementSequence);
        }

        private void CreateRover(Point initialPosition = null, CardinalDirection initialPointingDirection = CardinalDirection.North)
        {
            _roverUnderTest = new Rover(
                _compassMock.Object,
                _navigationSystemMock.Object,
                initialPosition ?? new Point(0, 0),
                initialPointingDirection
            );
        }
    }
}
