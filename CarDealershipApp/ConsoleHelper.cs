using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp
{
    public static class ConsoleHelper
    {
        public static void WriteLineColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLineSuccess(string message)
        {
            WriteLineColored(message, ConsoleColor.Green);
        }
        public static void WriteLineError(string message)
        {
            WriteLineColored(message, ConsoleColor.Red);
        }
    }
}