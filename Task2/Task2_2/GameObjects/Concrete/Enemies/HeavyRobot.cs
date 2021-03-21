namespace Task2_2
{
    public class HeavyRobot : Enemy
    {
        public override char Symbol => '¶';
        public override int MaxHealth => 4;
        public override int Power => 1;
        public override double Speed => 0.85;
        public override int Score => 40;
    }
}