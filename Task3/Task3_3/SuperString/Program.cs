using System;

namespace SuperString
{
    class Program
    {
        static void Main(string[] args)
        {
            TestString("Саратов");
            TestString("Epam");
            TestString("88005553535");
            TestString("shadow1337");
            TestString("help me");
        }

        static void TestString(string str) =>
            Console.WriteLine(str + ": " + str.GetStringType().ToString());
    }
}