using System;

namespace Cardano.MarsRover.ConsoleApp.Exceptions
{
    public class InvalidCardinalDirectionException : Exception
    {
        public InvalidCardinalDirectionException(string cardinalDirectionUsed)
            : base($"Cardinal direction '{cardinalDirectionUsed}' is not valid")
        {
        }
    }
}
