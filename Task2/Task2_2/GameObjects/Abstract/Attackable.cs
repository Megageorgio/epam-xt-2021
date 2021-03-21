using System;

namespace Task2_2
{
    public abstract class Attackable : GameObject, IAttackable
    {
        public abstract int MaxHealth { get; }
        public int Health { get; protected set; }

        public override ConsoleColor Color
        {
            get
            {
                if (Health == MaxHealth) return ConsoleColor.DarkGreen;
                if (Health == 1) return ConsoleColor.DarkRed;
                if (Health == 2) return ConsoleColor.Red;
                if (Health == 3) return ConsoleColor.DarkYellow;
                return ConsoleColor.Green;
            }
        }

        public Attackable()
        {
            Health = MaxHealth;
        }

        public virtual bool Damage(int points)
        {
            Health -= points;
            if (Health < 0)
            {
                Health = 0;
            }

            if (Health == 0)
            {
                Destroy();
                Board.UpdateMapCell(X, Y);
                return true;
            }

            Board.UpdateMapCell(X, Y);
            return false;
        }

        protected virtual void OnDestroy()
        {
        }

        protected void Destroy()
        {
            Board.Remove(this);
            OnDestroy();
        }
    }
}