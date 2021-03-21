using System;

namespace Task2_2
{
    public class HeavyCrystal : Crystal
    {
        public override ConsoleColor Color => ConsoleColor.DarkBlue;
        protected override int Score => 50;
    }
}