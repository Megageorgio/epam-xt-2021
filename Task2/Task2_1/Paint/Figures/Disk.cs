using System;

namespace Paint
{
    public record Disk(Point Center, int Radius) : Circle(Center, Radius), IFigure
    {
        string IFigure.FigureName => "Круг";

        public double Area => Math.PI * Radius * Radius;

        public override string ToString() => base.ToString() + Environment.NewLine +
                                             $"Площадь: {Area}";
    }
}