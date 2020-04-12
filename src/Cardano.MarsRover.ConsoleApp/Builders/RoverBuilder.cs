using Cardano.MarsRover.ConsoleApp.Models;

namespace Cardano.MarsRover.ConsoleApp.Builders
{
    public class RoverBuilder
    {
        private CardinalDirection _direction;
        private Point _position;

        public RoverBuilder OnPosition(Point position)
        {
            _position = position;
            return this;
        }

        public RoverBuilder PointingTo(CardinalDirection direction)
        {
            _direction = direction;
            return this;
        }

        public Rover Build()
        {
            return new Rover(new Compass(), new NavigationSystem(), _position, _direction);
        }
    }
}
