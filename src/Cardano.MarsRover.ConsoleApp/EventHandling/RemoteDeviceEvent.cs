using System;

namespace Cardano.MarsRover.ConsoleApp.EventHandling
{
    public class RemoteDeviceEvent
    {
        public RemoteDeviceEvent(int deviceId)
        {
            DeviceId = deviceId;
            Id = Guid.NewGuid();
            ReportedDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public int DeviceId { get; set; }
        public DateTime ReportedDate { get; set; }
    }
}
