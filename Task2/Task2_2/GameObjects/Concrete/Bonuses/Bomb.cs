using System;

namespace Task2_2
{
    public class Bomb : Bonus
    {
        public override char Symbol => 'o';
        public override ConsoleColor Color => ConsoleColor.Gray;

        protected override void ApplyEffect(IPlayer picker)
        {
            picker.AddBomb();
        }
    }
}