using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.MarsRover.ConsoleApp.Models
{
    public abstract class Mission : IMission
    {
        protected string _name;
        public Mission()
        {
            DeployedDevices = new List<IDeployableDevice>();
        }

        public string Name => _name;
        public abstract ILandingSurface TargetDestination { get; protected set; }
        public List<IDeployableDevice> DeployedDevices { get; }
        public abstract IDeployableDevice CurrentDeviceInControl { get; protected set; }

        public abstract void DeployDevice(IDeployableDevice deviceToDeploy);
        public abstract Task DispatchCurrentDeviceInControlAsync();
        public abstract void SendCommandsToCurrentDeviceInControl(IList<object> commands);
        public abstract void SetLandingSurface(ILandingSurface landingSurface);
        public abstract string GetStatusReport();
        public override string ToString() => Name;
    }
}
