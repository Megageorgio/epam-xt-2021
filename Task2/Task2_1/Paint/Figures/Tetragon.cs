using System;

namespace Paint
{
    public record Tetragon(Point A, Point B, Point C, Point D) : Polygon(A, B, C, D), IFigure
    {
        string IFigure.FigureName => "Четырехугольник";

        public override string ToString() => base.ToString();
    }
}