namespace Task2_2
{
    public class LightRobot : Enemy
    {
        public override char Symbol => 'i';
        public override int MaxHealth => 2;
        public override int Power => 1;
        public override double Speed => 1.2;
        public override int Score => 20;
    }
}
