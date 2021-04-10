using System;
using System.Collections.Generic;
using System.Linq;

namespace Paint
{
    public class Painter
    {
        public IDictionary<string, IList<IFigure>> Figures { get; set; } = new Dictionary<string, IList<IFigure>>();

        private string username;

        public void Run()
        {
            var opt = 4;
            do
            {
                if (username != null)
                {
                    Console.WriteLine(username + ", выберите действие:" + Environment.NewLine +
                                      "1. Добавить фигуру" + Environment.NewLine +
                                      "2. Вывести фигуры" + Environment.NewLine +
                                      "3. Очистить холст" + Environment.NewLine +
                                      "4. Сменить пользователя" + Environment.NewLine +
                                      "5. Выход");
                    if (!int.TryParse(Console.ReadLine(), out opt))
                    {
                        continue;
                    }
                }
            } while (HandleMainMenuInput(opt));
        }

        private bool HandleMainMenuInput(int opt)
        {
            switch (opt)
            {
                case 1:
                    Figures[username].Add(GetFigureFromInput());
                    Console.WriteLine("Фигура добавлена");
                    break;
                case 2:
                    Console.WriteLine("Список фигур:");
                    Console.WriteLine(Figures[username].Count == 0
                        ? "Фигуры осутствуют"
                        : string.Join(Environment.NewLine + new string('-', 20) + Environment.NewLine,
                            Figures[username]));
                    break;
                case 3:
                    Figures[username].Clear();
                    Console.WriteLine("Все фигуры удалены!");
                    break;
                case 4:
                    do
                    {
                        Console.WriteLine("Введите имя:");
                        username = Console.ReadLine();
                    } while (username == string.Empty);

                    Console.WriteLine("Имя изменено!");
                    if (!Figures.ContainsKey(username))
                    {
                        Figures.Add(username, new List<IFigure>());
                    }

                    break;
                case 5:
                    return false;
            }

            return true;
        }

        private IFigure GetFigureFromInput()
        {
            // хз что с этим делать, вариант с константами не получается, а из свойства без создания объекта вытащить не получится
            // есть вариант хранить имена в самом пэйнтере, а не в двух местах, но это будет не очень правильно
            var figureNames = new[]
            {
                "Линия", "Многоугольник", "Четырехугольник", "Прямоугольник", "Квадрат", "Треугольник", "Окружность",
                "Круг", "Кольцо"
            };
            while (true)
            {
                Console.WriteLine(username + ", выберите нужную фигуру:" + Environment.NewLine +
                                  string.Join(Environment.NewLine,
                                      figureNames.Select((name, i) => $"{i + 1}. {name}")));
                if (!int.TryParse(Console.ReadLine(), out var opt) ||
                    opt <= 0 || opt > figureNames.Length)
                {
                    continue;
                }

                Console.WriteLine($"Введите параметры фигуры {figureNames[opt - 1]}:");
                var figure = HandleFigureMenuInput(opt);
                if (figure == null)
                {
                    continue;
                }

                Console.WriteLine($"Фигура {figureNames[opt - 1]} создана!");
                return figure;
            }
        }

        private IFigure HandleFigureMenuInput(int opt)
        {
            switch (opt)
            {
                case 1:
                    var linePoints = GetPointsFromInput(2);
                    return new Line(linePoints[0], linePoints[1]);
                case 2:
                    Console.WriteLine("Введите количество точек:");
                    var polygonPointsCount = int.Parse(Console.ReadLine());
                    var polygonPoints = GetPointsFromInput(polygonPointsCount);
                    return new Polygon(polygonPoints);
                case 3:
                    var tetragonPoints = GetPointsFromInput(4);
                    return new Tetragon(tetragonPoints[0], tetragonPoints[1], tetragonPoints[2], tetragonPoints[3]);
                case 4:
                    var rectanglePoints = GetPointsFromInput(4);
                    return new Rectangle(rectanglePoints[0], rectanglePoints[1], rectanglePoints[2],
                        rectanglePoints[3]);
                case 5:
                    var squarePoints = GetPointsFromInput(4);
                    return new Square(squarePoints[0], squarePoints[1], squarePoints[2], squarePoints[3]);
                case 6:
                    var trianglePoints = GetPointsFromInput(3);
                    return new Triangle(trianglePoints[0], trianglePoints[1], trianglePoints[2]);
                case 7:
                    var circleCenter = GetPointFromInput();
                    Console.WriteLine("Введите радиус:");
                    var circleRadius = int.Parse(Console.ReadLine());
                    return new Circle(circleCenter, circleRadius);
                case 8:
                    var diskCenter = GetPointFromInput();
                    Console.WriteLine("Введите радиус:");
                    var diskRadius = int.Parse(Console.ReadLine());
                    return new Disk(diskCenter, diskRadius);
                case 9:
                    var ringCenter = GetPointFromInput();
                    Console.WriteLine("Введите радиус первой окружности:");
                    var ringStartRadius = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите радиус второй окружности:");
                    var ringEndRadius = int.Parse(Console.ReadLine());
                    return new Ring(ringCenter, ringStartRadius, ringEndRadius);
            }

            return null;
        }

        private Point GetPointFromInput()
        {
            Console.WriteLine("Введите первую координату:");
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите вторую координату:");
            var y = int.Parse(Console.ReadLine());
            return new Point(x, y);
        }

        private Point[] GetPointsFromInput(int count)
        {
            var points = new Point[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите координаты {i + 1} точки:");
                points[i] = GetPointFromInput();
            }

            return points;
        }
    }
}