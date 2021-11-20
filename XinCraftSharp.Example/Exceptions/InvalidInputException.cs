using System;

namespace XinCraftSharp.Example.Exceptions
{
    public class InvalidInputException : Exception
    {
            public InvalidInputException()
            : base("The specified input was invalid")
            {
            }
        
            public InvalidInputException(string message)
                : base(message)
            {
            }
    }
}