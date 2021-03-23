using System;

namespace Task2_2
{
    public abstract class Enemy : Entity, IEnemy
    {
        private double Steps { get; set; }
        public abstract double Speed { get; }
        public abstract int Power { get; }
        public abstract int Score { get; }

        public void Think()
        {
            var dirs = new Direction[] {Direction.Up, Direction.Left, Direction.Down, Direction.Right};
            var delta = Math.Abs(Board.Player.X - X) + Math.Abs(Board.Player.Y - Y);

            for (Steps += Speed; Steps >= 1; Steps -= 1)
            {
                if (delta == 1)
                {
                    TryMove(Board.Player.X, Board.Player.Y);
                    return;
                }

                if (delta < (Board.Height + Board.Width) / 6)
                {
                    if (Board.Player.Y < Y && Move(Direction.Up)) continue;

                    if (Board.Player.X < X && Move(Direction.Left)) continue;

                    if (Board.Player.Y > Y && Move(Direction.Down)) continue;

                    if (Board.Player.X > X && Move(Direction.Right)) continue;
                }

                if (Move(dirs[new Random().Next(4)])) continue;

                foreach (var dir in dirs)
                {
                    if (Move(dir)) continue;
                }
            }
        }

        protected override bool OnCollision(IGameObject target)
        {
            switch (target)
            {
                case IPlayer player:
                    player.Damage(Power);
                    return false;
                default:
                    return false;
            }
        }

        protected override void OnDestroy()
        {
            Board.Player.AddScore(Score);
        }
    }
}