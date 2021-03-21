namespace Task2_2
{
    public class Tank : Enemy
    {
        public override char Symbol => '@';
        public override int MaxHealth => 5;
        public override int Power => 2;
        public override double Speed => 0.5;
        public override int Score => 50;
    }
}