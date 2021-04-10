using System;

namespace Paint
{
    public record Line(Point Start, Point End) : Figure
    {
        public override string FigureName => "Линия";

        double Length = Math.Sqrt(Math.Pow(Start.X - End.X, 2) + Math.Pow(Start.Y - End.Y, 2));

        public override string ToString() => FormatOutput(
            base.ToString(),
            "Начало: " + Start,
            "Конец: " + End,
            "Длина: " + Length
        );
    }
}