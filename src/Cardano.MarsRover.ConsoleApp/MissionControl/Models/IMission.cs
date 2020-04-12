using System.Collections.Generic;
using System.Threading.Tasks;
using Cardano.MarsRover.ConsoleApp.DeviceManagement.Models;
using Cardano.MarsRover.ConsoleApp.Navigation.Models;

namespace Cardano.MarsRover.ConsoleApp.MissionControl.Models
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
