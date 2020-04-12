using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.AppSetup;
using Cardano.MarsRover.ConsoleApp.MissionControl;
using Microsoft.Extensions.DependencyInjection;

namespace Cardano.MarsRover.ConsoleApp
{
    class Program
    {
        private const string _commandsFilePathArg = "CommandFilePath";
        private static IServiceProvider _serviceProvider;
        private static IMissionControlCenter _missionControlCenter;
        private static Dictionary<string, string> _arguments;

        static async Task Main(string[] args)
        {
            LoadArguments(args);
            string[] commandsToSend = GetCommandsToSend();

            ConfigureApp();
            InitializeMissionControlCenter();

            foreach (var command in commandsToSend)
            {
                await _missionControlCenter.SendCommandAsync(command.ToUpper());
            }

            _missionControlCenter.GetMissionResults();

            // TODO: gracefully handle exception

            Console.Write("Mission finished. Exiting application...");
        }

        private static void LoadArguments(string[] args)
        {
            _arguments = new Dictionary<string, string>();

            if (args == null || args.Length == 0) return;

            foreach (string argument in args)
            {
                int idx = argument.IndexOf('=');
                if (idx > 0)
                {
                    _arguments[argument.Substring(0, idx)] = argument.Substring(idx + 1);
                }
            }
        }

        private static void ConfigureApp()
        {
            _serviceProvider = new AppConfigurationBuilder().Build();
        }

        private static void InitializeMissionControlCenter()
        {
            _missionControlCenter = _serviceProvider.GetService<IMissionControlCenter>();
        }

        private static string[] GetCommandsToSend()
        {
            string commandsFilePath;
            string[] commandsToSend = new string[] { };

            if (TryGetCommandsFilePath(out commandsFilePath))
            {
                TryReadCommandsFile(commandsFilePath, out commandsToSend);
            }

            if (commandsToSend.Length > 0)
            {
                return commandsToSend;
            }
            else
            {
                return LoadSampleCommands();
            }
        }

        private static bool TryGetCommandsFilePath(out string commandsFilePath)
        {
            if (_arguments.TryGetValue(_commandsFilePathArg, out commandsFilePath))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Commands file path not provided");
                return false;
            }
        }

        private static bool TryReadCommandsFile(string commandsFilePath, out string[] commands)
        {
            commands = new string[] { };
            try
            {
                Console.WriteLine($"Reading commands from file '{commandsFilePath}'...");
                commands = File.ReadAllLines(commandsFilePath);
                Console.WriteLine($"{commands.Length} commands found on file {commandsFilePath}");
                return true;
            }
            catch (Exception ex)
            {
                // for now it's ok if we can't read the file for some reason, let's just use a static example instead
                Console.WriteLine($"Could not load commands from file {commandsFilePath}: {ex.Message}");
                return false;
            }
        }

        private static string[] LoadSampleCommands()
        {
            Console.WriteLine("Using sample commands.");
            string[] commands = new string[]
            {
                "5 5",
                "1 2 N",
                "LML",
                "3 3 E",
                "MMR"
            };

            return commands;
        }
    }
}