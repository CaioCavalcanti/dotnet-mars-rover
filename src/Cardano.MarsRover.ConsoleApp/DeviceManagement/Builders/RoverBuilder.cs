using Cardano.MarsRover.ConsoleApp.DeviceManagement.Models;
using Cardano.MarsRover.ConsoleApp.Navigation.Exceptions;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;

namespace Cardano.MarsRover.ConsoleApp.DeviceManagement.Builders
{
    public class RoverBuilder
    {
        private CardinalDirection? _direction;
        private Point _position;

        public RoverBuilder LandingOn(Point position)
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
            if (_position == null) throw new InvalidPointException(string.Empty);
            if (!_direction.HasValue) throw new InvalidCardinalDirectionException(string.Empty);

            return new Rover(new Compass(), new NavigationSystem(), _position, _direction.Value);
        }
    }
}
