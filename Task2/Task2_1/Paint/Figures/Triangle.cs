using System;

namespace Paint
{
    public record Triangle(Point A, Point B, Point C) : Polygon(A, B, C), IFigure
    {
        string IFigure.FigureName => "Треугольник";

        public override string ToString() => base.ToString();
    }
}