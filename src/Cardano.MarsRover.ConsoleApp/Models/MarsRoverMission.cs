using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardano.MarsRover.ConsoleApp.Models
{
    public class MarsRoverMission : Mission, IMission
    {
        private IRover _currentRoverInControl;

        public MarsRoverMission() : base()
        {
            _name = "Mars Rover";
        }

        public override ILandingSurface TargetDestination { get; protected set; }
        public override IDeployableDevice CurrentDeviceInControl
        {
            get
            {
                return _currentRoverInControl;
            }
            protected set
            {
                _currentRoverInControl = (IRover)value;
            }
        }

        public override void SetLandingSurface(ILandingSurface landingSurface)
        {
            TargetDestination = landingSurface;
        }

        public override void DeployDevice(IDeployableDevice deviceToDeploy)
        {
            if (deviceToDeploy == null) throw new ArgumentNullException(nameof(deviceToDeploy));
            if (TargetDestination == null) throw new InvalidOperationException("Cannot deploy device, target destination is not set");

            if (CanDeployDevice(deviceToDeploy))
            {
                CurrentDeviceInControl = deviceToDeploy;
                CurrentDeviceInControl.SetDeviceIdentifier(DeployedDevices.Count() + 1);
                CurrentDeviceInControl.DeployTo(TargetDestination);
                DeployedDevices.Add(CurrentDeviceInControl);
            }
        }

        private bool CanDeployDevice(IDeployableDevice deviceToDeploy)
        {
            if ((DeployedDevices.Count() + 1) == TargetDestination.GetArea())
            {
                throw new InvalidOperationException("Cannot add more devices to deploy");
            }

            if (DeployedDevices.Any(regiteredDevice => regiteredDevice.Position == deviceToDeploy.Position))
            {
                throw new InvalidOperationException("There's a device at this position at the moment");
            }

            return true;
        }

        public override void SendCommandsToCurrentDeviceInControl(IList<object> commands)
        {
            if (CurrentDeviceInControl == null) throw new InvalidOperationException("There's no rover in control at the moment");

            Queue<RoverMovement> roverMovementSequence = new Queue<RoverMovement>();
            foreach (object commandObj in commands)
            {
                RoverMovement roverMovement = (RoverMovement)commandObj;
                roverMovementSequence.Enqueue(roverMovement);
            }
            _currentRoverInControl.SetMovementSequence(roverMovementSequence);
        }

        public override async Task DispatchCurrentDeviceInControlAsync()
        {
            if (_currentRoverInControl == null) throw new InvalidOperationException("There's no rover in control at the moment");

            await _currentRoverInControl.StartMovementSequenceAsync();
        }

        public override string GetStatusReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Deployed rovers: {DeployedDevices.Count()}");
            sb.AppendLine($"Final rover location and status:");
            DeployedDevices.ForEach(rover => sb.AppendLine($"[Rover {rover.Id}] {rover}"));
            return sb.ToString();
        }
    }
}
