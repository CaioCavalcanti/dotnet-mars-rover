namespace Cardano.MarsRover.ConsoleApp.Navigation.Models
{
    public interface INavigationSystem
    {
        Point GetNextPointOnDirection(Point point, CardinalDirection pointingDirection);
    }
}
