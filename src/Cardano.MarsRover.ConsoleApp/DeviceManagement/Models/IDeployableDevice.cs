using Cardano.MarsRover.ConsoleApp.Navigation.Models;

namespace Cardano.MarsRover.ConsoleApp.DeviceManagement.Models
{
    public interface IDeployableDevice
    {
        int Id { get; }
        ILandingSurface LandingSurface { get; }
        Point Position { get; }
        CardinalDirection PointingDirection { get; }
        void SetDeviceIdentifier(int id);
        void DeployTo(ILandingSurface landingSurface);
    }
}
