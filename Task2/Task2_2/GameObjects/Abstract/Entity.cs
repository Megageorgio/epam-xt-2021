namespace Task2_2
{
    public abstract class Entity : Attackable, IMovable
    {
        public bool Move(Direction dir)
        {
            var newX = X;
            var newY = Y;
            switch (dir)
            {
                case Direction.Up:
                    newY--;
                    break;
                case Direction.Left:
                    newX--;
                    break;
                case Direction.Down:
                    newY++;
                    break;
                case Direction.Right:
                    newX++;
                    break;
            }

            return TryMove(newX, newY);
        }

        protected abstract bool OnCollision(IGameObject target);

        protected bool TryMove(int x, int y)
        {
            if (x >= Board.Width || x < 0 ||
                y >= Board.Height || y < 0)
            {
                return false;
            }

            var target = Board[x, y];

            if (target is null || OnCollision(target))
            {
                var oldX = _x;
                var oldY = _y;
                _x = x;
                _y = y;
                Board.UpdateMapCell(oldX, oldY);
                Board.UpdateMapCell(_x, _y);
                return true;
            }

            return false;
        }
    }
}