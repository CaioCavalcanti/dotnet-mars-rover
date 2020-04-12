using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.MissionControl.CommandHandling;
using Cardano.MarsRover.ConsoleApp.MissionControl.Exceptions;
using Cardano.MarsRover.ConsoleApp.MissionControl.Models;

namespace Cardano.MarsRover.ConsoleApp.MissionControl
{
    public class MissionControlCenter : IMissionControlCenter
    {
        private readonly IEnumerable<IMission> _missions;
        private readonly IEnumerable<ICommandHandler> _commandHandlers;
        private IMission _missionSelected;

        public MissionControlCenter(
            IEnumerable<IMission> missions,
            IEnumerable<ICommandHandler> commandHandlers
        )
        {
            _missions = missions;
            _commandHandlers = commandHandlers;

            Startup();
        }

        public async Task SendCommandAsync(string command)
        {
            ShowMessage($"Command received: '{command}'");
            // TODO: validate command sequence

            var commandHandler = _commandHandlers.FirstOrDefault(handler => handler.MatchesCommandPattern(command));

            if (commandHandler != null)
            {
                await commandHandler.HandleCommandAsync(_missionSelected, command);
            }
            else
            {
                throw new InvalidCommandException(command);
            }
        }

        public void GetMissionResults()
        {
            string missionStatusReport = _missionSelected.GetStatusReport();
            ShowMessage(missionStatusReport);
        }

        private void Startup()
        {
            ShowMessage("Welcome to Cardano Mission Control Center");
            LoadMissions();
        }

        private void LoadMissions()
        {
            if (_missions == null || !_missions.Any())
            {
                ShowMessage("There are no missions available at the moment");
            }
            else
            {
                ShowMessage("Missions available:");
                foreach (var mission in _missions)
                {
                    ShowMessage($"- {mission}");
                }

                if (_missions.Count() == 1)
                {
                    _missionSelected = _missions.First();
                }

                // TODO: more than one mission? let user select one
                StartMissionSelected();
            }
        }

        private void StartMissionSelected()
        {
            ShowMissionSelected();
        }

        private void ShowMissionSelected()
        {
            ShowMessage($"Mission selected: {_missionSelected}");
        }

        private void ShowMessage(string message)
        {
            string prefix = $"[{DateTime.Now}]";
            if (_missionSelected != null)
            {
                prefix += $"[{_missionSelected}]";
            }
            Console.WriteLine($"{prefix} {message}");
        }
    }
}
