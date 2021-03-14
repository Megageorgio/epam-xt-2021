using System;

namespace Paint
{
    public record Point (int X, int Y)
    {
        public override string ToString() => $"({X}, {Y})";
    }
}