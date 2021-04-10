using System;

namespace Paint
{
    public record Rectangle(Point A, Point B, Point C, Point D) : Tetragon(A, B, C, D)
    {
        public override string FigureName => "Прямоугольник";

        public override double Area => GetSideLength(A, B) * GetSideLength(C, D);

        public override string ToString() => base.ToString();
    }
}
