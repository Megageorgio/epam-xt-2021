namespace Task2_2
{
    public class GenericRobot : Enemy
    {
        public override char Symbol => 'j';
        public override int MaxHealth => 3;
        public override int Power => 1;
        public override double Speed => 1;
        public override int Score => 30;
    }
}