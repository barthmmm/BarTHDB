using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTHDB.Exceptions
{
    internal class InvalidPeriodException : Exception
    {
        public InvalidPeriodException(string? message) : base(message)
        {
        }
    }
}
