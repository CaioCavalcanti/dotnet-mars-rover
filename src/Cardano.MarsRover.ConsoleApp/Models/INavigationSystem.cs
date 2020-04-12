namespace Cardano.MarsRover.ConsoleApp.Models
{
    public interface INavigationSystem
    {
        Point GetNextPointOnDirection(Point point, CardinalDirection pointingDirection);
    }
}
