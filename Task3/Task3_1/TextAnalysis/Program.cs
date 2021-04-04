using System;

namespace TextAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доброго времени суток, уважаемый профессионал журналистики!" + Environment.NewLine +
                              "Вас приветствует приятный и понятный интерфейс программы \"Анализатор текста\"" + Environment.NewLine +
                              "Для продолжения нажмите любую клавишу.");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.WriteLine("Пожалуйста, введите текст для анализа:");
                var analyzer = new TextAnalyzer();
                var text = Console.ReadLine();
                Console.WriteLine("Статистика использования слов:" + Environment.NewLine + analyzer.GetStats(text) +
                                  Environment.NewLine +
                                  "Для выхода из программы нажмите Escape." + Environment.NewLine +
                                  "Для повторного ввода текста и его дальнейшего анализа нажмите любую другую клавишу.");
            }
        }
    }
}