using System;

namespace Cardano.MarsRover.ConsoleApp.Navigation.Exceptions
{
    public class InvalidPointException : Exception
    {
        public InvalidPointException(string invalidPoint)
            : base($"Point '{invalidPoint}' is not valid")
        {
        }
    }
}
