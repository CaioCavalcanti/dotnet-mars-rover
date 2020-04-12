namespace Cardano.MarsRover.ConsoleApp.Models
{
    public interface ICompass
    {
        CardinalDirection GetCardinalDirectionOnLeftSideOf(CardinalDirection direction);
        CardinalDirection GetCardinalDirectionOnRightSideOf(CardinalDirection direction);
    }
}
