using System.Threading.Tasks;

namespace Cardano.MarsRover.ConsoleApp.EventHandling
{
    public interface IRemoteDeviceEventHandler<TRemoteDeviceEvent>
        where TRemoteDeviceEvent : RemoteDeviceEvent
    {
        Task HandleEventAsync(TRemoteDeviceEvent @event);
    }
}
