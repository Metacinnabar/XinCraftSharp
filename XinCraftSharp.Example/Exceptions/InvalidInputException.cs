using System;

namespace XinCraftSharp.Example.Exceptions
{
    /// <summary>
    /// Exception thrown when an invalid input was provided.
    /// </summary>
    public class InvalidInputException : Exception
    {
        /// <summary>
        /// Exception with the message of "The specified input was invalid".
        /// </summary>
        public InvalidInputException() : base("The specified input was invalid.")
        {
        }
        
        /// <summary>
        /// Exception with a provided message.
        /// </summary>
        /// <param name="message">Error message when the exception is thrown</param>
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}