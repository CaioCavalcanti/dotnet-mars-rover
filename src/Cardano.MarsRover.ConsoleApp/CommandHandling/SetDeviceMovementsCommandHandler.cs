using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.Models;

namespace Cardano.MarsRover.ConsoleApp.CommandHandling
{
    public class SetDeviceMovementsCommandHandler : CommandHandler, ICommandHandler
    {
        public override Regex CommandRegexPattern => new Regex(@"^[LRM]+$");

        public override async Task HandleCommandAsync(IMission mission, string command)
        {
            IList<RoverMovement> movementSequence = GetMovementSequence(command);
            IList<object> genericMovementSequence = movementSequence.Cast<object>().ToList();

            mission.SendCommandsToCurrentDeviceInControl(genericMovementSequence);
            await mission.DispatchCurrentDeviceInControlAsync();
        }

        private IList<RoverMovement> GetMovementSequence(string command)
        {
            char[] commandSplit = command.ToCharArray();
            return commandSplit.Select(arg => _movements[arg]).ToList();
        }

        private static IReadOnlyDictionary<char, RoverMovement> _movements = new Dictionary<char, RoverMovement>
        {
            { 'L', RoverMovement.TurnLeft },
            { 'R', RoverMovement.TurnRight },
            { 'M', RoverMovement.MoveForward },
        };
    }
}
