using System;

namespace Task2_2
{
    public interface IGameObject
    {
        int X { get; init; }
        int Y { get; init; }
        char Symbol { get; }
        ConsoleColor Color { get; }
    }
}