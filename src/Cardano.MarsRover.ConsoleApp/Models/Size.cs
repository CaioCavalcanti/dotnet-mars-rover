using System;

namespace Cardano.MarsRover.ConsoleApp.Models
{
    public class Size
    {
        public Size(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException($"Size '{width} {height}' is not valid, must be positive integers");
            }

            Width = width;
            Height = height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public override string ToString()
        {
            return $"{Width} {Height}";
        }
    }
}
