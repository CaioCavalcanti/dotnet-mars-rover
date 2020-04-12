using System;
using Cardano.MarsRover.ConsoleApp.MissionControl;
using Cardano.MarsRover.ConsoleApp.MissionControl.CommandHandling;
using Cardano.MarsRover.ConsoleApp.MissionControl.CommandHandling.CommandHandlers;
using Cardano.MarsRover.ConsoleApp.MissionControl.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Cardano.MarsRover.ConsoleApp.AppSetup
{
    public class AppConfigurationBuilder
    {
        private readonly IServiceCollection _services;

        public AppConfigurationBuilder()
        {
            _services = new ServiceCollection();
        }

        private void LoadMissions()
        {
            _services.AddSingleton<IMission, MarsRoverMission>();
        }

        private void LoadCommandHandlers()
        {
            _services.AddSingleton<ICommandHandler, SetPlateauSizeCommandHandler>();
            _services.AddSingleton<ICommandHandler, SetDevicePositionCommandHandler>();
            _services.AddSingleton<ICommandHandler, SetDeviceMovementsCommandHandler>();
        }

        public IServiceProvider Build()
        {
            _services.AddSingleton<IMissionControlCenter, MissionControlCenter>();

            LoadMissions();
            LoadCommandHandlers();

            return _services.BuildServiceProvider();
        }
    }
}
