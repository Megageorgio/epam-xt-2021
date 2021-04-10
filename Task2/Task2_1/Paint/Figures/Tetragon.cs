using System;

namespace Paint
{
    public record Tetragon(Point A, Point B, Point C, Point D) : Polygon(A, B, C, D)
    {
        public override string FigureName => "Четырехугольник";

        public override string ToString() => base.ToString();
    }
}