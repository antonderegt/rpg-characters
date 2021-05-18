using System;

namespace RPGCharacters.Custom_Exceptions
{
    /// <summary>
    /// Invalid weapon exception.
    /// </summary>
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {
        }

        public InvalidWeaponException(string message) : base(message)
        {
        }

        public override string Message => "Invalid weapon exception";
    }
}
