using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.Builders;
using Cardano.MarsRover.ConsoleApp.Models;

namespace Cardano.MarsRover.ConsoleApp.CommandHandling
{
    public class SetDevicePositionCommandHandler : CommandHandler, ICommandHandler
    {
        public override Regex CommandRegexPattern => new Regex(@"^\d+ \d+ [NSEW]$");

        public override async Task HandleCommandAsync(IMission mission, string command)
        {
            string[] roverInputCommandArgs = command.Split(' ');
            Point position = GetPosition(roverInputCommandArgs);
            CardinalDirection direction = GetPointingDirection(roverInputCommandArgs);

            Rover rover = new RoverBuilder()
                .OnPosition(position)
                .PointingTo(direction)
                .Build();

            mission.DeployDevice(rover);

            await Task.CompletedTask.ConfigureAwait(false);
        }

        private Point GetPosition(string[] roverInputCommandArgs)
        {
            var x = int.Parse(roverInputCommandArgs[0]);
            var y = int.Parse(roverInputCommandArgs[1]);
            return new Point(x, y);
        }

        private CardinalDirection GetPointingDirection(string[] roverInputCommandArgs)
        {
            char inputDirection = roverInputCommandArgs[2][0];
            return _cardinalDirections[inputDirection];
        }

        private static IDictionary<char, CardinalDirection> _cardinalDirections = new Dictionary<char, CardinalDirection>
        {
            { 'N', CardinalDirection.North },
            { 'E', CardinalDirection.East },
            { 'S', CardinalDirection.South },
            { 'W', CardinalDirection.West },
        };
    }
}
