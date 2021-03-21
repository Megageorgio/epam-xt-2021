using System;

namespace Task2_2
{
    public abstract class GameObject : IGameObject
    {
        protected int _x;
        protected int _y;
        public GameBoard Board { get; init; }

        public int X
        {
            get => _x;
            init => _x = value;
        }

        public int Y
        {
            get => _y;
            init => _y = value;
        }

        public abstract char Symbol { get; }
        public abstract ConsoleColor Color { get; }
    }
}