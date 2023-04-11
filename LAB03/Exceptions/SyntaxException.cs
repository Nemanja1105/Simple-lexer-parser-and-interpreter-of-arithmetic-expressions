using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class SyntaxException:Exception
    {
        public SyntaxException() : base("Sintaksna greska u specifikaciji!!") { }
        public SyntaxException(string? message):base(message) { }
    }
}
