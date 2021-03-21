using System;
using System.Linq;

namespace Task2_2
{
    public class GameManager
    {
        private GameBoard Board { get; set; }

        public GameManager(int height, int width)
        {
            Board = new GameBoard(height, width, (height + width) / 2);
        }

        public void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnRandomObject();
            }

            Console.Clear();
            Board.PrintMap();
            while (true)
            {
                if (Board.Player.Health == 0) break;
                Console.SetCursorPosition(0, Board.Height + 3);
                Board.PrintInfo();
                var input = Console.ReadKey(true).KeyChar;
                if (!Board.Player.HandleInput(input)) continue;
                UpdateObjects();
                if (new Random().Next(5) == 0)
                {
                    SpawnRandomObject();
                }
            }

            GameOver();
        }

        private void UpdateObjects()
        {
            foreach (var gameObject in Board.Objects.ToArray())
            {
                if (gameObject is IEnemy)
                {
                    (gameObject as IEnemy).Think();
                    if (Board.Player.Health <= 0) break;
                }
            }

            Board.UpdateEffects();
        }

        private void SpawnRandomObject()
        {
            IGameObject obj = new Random().Next(100) switch
            {
                < 11 => Board.RandomSpawnEnemy<ScoutDrone>(),
                < 19 => Board.RandomSpawnEnemy<LightRobot>(),
                < 25 => Board.RandomSpawnEnemy<GenericRobot>(),
                < 29 => Board.RandomSpawnEnemy<HeavyRobot>(),
                < 31 => Board.RandomSpawnEnemy<Tank>(),
                < 33 => Board.RandomSpawnEnemy<KamikazeDrone>(),
                < 45 => Board.RandomSpawn<Box>(),
                < 57 => Board.RandomSpawn<RedHeart>(),
                < 63 => Board.RandomSpawn<GoldenHeart>(),
                < 68 => Board.RandomSpawn<Bomb>(),
                < 74 => Board.RandomSpawn<Battery>(),
                < 88 => Board.RandomSpawn<LightCrystal>(),
                < 95 => Board.RandomSpawn<GenericCrystal>(),
                < 100 => Board.RandomSpawn<HeavyCrystal>(),
                _ => null
            };
        }

        private void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Игра окончена. Ваш счёт: " + Board.Player.Score + Environment.NewLine +
                              "Нажмите любую клавишу, чтобы начать заново.");
            Console.ReadKey();
            Board = new GameBoard(Board.Height, Board.Width, (Board.Height + Board.Width) / 2);
            Run();
        }
    }
}