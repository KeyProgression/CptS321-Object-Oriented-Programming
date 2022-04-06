using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeTests
{
    public class UnsupportedOperatorException : Exception
    {
        public UnsupportedOperatorException() { }
        public UnsupportedOperatorException(string message) : base(message)
        {

        }

        public UnsupportedOperatorException(string message, Exception inner) : base(message, inner) { }
    }
}
