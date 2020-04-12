namespace Cardano.MarsRover.ConsoleApp.Models
{
    public interface ILandingSurface
    {
        int GetArea();
        bool IsPointWithinBoundaries(Point point);
    }
}
