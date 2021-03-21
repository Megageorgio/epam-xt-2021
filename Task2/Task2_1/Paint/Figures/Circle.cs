using System;

namespace Paint
{
    public record Circle(Point Center, int Radius) : IFigure
    {
        string IFigure.FigureName => "Окружность";
        public double Length => 2 * Math.PI * Radius;

        public override string ToString() =>
            ((IFigure) this).FigureName + Environment.NewLine +
            $"Центр: {Center}" + Environment.NewLine +
            $"Радиус: {Radius}" + Environment.NewLine +
            $"Длина: {Length}";
    }
}