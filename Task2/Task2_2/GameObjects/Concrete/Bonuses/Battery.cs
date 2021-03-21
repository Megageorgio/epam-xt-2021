using System;

namespace Task2_2
{
    public class Battery : Bonus
    {
        public override char Symbol => '=';
        public override ConsoleColor Color => ConsoleColor.DarkBlue;

        protected override void ApplyEffect(IPlayer picker)
        {
            picker.AddBattery();
        }
    }
}