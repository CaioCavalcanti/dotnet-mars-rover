using System;
using System.Collections.Generic;
using Cardano.MarsRover.ConsoleApp.Exceptions;

namespace Cardano.MarsRover.ConsoleApp.Models
{
    public class Rover : IRover
    {
        private readonly Queue<RoverMovement> _movementSequence = new Queue<RoverMovement>();
        private readonly IReadOnlyDictionary<RoverMovement, Action> _roverMovementActionMappings;
        private readonly ICompass _compass;
        private readonly INavigationSystem _navigationSystem;
        private bool _isDeployed = false;

        public int Id { get; private set; }
        public ILandingSurface LandingSurface { get; private set; }
        public Point Position { get; private set; }
        public CardinalDirection PointingDirection { get; private set; }

        public Rover(int id, ICompass compass, INavigationSystem navigationSystem)
        {
            _compass = compass ?? throw new ArgumentNullException(nameof(compass));
            _navigationSystem = navigationSystem ?? throw new ArgumentNullException(nameof(navigationSystem));

            Id = id;

            _roverMovementActionMappings = new Dictionary<RoverMovement, Action>()
            {
                { RoverMovement.TurnLeft, TurnLeft },
                { RoverMovement.TurnRight, TurnRight },
                { RoverMovement.MoveForward, MoveForward }
            };
        }

        public void Deploy(ILandingSurface landingSurface, Point position, CardinalDirection pointingDirection)
        {
            LandingSurface = landingSurface;
            Position = position;
            PointingDirection = pointingDirection;
            _isDeployed = true;
        }

        public void TurnLeft()
        {
            if (!_isDeployed) throw new RemoteDeviceNotDeployedException(nameof(Rover));
            PointingDirection = _compass.GetCardinalDirectionOnLeftSideOf(PointingDirection);
        }

        public void TurnRight()
        {
            if (!_isDeployed) throw new RemoteDeviceNotDeployedException(nameof(Rover));
            PointingDirection = _compass.GetCardinalDirectionOnRightSideOf(PointingDirection);
        }

        public void MoveForward()
        {
            if (!_isDeployed) throw new RemoteDeviceNotDeployedException(nameof(Rover));
            Point nextPoint = _navigationSystem.GetNextPointOnDirection(Position, PointingDirection);
            bool nextPointIsValid = LandingSurface.IsPointWithinBoundaries(nextPoint);

            if (nextPointIsValid)
            {
                // TODO: is next point available?
                // TODO: report RoverMovedEvent
                Position = nextPoint;
            }
            else
            {
                // TODO: RoverStopped event
                throw new InvalidOperationException($"Cannot move forward, next position {nextPoint} is out of range");
            }
        }
    }
}
