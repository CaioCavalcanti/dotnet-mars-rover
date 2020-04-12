using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.MarsRover.ConsoleApp.Models
{
    public interface IMission
    {
        public string Name { get; }
        public ILandingSurface TargetDestination { get; }
        public List<IDeployableDevice> DeployedDevices { get; }
        public IDeployableDevice CurrentDeviceInControl { get; }

        void SetLandingSurface(ILandingSurface landingSurface);
        void DeployDevice(IDeployableDevice deviceToDeploy);
        void SendCommandsToCurrentDeviceInControl(IList<object> commands);
        Task DispatchCurrentDeviceInControlAsync();
        string GetStatusReport();
    }
}
