using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseApp.Helpers
{
    public static class Helper
    {

        public static void PrintConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static string ReadLetterOrDigitUpdateString(string oldValue, string errorMessage)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return oldValue;
                }

                if (input.All(c => char.IsLetterOrDigit(c)))
                {
                    return input;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ResetColor();
            }
        }

        public static string ReadValidatedUpdateString(string oldValue, string errorMessage)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return oldValue;
                }

                if (input.Length >= 2)
                {
                    return input;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ResetColor();
            }
        }

        public static string ReadValidatedString(string errorMessage)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                PrintConsole(ConsoleColor.Red, errorMessage);
            }
        }
        public static int ReadValidatedInt(string errorMessage)
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                PrintConsole(ConsoleColor.Red, errorMessage);
            }
            return result;
        }
    }
}



