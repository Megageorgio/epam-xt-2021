using System;
using System.Linq;

namespace WeakestLink
{
    record Person(int Id);

    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = ReadInteger("Введите N:");
            var indexToRemove = ReadInteger("Введите, какой по счету человек будет вычеркнут каждый раунд:") - 1;
            var peopleList = Enumerable.Range(1, peopleCount).Select(id => new Person(id)).ToList();
            var round = 1;

            var currentIndex = indexToRemove;
            Console.WriteLine("Изначальный круг: " + string.Join(", ", peopleList.Select(person => person.Id)));
            while (peopleList.Count > indexToRemove)
            {
                peopleList.RemoveAt(currentIndex);
                currentIndex += indexToRemove;
                if (currentIndex >= peopleList.Count)
                {
                    currentIndex -= peopleList.Count;
                }

                Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {peopleList.Count}");
                Console.WriteLine("Текущий круг: " + string.Join(", ", peopleList.Select(person => person.Id)));
                round++;
            }

            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
        }

        static int ReadInteger(string message)
        {
            int result;
            do
            {
                Console.WriteLine(message);
            } while (!int.TryParse(Console.ReadLine(), out result));

            return result;
        }
    }
}