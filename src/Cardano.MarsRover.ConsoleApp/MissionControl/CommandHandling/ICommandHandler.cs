using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.MissionControl.Models;

namespace Cardano.MarsRover.ConsoleApp.MissionControl.CommandHandling
{
    public interface ICommandHandler
    {
        Regex CommandRegexPattern { get; }
        bool MatchesCommandPattern(string command);
        Task HandleCommandAsync(IMission mission, string command);
    }
}
