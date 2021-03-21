using System;

namespace Task2_2
{
    public class GenericCrystal : Crystal
    {
        public override ConsoleColor Color => ConsoleColor.Blue;
        protected override int Score => 50;
    }
}