﻿using System;

namespace Cardano.MarsRover.ConsoleApp.MissionControl.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string commandSent)
            : base($"Command '{commandSent}' is not valid")
        {
        }
    }
}
