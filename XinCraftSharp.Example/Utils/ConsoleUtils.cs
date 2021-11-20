using System;
using XinCraftSharp.Example.Exceptions;

namespace XinCraftSharp.Example.Utils
{
    /// <summary>
    /// Utility class for console related helper methods.
    /// </summary>
    public static class ConsoleUtils
    {
        /// <summary>
        /// Helper util to ease requesting inputs from console.
        /// </summary>
        /// <param name="request">Request message sent in console.</param>
        /// <param name="errorMsg">Error message thrown.
        /// Defaults to "The specified input was invalid".</param>
        /// <returns>Returns the inputted value.</returns>
        /// <exception cref="InvalidInputException">Throws if the input was null or empty.</exception>
        public static string RequestInput(string request, string errorMsg = "The specified input was invalid")
        {
            // Write the input request.
            Console.WriteLine(request);
            // Read the input and assign the value to a variable.
            string? input = Console.ReadLine();

            // Check if the input is empty and throws an error if so.
            if (string.IsNullOrEmpty(input)) 
                throw new InvalidInputException(errorMsg);
            
            // Returns the provided input
            return input;
        }
    }
}