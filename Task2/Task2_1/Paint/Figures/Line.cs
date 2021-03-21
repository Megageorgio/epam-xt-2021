using System;

namespace Paint
{
    public record Line(Point Start, Point End) : IFigure
    {
        string IFigure.FigureName => "Линия";

        double Length = Math.Sqrt(Math.Pow(Start.X - End.X, 2) + Math.Pow(Start.Y - End.Y, 2));

        public override string ToString() =>
            ((IFigure) this).FigureName + Environment.NewLine +
            $"Начало: {Start}" + Environment.NewLine +
            $"Конец: {End}" + Environment.NewLine +
            $"Длина: {Length}";
    }
}