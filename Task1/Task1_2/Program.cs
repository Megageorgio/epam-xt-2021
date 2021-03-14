using System;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace Task1_2
{
    class Program
    {
        //Task 1 не округляем
        static double GetAverageWordLength(string s) =>
            s.Where(c => !char.IsPunctuation(c))
                .Aggregate(new StringBuilder(),
                    (current, next) => current.Append(next), sb => sb.ToString())
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.Length)
                .Average();


        //Task 2
        static string DoubleLetters(string s1, string s2) =>
            string.Concat(s1.Select(c => c.ToString() + (s2.Contains(c) ? c : "")));

        //Task 3 (поскольку между словами все равно есть пробелы и их не надо выводить, я не делаю сплит по символам)
        static int CountLowercaseFirstLetters(string s) =>
            s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Count(s => char.IsLower(s[0]));

        //Task 4
        static string Capitalize(string s)
        {
            var result = new StringBuilder();
            var nextUpper = true;

            foreach (var c in s)
            {
                if (nextUpper && char.IsLetter(c))
                {
                    result.Append(char.ToUpper(c));
                    nextUpper = false;
                    continue;
                }

                if (c == '.' || c == '?' || c == '!')
                {
                    nextUpper = true;
                }

                char[] a;
                result.Append(c);
            }

            return result.ToString();
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
                            Console.WriteLine("Введите строку:");
                            Console.WriteLine(GetAverageWordLength(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Введите строку, в которой дублировать буквы:");
                            var s1 = Console.ReadLine();
                            Console.WriteLine("Введите строку, из которой брать буквы:");
                            var s2 = Console.ReadLine();
                            Console.WriteLine(DoubleLetters(s1, s2));
                            break;
                        case 3:
                            Console.WriteLine("Введите строку:");
                            Console.WriteLine(CountLowercaseFirstLetters(Console.ReadLine()));
                            break;
                        case 4:
                            Console.WriteLine("Введите строку:");
                            Console.WriteLine(Capitalize(Console.ReadLine()));
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