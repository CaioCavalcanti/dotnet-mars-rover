namespace Cardano.MarsRover.ConsoleApp.Models
{
    public interface IRover : IRemoteDevice
    {
        void TurnLeft();
        void TurnRight();
        void MoveForward();
    }
}
