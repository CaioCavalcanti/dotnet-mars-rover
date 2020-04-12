namespace Cardano.MarsRover.ConsoleApp.Navigation.Models
{
    public interface ICompass
    {
        CardinalDirection GetCardinalDirectionOnLeftSideOf(CardinalDirection direction);
        CardinalDirection GetCardinalDirectionOnRightSideOf(CardinalDirection direction);
    }
}
