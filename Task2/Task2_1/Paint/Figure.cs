using System;

namespace Paint
{
    public abstract record Figure : IFigure
    {
        public abstract string FigureName { get; }
        public override string ToString() => FigureName;

        protected string FormatOutput(params string[] rows) =>
            string.Join(Environment.NewLine, rows);
    }
}