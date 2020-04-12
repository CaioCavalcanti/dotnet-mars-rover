using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.DeviceManagement.Exceptions;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;

namespace Cardano.MarsRover.ConsoleApp.DeviceManagement.Models
{
    public class Rover : IRover
    {
        private readonly IReadOnlyDictionary<RoverMovement, Action> _roverMovementActionMappings;
        private readonly ICompass _compass;
        private readonly INavigationSystem _navigationSystem;
        private bool _isDeployed = false;

        public int Id { get; private set; }
        public ILandingSurface LandingSurface { get; private set; }
        public Point Position { get; private set; }
        public CardinalDirection PointingDirection { get; private set; }
        public Queue<RoverMovement> MovementSequence { get; private set; }

        public Rover(
            ICompass compass,
            INavigationSystem navigationSystem,
            Point initialPosition,
            CardinalDirection initialPointingDirection)
        {
            _compass = compass ?? throw new ArgumentNullException(nameof(compass));
            _navigationSystem = navigationSystem ?? throw new ArgumentNullException(nameof(navigationSystem));

            Position = initialPosition;
            PointingDirection = initialPointingDirection;

            _roverMovementActionMappings = new Dictionary<RoverMovement, Action>()
            {
                { RoverMovement.TurnLeft, TurnLeft },
                { RoverMovement.TurnRight, TurnRight },
                { RoverMovement.MoveForward, MoveForward }
            };
        }

        public void DeployTo(ILandingSurface landingSurface)
        {
            LandingSurface = landingSurface;
            _isDeployed = true;
        }

        public void SetMovementSequence(Queue<RoverMovement> movementSequence) => MovementSequence = movementSequence;

        public void SetDeviceIdentifier(int id) => Id = id;

        public async Task StartMovementSequenceAsync()
        {
            if (!_isDeployed) throw new RemoteDeviceNotDeployedException(nameof(Rover));
            await ExecuteMovementSequenceAsync();
        }

        private async Task ExecuteMovementSequenceAsync()
        {
            try
            {
                while (MovementSequence.Count > 0)
                {
                    RoverMovement nextMovement = MovementSequence.Dequeue();
                    await ExecuteMovementAsync(nextMovement).ConfigureAwait(false);
                }
                // TODO: report success
            }
            catch (InvalidOperationException)
            {
                // TODO: use domain exception
                // TODO: report error
            }
        }

        private async Task ExecuteMovementAsync(RoverMovement movement)
        {
            Action movementAction = _roverMovementActionMappings[movement];
            await Task.Run(movementAction).ConfigureAwait(false);
        }

        private void TurnLeft()
        {
            PointingDirection = _compass.GetCardinalDirectionOnLeftSideOf(PointingDirection);
        }

        private void TurnRight()
        {
            PointingDirection = _compass.GetCardinalDirectionOnRightSideOf(PointingDirection);
        }

        private void MoveForward()
        {
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

        public override string ToString() => $"{Position.X} {Position.Y} {PointingDirection.ToString()[0]} ({MovementSequence.Count})";
    }
}
