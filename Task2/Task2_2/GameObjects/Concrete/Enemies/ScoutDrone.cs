namespace Task2_2
{
    public class ScoutDrone : Enemy
    {
        public override char Symbol => '☼';
        public override int MaxHealth => 1;
        public override int Power => 1;
        public override double Speed => 1.6;
        public override int Score => 10;
    }
}