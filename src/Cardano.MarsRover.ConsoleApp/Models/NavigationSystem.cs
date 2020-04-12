using System;
using System.Collections.Generic;
using Cardano.MarsRover.ConsoleApp.Exceptions;

namespace Cardano.MarsRover.ConsoleApp.Models
{
    public class NavigationSystem : INavigationSystem
    {
        public Point GetNextPointOnDirection(Point point, CardinalDirection pointingDirection)
        {
            Func<Point, Point> factoryForNextPoint;
            if (_pointFactoriesForNextPositionOnDirection.TryGetValue(pointingDirection, out factoryForNextPoint))
            {
                return factoryForNextPoint.Invoke(point);
            } else
            {
                throw new InvalidCardinalDirectionException(nameof(pointingDirection));
            }
        }

        private static IReadOnlyDictionary<CardinalDirection, Func<Point, Point>> _pointFactoriesForNextPositionOnDirection =
            new Dictionary<CardinalDirection, Func<Point, Point>>
            {
                { CardinalDirection.North, CreateNeighbourPointOnNorth },
                { CardinalDirection.East, CreateNeighbourPointOnEast },
                { CardinalDirection.South, CreateNeighbourPointOnSouth },
                { CardinalDirection.West, CreateNeighbourPointOnWest },
            };

        private static Func<Point, Point> CreateNeighbourPointOnNorth => (point) => new Point(point.X, point.Y + 1);
        private static Func<Point, Point> CreateNeighbourPointOnEast => (point) => new Point(point.X + 1, point.Y);
        private static Func<Point, Point> CreateNeighbourPointOnSouth => (point) => new Point(point.X, point.Y - 1);
        private static Func<Point, Point> CreateNeighbourPointOnWest => (point) => new Point(point.X - 1, point.Y);
    }
}
