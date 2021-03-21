using System;

namespace Task2_2
{
    public class Wall : GameObject
    {
        public override char Symbol => '█';
        public override ConsoleColor Color => ConsoleColor.DarkGray;
    }
}