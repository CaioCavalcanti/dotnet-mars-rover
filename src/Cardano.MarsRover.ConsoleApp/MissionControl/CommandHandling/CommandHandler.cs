using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.MissionControl.Models;

namespace Cardano.MarsRover.ConsoleApp.MissionControl.CommandHandling
{
    public abstract class CommandHandler : ICommandHandler
    {
        public abstract Regex CommandRegexPattern { get; }

        public abstract Task HandleCommandAsync(IMission mission, string command);

        public bool MatchesCommandPattern(string command)
        {
            return CommandRegexPattern.IsMatch(command);
        }
    }
}
