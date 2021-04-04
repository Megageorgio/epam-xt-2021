using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperArray
{
    public static class ArrayExtension
    {
        public static void ForEach<T>(this T[] array, Func<T, T> func)
        {
            if (func is not null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = func(array[i]);
                }
            }
        }

        public static T GetMostFrequentElement<T>(this T[] array) =>
            array.GroupBy(x => x)
                .OrderBy(item => item.Count())
                .Last()
                .Key;

        public static int SumAll(this int[] array) => array.Sum();

        public static double AverageValue(this int[] array) => array.Average();
    }
}