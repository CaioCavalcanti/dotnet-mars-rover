namespace Cardano.MarsRover.ConsoleApp.Models
{
    public interface ILandingSurface
    {
        void SetSize(Size size);
        int GetArea();
        bool IsPointWithinBoundaries(Point point);
    }
}
