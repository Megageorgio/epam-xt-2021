using System;
using System.Collections.Generic;
using DynamicArrayLib;
using Megageorgio.DynamicArrayLib;

namespace DynamicArrayUse
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            TestCycled();
        }

        static void Test()
        {
            var array = new DynamicArray<int> {1, 2, 3, 4, 5};
            PrintArrayState(array);
            array.Add(6);
            PrintArrayState(array);
            array.AddRange(new[] {8, 9, 10});
            PrintArrayState(array);
            array.Insert(7, 6);
            PrintArrayState(array);
            array.Capacity = 30;
            PrintArrayState(array);
            array.Capacity = 5;
            PrintArrayState(array);
            array.Remove(3);
            PrintArrayState(array);
        }

        static void TestCycled()
        {
            var array = new CycledDynamicArray<string>(3);
            array.AddRange(new List<string> {"Tomato", "Potato", "Cucumber", "Avocado", "Melon"});
            PrintArrayState(array);
            int counter = 12;
            foreach (var item in array)
            {
                Console.WriteLine(item);
                if (--counter == 0)
                {
                    break;
                }
            }
        }

        static void PrintArrayState<T>(DynamicArray<T> array)
        {
            Console.WriteLine("array: " + string.Join(", ", array)); // внутри использует foreach
            Console.WriteLine("capacity: " + array.Capacity);
            Console.WriteLine("length: " + array.Length);
        }

        static void PrintArrayState<T>(CycledDynamicArray<T> array)
        {
            Console.WriteLine("array: " + string.Join(", ", array.ToArray()));
            Console.WriteLine("capacity: " + array.Capacity);
            Console.WriteLine("length: " + array.Length);
        }
    }
}