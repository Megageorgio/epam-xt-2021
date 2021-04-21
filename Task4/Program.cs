using System;
using System.Globalization;

namespace Task4
{
    class Program
    {
        private static string directoryPath = null;
        private static DateTime? rollbackDate = null;
        private static RunType? runType = null;

        private enum RunType
        {
            Watch,
            Rollback,
            List
        }

        static void Main(string[] args)
        {
            if (!TryProcessArgs(args))
            {
                return;
            }

            InputMissingArgs();

            var liteGit = new LiteGit(directoryPath);
            switch (runType)
            {
                case RunType.Watch:
                    liteGit.Watch();
                    Console.WriteLine("type 'exit' to quit program");
                    while (Console.ReadLine() != "exit") ;
                    break;
                case RunType.Rollback:
                    liteGit.Rollback(rollbackDate.Value);
                    break;
                case RunType.List:
                    Console.WriteLine(liteGit.ToString());
                    break;
            }
        }

        private static void InputMissingArgs()
        {
            if (directoryPath is null)
            {
                Console.WriteLine("Enter directory path:");
                directoryPath = Console.ReadLine();
            }

            if (runType is null)
            {
                Console.WriteLine(string.Join(Environment.NewLine,
                    new[]
                    {
                        "Select program mode:",
                        "1. Watch",
                        "2. Rollback",
                        "3. List"
                    }));
                int opt;
                while (!(int.TryParse(Console.ReadLine(), out opt) && opt is >= 1 and <= 3))
                {
                    Console.WriteLine("Try again");
                }

                runType = opt switch
                {
                    1 => RunType.Watch,
                    2 => RunType.Rollback,
                    3 => RunType.List,
                    _ => default
                };
            }

            if ((runType is RunType.Rollback) && (rollbackDate is null))
            {
                DateTime date;
                Console.WriteLine("Write date in format '21.04.2021 06:30:00':");
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy hh:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Try again");
                }

                rollbackDate = date;
            }
        }

        private static bool TryProcessArgs(string[] args)
        {
            foreach (var arg in args)
            {
                var isCorrect = true;
                if (arg.Length >= 2)
                {
                    if (arg[0] is '-')
                    {
                        if (runType is null)
                        {
                            switch (arg[1])
                            {
                                case 'w':
                                    runType = RunType.Watch;
                                    break;
                                case 'r':
                                    runType = RunType.Rollback;
                                    break;
                                case 'l':
                                    runType = RunType.List;
                                    break;
                                default:
                                    isCorrect = false;
                                    break;
                            }
                        }
                        else
                        {
                            isCorrect = false;
                        }
                    }
                    else if (runType is RunType.Rollback && DateTime.TryParseExact(arg, "dd.MM.yyyy hh:mm:ss",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                    {
                        rollbackDate = date;
                    }
                    else
                    {
                        if (directoryPath is null)
                        {
                            directoryPath = arg;
                        }
                        else
                        {
                            isCorrect = false;
                        }
                    }
                }
                else
                {
                    isCorrect = false;
                }

                if (!isCorrect)
                {
                    Console.WriteLine("Incorrect args!");
                    return false;
                }
            }

            return true;
        }
    }
}