using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.Models;

namespace Cardano.MarsRover.ConsoleApp.CommandHandling
{
    public interface ICommandHandler
    {
        Regex CommandRegexPattern { get; }
        bool MatchesCommandPattern(string command);
        Task HandleCommandAsync(IMission mission, string command);
    }
}
