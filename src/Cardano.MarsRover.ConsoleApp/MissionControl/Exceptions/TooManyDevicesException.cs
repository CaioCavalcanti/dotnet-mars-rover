using System;

namespace Cardano.MarsRover.ConsoleApp.MissionControl.Exceptions
{
    public class TooManyDevicesException : Exception
    {
        public TooManyDevicesException(int deployedDevices, int surfaceArea)
            : base($"Cannot deploy more devices, there is already {deployedDevices} devices deployed and the limit is {surfaceArea - 1}")
        {
        }
    }
}
