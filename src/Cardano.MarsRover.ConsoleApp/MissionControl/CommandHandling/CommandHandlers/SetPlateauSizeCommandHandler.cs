using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.MissionControl.Models;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;

namespace Cardano.MarsRover.ConsoleApp.MissionControl.CommandHandling.CommandHandlers
{
    public class SetPlateauSizeCommandHandler : CommandHandler, ICommandHandler
    {
        public override Regex CommandRegexPattern => new Regex(@"^\d+ \d+$");

        public override async Task HandleCommandAsync(IMission mission, string command)
        {
            Size plateauSize = GetSize(command);
            Plateau plateau = new Plateau();
            plateau.SetSize(plateauSize);
            mission.SetLandingSurface(plateau);

            await Task.CompletedTask;
        }

        private Size GetSize(string command)
        {
            string[] splitCommand = command.Split(" ");
            var width = int.Parse(splitCommand[0]);
            var height = int.Parse(splitCommand[1]);
            return new Size(width, height);
        }
    }
}
