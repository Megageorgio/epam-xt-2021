using System;

namespace Paint
{
    public record Ring(Point Center, Circle Start, Circle End) : Figure
    {
        public override string FigureName => "Кольцо";

        public double Area => Math.PI * Math.Abs(End.Radius * End.Radius - Start.Radius * Start.Radius);

        public double Length => Start.Length + End.Length;

        public Ring(Point center, int startRadius, int endRadius)
            : this(center, new Circle(center, startRadius), new Circle(center, endRadius))
        {
        }

        public override string ToString() => FormatOutput(
            base.ToString(),
            "Центр: " + Center,
            "Радиус первой окружности: " + Start.Radius,
            "Радиус второй окружности: " + End.Radius,
            "Суммарная длина окружностей: " + Length,
            "Площадь: " + Area);
    }
}