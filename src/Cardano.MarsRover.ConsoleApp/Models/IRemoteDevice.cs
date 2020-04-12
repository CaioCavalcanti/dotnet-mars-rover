namespace Cardano.MarsRover.ConsoleApp.Models
{
    public interface IRemoteDevice
    {
        int Id { get; }
        ILandingSurface LandingSurface { get; }
        Point Position { get; }
        CardinalDirection PointingDirection { get; }

        void Deploy(ILandingSurface landingSurface, Point position, CardinalDirection pointingDirection);
    }
}
