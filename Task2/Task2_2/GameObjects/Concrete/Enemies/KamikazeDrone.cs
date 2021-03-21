using System;

namespace Task2_2
{
    public class KamikazeDrone : Enemy
    {
        public override char Symbol => '☼';
        public override ConsoleColor Color => ConsoleColor.DarkRed;
        public override int MaxHealth => 1;
        public override int Power => 3;
        public override double Speed => 1.6;
        public override int Score => 20;

        protected override bool OnCollision(IGameObject target)
        {
            switch (target)
            {
                case IPlayer:
                    (target as IPlayer)?.Damage(Power);
                    Destroy();
                    return false;
                default:
                    return false;
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Board.Spawn<BombEffect>(X, Y);
        }
    }
}