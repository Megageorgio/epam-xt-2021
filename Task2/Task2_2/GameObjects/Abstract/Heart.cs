namespace Task2_2
{
    public abstract class Heart : Bonus
    {
        public override char Symbol => '♥';
        protected abstract int HealAmount { get; }

        protected override void ApplyEffect(IPlayer picker)
        {
            picker.Heal(HealAmount);
        }
    }
}