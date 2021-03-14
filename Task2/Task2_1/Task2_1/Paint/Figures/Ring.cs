using System;

namespace Paint
{
    public record Ring(Point Center, Circle Start, Circle End) : IFigure
    {
        string IFigure.FigureName => "Кольцо";

        public double Area => Math.PI * Math.Abs(End.Radius * End.Radius - Start.Radius * Start.Radius);

        public double Length => Start.Length + End.Length;

        public Ring(Point center, int startRadius, int endRadius)
            : this(center, new Circle(center, startRadius), new Circle(center, endRadius))
        {
        }

        public override string ToString() =>
            ((IFigure) this).FigureName + Environment.NewLine +
            $"Центр: {Center}" + Environment.NewLine +
            $"Радиус первой окружности: {Start.Radius}" + Environment.NewLine +
            $"Радиус второй окружности: {End.Radius}" + Environment.NewLine +
            $"Суммарная длина окружностей: {Length}" + Environment.NewLine +
            $"Площадь: {Area}";
    }
}