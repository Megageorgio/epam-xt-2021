using System;

namespace Paint
{
    public record Square (Point A, Point B, Point C, Point D) : Rectangle(A, B, C, D), IFigure
    {
        string IFigure.FigureName => "Квадрат";

        public override double Area => GetSideLength(A, B);

        public override string ToString() => base.ToString();
    }
}