namespace Task2_2
{
    public abstract class Crystal : Bonus
    {
        public override char Symbol => '♦';
        protected abstract int Score { get; }

        protected override void ApplyEffect(IPlayer picker)
        {
            picker.AddScore(Score);
        }
    }
}