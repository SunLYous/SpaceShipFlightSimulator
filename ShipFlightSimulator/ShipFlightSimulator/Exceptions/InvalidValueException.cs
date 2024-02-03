using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
public class InvalidValueException : Exception
{
    public InvalidValueException()
        : base("Invalid value")
    {
    }

    public InvalidValueException(string message)
        : base(message)
    {
    }

    public InvalidValueException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
