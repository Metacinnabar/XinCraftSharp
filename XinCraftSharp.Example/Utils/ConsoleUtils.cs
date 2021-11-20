using System;
using XinCraftSharp.Example.Exceptions;

namespace XinCraftSharp.Example.Utils
{
    public static class ConsoleUtils
    {
        public static string RequestInput(string request, string errorMsg = "")
        {
            Console.WriteLine(request);
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
                return input;

            throw string.IsNullOrEmpty(errorMsg) ? new InvalidInputException() : new InvalidInputException(errorMsg);
        }
    }
}