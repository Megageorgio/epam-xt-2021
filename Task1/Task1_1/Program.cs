using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1_1
{
    class Program
    {
        //Task 1
        static int CalculateRectangleArea(int a, int b)
        {
            if (a <= 0 || b <= 0) throw new ArgumentException();
            return a * b;
        }

        //Task 2
        static string DrawTriangle(int n)
        {
            var s = string.Empty;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    s += '*';
                }

                s += '\n';
            }

            return s;
        }

        //Task 3
        static string DrawPyramid(int n, int offset = 0)
        {
            var s = string.Empty;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (n - i - 1) + offset; j++)
                {
                    s += ' ';
                }

                for (int j = 0; j < i * 2 + 1; j++)
                {
                    s += '*';
                }

                s += '\n';
            }

            return s;
        }

        //Task 4
        static string DrawTree(int n)
        {
            var s = string.Empty;

            for (int i = 0; i < n; i++) s += DrawPyramid(i + 1, n - i - 1);

            return s;
        }

        //Task 5
        static int SumAllMultiples(int max, params int[] numbers)
        {
            var sum = 0;

            for (int i = 0; i < max; i++)
            {
                foreach (var number in numbers)
                {
                    if (i % number == 0)
                    {
                        sum += i;
                        break;
                    }
                }
            }

            return sum;
        }

        //Task 6
        static void OpenFontEditor()
        {
            var opts = new Dictionary<string, bool> {{"Bold", false}, {"Italic", false}, {"Underline", false}};
            while (true)
            {
                var s = string.Join(", ", from opt in opts where opt.Value select opt.Key);
                Console.WriteLine("Параметры надписи: " + (s == string.Empty ? "None" : s));
                Console.WriteLine("Введите номер параметра, чтобы добавить или удалить его (или 0, чтобы выйти):");

                for (int i = 0; i < opts.Count; i++)
                    Console.WriteLine($"\t{i + 1}: {opts.Keys.ElementAt(i).ToLower()}");

                var n = int.Parse(Console.ReadLine());
                if (n == 0) return;
                var key = opts.Keys.ElementAt(n - 1);
                opts[key] = !opts[key];
            }
        }

        //Task 7
        static void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static void GenerateAndSortArray()
        {
            var rand = new Random();
            var array = new int[rand.Next(10, 20)];

            Console.WriteLine("Оригинальный массив:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-1024, 1024);
                Console.Write(array[i] + " ");
            }

            SortArray(array);

            Console.WriteLine("\nОтсортированный массив:");

            foreach (var item in array) Console.Write(item + " ");

            Console.WriteLine("\nМинимальный элемент: " + array[0] +
                              "\nМаксимальный элемент: " + array[array.Length - 1]);
        }

        //Task 8
        static void RemovePositives(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0) array[i, j, k] = 0;
                    }
                }
            }
        }

        static void Generate3DArrayAndRemovePositives()
        {
            var rand = new Random();
            var array = new int[rand.Next(5, 10), rand.Next(5, 10), rand.Next(5, 10)];

            Console.WriteLine("Оригинальный трёхмерный массив:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rand.Next(-1024, 1024);
                        Console.WriteLine($"[{i},{j},{k}]: {array[i, j, k]}");
                    }
                }
            }

            RemovePositives(array);

            Console.WriteLine("Трёхмерный массив после замены положительных чисел на нули:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.WriteLine($"[{i},{j},{k}]: {array[i, j, k]}");
                    }
                }
            }
        }

        //Task 9
        static int SumPositives(int[] array)
        {
            var sum = 0;

            foreach (var item in array)
                if (item > 0)
                    sum += item;

            return sum;
        }

        static void GenerateArrayAndSumPositives()
        {
            var rand = new Random();
            var array = new int[rand.Next(10, 20)];

            Console.WriteLine("Массив:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-1024, 1024);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("Сумма: " + SumPositives(array));
        }

        //Task 10
        static int SumEvenPositions(int[,] array)
        {
            var sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i & 1; j < array.GetLength(1); j += 2) sum += array[i, j];
            }

            return sum;
        }

        static void GenerateMatrixAndSumEvenPositions()
        {
            var rand = new Random();
            var array = new int[rand.Next(5, 10), rand.Next(5, 10)];

            Console.WriteLine("Матрица:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(-1024, 1024);
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Сумма: " + SumEvenPositions(array));
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите номер задания (или 0, чтобы выйти):");

                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Введите a и b:");
                            var s = Console.ReadLine().Split();
                            Console.WriteLine(CalculateRectangleArea(int.Parse(s[0]), int.Parse(s[1])));
                            break;
                        case 2:
                            Console.WriteLine("Введите n:");
                            Console.WriteLine(DrawTriangle(int.Parse(Console.ReadLine())));
                            break;
                        case 3:
                            Console.WriteLine("Введите n:");
                            Console.WriteLine(DrawPyramid(int.Parse(Console.ReadLine())));
                            break;
                        case 4:
                            Console.WriteLine("Введите n:");
                            Console.WriteLine(DrawTree(int.Parse(Console.ReadLine())));
                            break;
                        case 5:
                            Console.WriteLine(SumAllMultiples(1000, 3, 5));
                            break;
                        case 6:
                            OpenFontEditor();
                            break;
                        case 7:
                            GenerateAndSortArray();
                            break;
                        case 8:
                            Generate3DArrayAndRemovePositives();
                            break;
                        case 9:
                            GenerateArrayAndSumPositives();
                            break;
                        case 10:
                            GenerateMatrixAndSumEvenPositions();
                            break;
                        default:
                            return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Произошла ошибка: " + e.Message);
                }
            }
        }
    }
}