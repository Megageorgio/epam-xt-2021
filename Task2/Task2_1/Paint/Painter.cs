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
            while (true)
            {
                var opt = 4;
                if (username != null)
                {
                    Console.WriteLine(username + ", выберите действие:" + Environment.NewLine +
                                      "1. Добавить фигуру" + Environment.NewLine +
                                      "2. Вывести фигуры" + Environment.NewLine +
                                      "3. Очистить холст" + Environment.NewLine +
                                      "4. Сменить пользователя" + Environment.NewLine +
                                      "5. Выход");
                    opt = int.Parse(Console.ReadLine());
                }

                switch (opt)
                {
                    case 1:
                        Figures[username].Add(GetFigureFromInput());
                        Console.WriteLine("Фигура добавлена");
                        break;
                    case 2:
                        Console.WriteLine("Список фигур:");
                        Console.WriteLine(string.Join(Environment.NewLine + new string('-', 20) + Environment.NewLine,
                            Figures[username]));
                        break;
                    case 3:
                        Figures[username].Clear();
                        Console.WriteLine("Все фигуры удалены!");
                        break;
                    case 4:
                        Console.WriteLine("Введите имя:");
                        username = Console.ReadLine();
                        Console.WriteLine("Имя изменено!");
                        if (!Figures.ContainsKey(username))
                        {
                            Figures.Add(username, new List<IFigure>());
                        }

                        break;
                    case 5:
                        return;
                }
            }
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
            Console.WriteLine(username + ", выберите нужную фигуру:" + Environment.NewLine +
                              string.Join(Environment.NewLine, figureNames.Select((name, i) => $"{i + 1}. {name}")));
            var opt = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите параметры фигуры {figureNames[opt - 1]}:");
            IFigure figure;
            switch (opt)
            {
                case 1:
                    var linePoints = GetPointsFromInput(2);
                    figure = new Line(linePoints[0], linePoints[1]);
                    break;
                case 2:
                    Console.WriteLine("Введите количество точек:");
                    var polygonPointsCount = int.Parse(Console.ReadLine());
                    var polygonPoints = GetPointsFromInput(polygonPointsCount);
                    figure = new Polygon(polygonPoints);
                    break;
                case 3:
                    var tetragonPoints = GetPointsFromInput(4);
                    figure = new Tetragon(tetragonPoints[0], tetragonPoints[1], tetragonPoints[2], tetragonPoints[3]);
                    break;
                case 4:
                    var rectanglePoints = GetPointsFromInput(4);
                    figure = new Rectangle(rectanglePoints[0], rectanglePoints[1], rectanglePoints[2],
                        rectanglePoints[3]);
                    break;
                case 5:
                    var squarePoints = GetPointsFromInput(4);
                    figure = new Square(squarePoints[0], squarePoints[1], squarePoints[2], squarePoints[3]);
                    break;
                case 6:
                    var trianglePoints = GetPointsFromInput(3);
                    figure = new Triangle(trianglePoints[0], trianglePoints[1], trianglePoints[2]);
                    break;
                case 7:
                    var circleCenter = GetPointFromInput();
                    Console.WriteLine("Введите радиус:");
                    var circleRadius = int.Parse(Console.ReadLine());
                    figure = new Circle(circleCenter, circleRadius);
                    break;
                case 8:
                    var diskCenter = GetPointFromInput();
                    Console.WriteLine("Введите радиус:");
                    var diskRadius = int.Parse(Console.ReadLine());
                    figure = new Disk(diskCenter, diskRadius);
                    break;
                case 9:
                    var ringCenter = GetPointFromInput();
                    Console.WriteLine("Введите радиус первой окружности:");
                    var ringStartRadius = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите радиус второй окружности:");
                    var ringEndRadius = int.Parse(Console.ReadLine());
                    figure = new Ring(ringCenter, ringStartRadius, ringEndRadius);
                    break;
                default:
                    return GetFigureFromInput();
            }

            Console.WriteLine($"Фигура {figureNames[opt - 1]} создана!");
            return figure;
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