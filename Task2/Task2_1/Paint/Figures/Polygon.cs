using System;
using System.Linq;

namespace Paint
{
    public record Polygon(params Point[] Points) : Figure
    {
        public override string FigureName => "Многоугольник";

        public virtual double Area =>
            Points.Select((point, i) => AreaHelper(point, ++i == Points.Length ? Points[0] : Points[i])).Sum() / 2;

        public double Perimeter =>
            Points.Select((point, i) => GetSideLength(point, ++i == Points.Length ? Points[0] : Points[i])).Sum();

        private double AreaHelper(Point a, Point b) => a.X * b.Y - a.Y * b.X;

        public double GetSideLength(Point a, Point b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

        public override string ToString() => FormatOutput(
            base.ToString(),
            FormatOutput(Points.Select((point, i) => $"{i + 1} точка: {point}").ToArray()),
            "Площадь: " + Area,
            "Периметр: " + Perimeter);
    }
}