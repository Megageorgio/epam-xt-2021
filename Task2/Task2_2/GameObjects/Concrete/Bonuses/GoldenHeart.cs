using System;

namespace Task2_2
{
    public class GoldenHeart : Heart
    {
        public override ConsoleColor Color => ConsoleColor.DarkYellow;
        protected override int HealAmount => 2;
    }
}