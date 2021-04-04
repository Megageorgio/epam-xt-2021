using System;

namespace SuperArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] {1, 2, 2, 3, 3, 3, 4, 4, 5};
            DisplayArrayInfo(array);
            array.ForEach(item => item * 2);
            DisplayArrayInfo(array);
        }

        static void DisplayArrayInfo(int[] array)
        {
            Console.WriteLine("Array: " + string.Join(", ", array));
            Console.WriteLine("Sum: " + array.SumAll());
            Console.WriteLine("Average: " + array.AverageValue());
            Console.WriteLine("Most Frequent: " + array.GetMostFrequentElement());
        }
    }
}