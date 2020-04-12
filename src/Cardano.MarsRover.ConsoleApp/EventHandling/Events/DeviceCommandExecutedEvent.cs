namespace Cardano.MarsRover.ConsoleApp.EventHandling.Events
{
    public class DeviceCommandExecutedEvent : RemoteDeviceEvent
    {
        public DeviceCommandExecutedEvent(int deviceId) : base(deviceId)
        {
        }
    }
}
