using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class LexicalErrorException:Exception
    {
        public LexicalErrorException() : base("Leksicka greska u specifikaciji")
        {
        }
        
        public LexicalErrorException(string? message) : base(message)
        {
        }
    }
}
