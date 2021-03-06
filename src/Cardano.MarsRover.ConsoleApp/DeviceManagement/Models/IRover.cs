﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cardano.MarsRover.ConsoleApp.DeviceManagement.Models
{
    public interface IRover : IDeployableDevice
    {
        void SetMovementSequence(Queue<RoverMovement> movementSequence);
        Task StartMovementSequenceAsync();
    }
}
