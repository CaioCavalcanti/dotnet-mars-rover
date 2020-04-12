using System;
using System.Collections.Generic;

namespace Cardano.MarsRover.ConsoleApp.Navigation.Models
{
    public class Compass : ICompass
    {
        public CardinalDirection GetCardinalDirectionOnLeftSideOf(CardinalDirection direction)
        {
            return TryGetCardinalDirectionFromMapping(direction, _cardinalDirectionMappedToLeft);
        }

        public CardinalDirection GetCardinalDirectionOnRightSideOf(CardinalDirection direction)
        {
            return TryGetCardinalDirectionFromMapping(direction, _cardinalDirectionMappedToRight);
        }

        private CardinalDirection TryGetCardinalDirectionFromMapping(
            CardinalDirection fromDirection,
            IReadOnlyDictionary<CardinalDirection, CardinalDirection> cardinalPositionMapping
        )
        {
            if (cardinalPositionMapping.TryGetValue(fromDirection, out CardinalDirection directionOnSide))
            {
                return directionOnSide;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Cardinal direction '{fromDirection}' is not valid");
            }
        }

        private static readonly IReadOnlyDictionary<CardinalDirection, CardinalDirection> _cardinalDirectionMappedToLeft =
            new Dictionary<CardinalDirection, CardinalDirection>
            {
                { CardinalDirection.North, CardinalDirection.West },
                { CardinalDirection.East, CardinalDirection.North },
                { CardinalDirection.South, CardinalDirection.East },
                { CardinalDirection.West, CardinalDirection.South }
            };

        private static readonly IReadOnlyDictionary<CardinalDirection, CardinalDirection> _cardinalDirectionMappedToRight =
            new Dictionary<CardinalDirection, CardinalDirection>
            {
                { CardinalDirection.North, CardinalDirection.East },
                { CardinalDirection.East, CardinalDirection.South },
                { CardinalDirection.South, CardinalDirection.West },
                { CardinalDirection.West, CardinalDirection.North }
            };
    }
}
