using System;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;

namespace Cardano.MarsRover.ConsoleApp.Navigation.Exceptions
{
    public class PointConflictException : Exception
    {
        public PointConflictException(Point pointUsed)
            : base($"Point '{pointUsed}' is already in use")
        {
        }
    }
}
