using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2_2
{
    public class GameBoard
    {
        private readonly IList<IGameObject> _objects = new List<IGameObject>();
        public IReadOnlyList<IGameObject> Objects => _objects as IReadOnlyList<IGameObject>;
        public int Height { get; }
        public int Width { get; }
        public IPlayer Player { get; }
        private bool CanPrint { get; set; }

        public GameBoard(int height, int width, int wallsCount)
        {
            Height = height;
            Width = width;
            Player = RandomSpawn<Player>();
            for (int i = 0; i < wallsCount; i++)
            {
                RandomSpawn<Wall>();
            }
        }

        public bool Remove(IGameObject gameObject)
        {
            if (gameObject == null)
            {
                return false;
            }

            _objects.Remove(gameObject);
            return true;
        }

        public void UpdateEffects()
        {
            foreach (var effect in Objects.OfType<Effect>().ToArray())
            {
                effect.Update();
                UpdateMapCell(effect.X, effect.Y);
            }
        }

        public T Spawn<T>(int x, int y) where T : GameObject, new()
        {
            var gameObject = new T() {Board = this, X = x, Y = y};
            _objects.Add(gameObject);
            UpdateMapCell(x, y);
            return gameObject;
        }

        public T RandomSpawn<T>() where T : GameObject, new()
        {
            return RandomSpawnOutsideArea<T>(0, 0, 0);
        }

        public T RandomSpawnEnemy<T>() where T : Enemy, new()
        {
            var radius = (Width + Height) / 5;
            return RandomSpawnOutsideArea<T>(Player.X, Player.Y, radius < 20 ? radius : 20);
        }

        private T RandomSpawnOutsideArea<T>(int areaX, int areaY, int areaRadius) where T : GameObject, new()
        {
            if (Width * Height - _objects.Count == 0) return null;
            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                var x = rand.Next(Width);
                var y = rand.Next(Height);
                if ((areaRadius == 0 || Math.Abs(areaX - x) + Math.Abs(areaY - y) > areaRadius)
                    && this[x, y] is null)
                {
                    return Spawn<T>(x, y);
                }
            }

            return null;
        }

        public IGameObject this[int x, int y] =>
            GetObjectByCoords(x, y);

        private IGameObject GetObjectByCoords(int x, int y) =>
            Objects.FirstOrDefault(obj => obj.X == x && obj.Y == y && obj is not IEffect);

        private IGameObject GetEffectByCoords(int x, int y) =>
            Objects.FirstOrDefault(obj => obj.X == x && obj.Y == y && obj is IEffect);

        public void UpdateMapCell(int x, int y)
        {
            if (!CanPrint) return;
            Console.SetCursorPosition(x + 1, y + 1);
            PrintCell(x, y);
        }

        private void PrintCell(int x, int y)
        {
            var symbol = ' ';
            var color = ConsoleColor.White;
            var gameObject = GetEffectByCoords(x, y) ?? this[x, y];
            if (gameObject != null)
            {
                symbol = gameObject.Symbol;
                color = gameObject.Color;
            }

            ColoredWrite(symbol.ToString(), color);
        }

        public void PrintMap()
        {
            ColoredWrite('╔' + new string('═', Width) + '╗' + Environment.NewLine);
            for (int i = 0; i < Height; i++)
            {
                ColoredWrite("║");
                for (int j = 0; j < Width; j++)
                {
                    PrintCell(j, i);
                }

                ColoredWrite("║" + Environment.NewLine);
            }

            ColoredWrite('╚' + new string('═', Width) + '╝');
            Console.WriteLine();
            CanPrint = true;
        }

        public void PrintInfo()
        {
            ColoredWrite("Здоровье: ");
            ColoredWrite(new string('♥', Player.Health), ConsoleColor.Red);
            ColoredWrite(new string('♥', Player.MaxHealth - Player.Health) + Environment.NewLine, ConsoleColor.Gray);
            ColoredWrite("Батарейки: " + Player.Batteries + Environment.NewLine);
            ColoredWrite("Бомбы: " + Player.Bombs + Environment.NewLine);
            ColoredWrite("Счёт: " + Player.Score + Environment.NewLine);
            ColoredWrite(
                "Управление: wasd - движение и атака, shift + wasd - стрельба, b - бомбы" + Environment.NewLine);
        }

        private void ColoredWrite(string s, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(s);
        }
    }
}