using System;

namespace Task2_2
{
    public class Box : Attackable
    {
        public override char Symbol => '■';
        public override ConsoleColor Color => Health == 2 ? ConsoleColor.DarkMagenta : ConsoleColor.Magenta;

        public override int MaxHealth => 2;

        protected override void OnDestroy()
        {
            IGameObject obj = new Random().Next(100) switch
            {
                < 20 => Board.Spawn<RedHeart>(X, Y),
                < 40 => Board.Spawn<LightCrystal>(X, Y),
                < 50 => Board.Spawn<GoldenHeart>(X, Y),
                < 60 => Board.Spawn<GenericCrystal>(X, Y),
                < 70 => Board.Spawn<Bomb>(X, Y),
                < 80 => Board.Spawn<Battery>(X, Y),
                _ => null
            };
        }
    }
}