using System;

namespace Paint
{
    public record Circle(Point Center, int Radius) : Figure
    {
        public override string FigureName => "Окружность";
        public double Length => 2 * Math.PI * Radius;

        public override string ToString() => FormatOutput(
            base.ToString(),
            "Центр: " + Center,
            "Радиус: " + Radius,
            "Длина: " + Length
        );
    }
}