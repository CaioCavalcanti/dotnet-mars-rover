using System;

namespace Cardano.MarsRover.ConsoleApp.DeviceManagement.Exceptions
{
    public class RemoteDeviceNotDeployedException : Exception
    {
        public RemoteDeviceNotDeployedException(string remoteDeviceName)
            : base($"{remoteDeviceName} is not deployed")
        {
        }
    }
}
