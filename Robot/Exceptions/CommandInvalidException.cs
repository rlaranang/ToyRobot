using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Exceptions
{
    public class CommandInvalidException : Exception
    {
        public CommandInvalidException(string message) : base(message)
        { 

        }
    }
}
