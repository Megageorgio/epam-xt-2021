using System;
using Megageorgio.MegaStringLib;

namespace MegaStringUse
{
    class Program
    {
        static void Main(string[] args)
        {
            MegaString s = "FFeewwWWfffg333 EWWErfgg   efwBVBbBfdddd";
            foreach (var c in s)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine(s.RemoveDoubles());
        }
    }
}