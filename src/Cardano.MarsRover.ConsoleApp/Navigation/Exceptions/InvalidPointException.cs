﻿using System;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;

namespace Cardano.MarsRover.ConsoleApp.Navigation.Exceptions
{
    public class InvalidPointException : Exception
    {
        public InvalidPointException(Point invalidPoint)
            : base($"Point '{invalidPoint}' is not valid")
        {
        }
    }
}
