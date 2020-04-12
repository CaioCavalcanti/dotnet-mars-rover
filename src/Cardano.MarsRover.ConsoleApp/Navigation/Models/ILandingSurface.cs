namespace Cardano.MarsRover.ConsoleApp.Navigation.Models
{
    public interface ILandingSurface
    {
        void SetSize(Size size);
        int GetArea();
        bool IsPointWithinBoundaries(Point point);
    }
}
