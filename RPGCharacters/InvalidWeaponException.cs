using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters
{
    class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {
        }

        public InvalidWeaponException(string message)
            : base(message)
        {
        }

        public InvalidWeaponException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
