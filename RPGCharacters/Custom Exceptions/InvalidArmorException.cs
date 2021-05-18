using System;

namespace RPGCharacters.Custom_Exceptions
{
    /// <summary>
    /// Invalid armor exception.
    /// </summary>
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException()
        {
        }

        public InvalidArmorException(string message) : base(message)
        {
        }

        public override string Message => "Invalid armor exception";
    }
}
