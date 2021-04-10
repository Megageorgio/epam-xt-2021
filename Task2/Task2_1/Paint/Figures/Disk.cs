using System;

namespace Paint
{
    public record Disk(Point Center, int Radius) : Circle(Center, Radius), IFigure
    {
        public override string FigureName => "Круг";

        public double Area => Math.PI * Radius * Radius;

        public override string ToString() => FormatOutput(
            base.ToString(), 
            "Площадь" + Area);
    }
}