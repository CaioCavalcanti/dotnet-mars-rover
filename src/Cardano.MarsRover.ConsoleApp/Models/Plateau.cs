using System;

namespace Cardano.MarsRover.ConsoleApp.Models
{
    public class Plateau : ILandingSurface
    {
        public Size Size { get; private set; }

        public int GetArea()
        {
            return Size.Width * Size.Height;
        }

        public bool IsPointWithinBoundaries(Point point)
        {
            bool xIsValid = point.X >= 0 && point.X <= Size.Width;
            bool yIsValid = point.Y >= 0 && point.Y <= Size.Height;
            return xIsValid && yIsValid;

        }

        public void SetSize(Size size)
        {
            Size = size ?? throw new ArgumentNullException(nameof(size));
        }
    }
}
