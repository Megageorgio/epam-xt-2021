using System;

namespace Task2_2
{
    public class LightCrystal : Crystal
    {
        public override ConsoleColor Color => ConsoleColor.Cyan;
        protected override int Score => 25;
    }
}