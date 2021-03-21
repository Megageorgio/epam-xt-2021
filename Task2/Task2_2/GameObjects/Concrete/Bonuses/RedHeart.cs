using System;

namespace Task2_2
{
    public class RedHeart : Heart
    {
        public override ConsoleColor Color => ConsoleColor.Red;
        protected override int HealAmount => 1;
    }
}