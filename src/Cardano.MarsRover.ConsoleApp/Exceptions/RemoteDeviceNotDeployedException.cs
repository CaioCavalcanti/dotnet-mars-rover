using System;
using Cardano.MarsRover.ConsoleApp.Models;

namespace Cardano.MarsRover.ConsoleApp.Exceptions
{
    public class RemoteDeviceNotDeployedException : Exception
    {
        public RemoteDeviceNotDeployedException(string remoteDeviceName) 
            : base($"{remoteDeviceName} is not deployed")
        {
        }
    }
}
