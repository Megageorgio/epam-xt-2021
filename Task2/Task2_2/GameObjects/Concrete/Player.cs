using System;

namespace Task2_2
{
    public class Player : Entity, IPlayer
    {
        public int Score { get; private set; }
        public int Bombs { get; private set; }
        public int Batteries { get; private set; }
        public override char Symbol => '☺';
        public override ConsoleColor Color => ConsoleColor.Magenta;

        public override int MaxHealth => 10;

        public void Heal(int points)
        {
            Health += points;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public bool HandleInput(char input)
        {
            var dir = Direction.None;
            switch (char.ToLower(input))
            {
                case 'w' or 'ц':
                    dir = Direction.Up;
                    break;
                case 'a' or 'ф':
                    dir = Direction.Left;
                    break;
                case 's' or 'ы':
                    dir = Direction.Down;
                    break;
                case 'd' or 'в':
                    dir = Direction.Right;
                    break;
                case 'b' or 'и':
                    UseBomb();
                    break;
                default:
                    return false;
            }

            if (dir != Direction.None)
            {
                if (char.IsLower(input))
                {
                    Move(dir);
                }
                else
                {
                    Shoot(dir);
                }
            }

            return true;
        }

        protected override bool OnCollision(IGameObject target)
        {
            switch (target)
            {
                case IEffect:
                    return true;
                case IBonus:
                    (target as IBonus).Pick(this);
                    return true;
                case IAttackable:
                    if ((target as IAttackable).Damage(1))
                    {
                        return OnCollision(Board[target.X, target.Y]);
                    }

                    return false;
                default:
                    return false;
            }
        }

        public void AddScore(int score)
        {
            Score += score;
        }

        public void AddBomb()
        {
            Bombs++;
        }

        private void UseBomb()
        {
            if (Bombs == 0) return;
            Bombs--;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    var targetX = X + i;
                    var targetY = Y + j;
                    (Board[targetX, targetY] as IAttackable)?.Damage(2);
                    Board.Spawn<BombEffect>(targetX, targetY);
                    Board.UpdateMapCell(targetX, targetY);
                }
            }
        }

        public void AddBattery()
        {
            Batteries++;
        }

        private void Shoot(Direction dir)
        {
            if (Batteries == 0) return;
            Batteries--;
            var xOffset = 0;
            var yOffset = 0;
            while (true)
            {
                var isVertical = true;
                switch (dir)
                {
                    case Direction.Up:
                        yOffset--;
                        break;
                    case Direction.Left:
                        isVertical = false;
                        xOffset--;
                        break;
                    case Direction.Down:
                        yOffset++;
                        break;
                    case Direction.Right:
                        isVertical = false;
                        xOffset++;
                        break;
                }

                var targetX = X + xOffset;
                var targetY = Y + yOffset;

                if (targetX < 0 || targetX >= Board.Width ||
                    targetY < 0 || targetY >= Board.Height)
                {
                    break;
                }

                var gameObject = Board[targetX, targetY];
                if (gameObject is IAttackable)
                {
                    (gameObject as IAttackable).Damage(1);
                }
                else if (gameObject is not IBonus and not null)
                {
                    break;
                }

                if (isVertical)
                {
                    Board.Spawn<VerticalLaserEffect>(targetX, targetY);
                }
                else
                {
                    Board.Spawn<HorizontalLaserEffect>(targetX, targetY);
                }

                Board.UpdateMapCell(targetX, targetY);
            }
        }
    }
}