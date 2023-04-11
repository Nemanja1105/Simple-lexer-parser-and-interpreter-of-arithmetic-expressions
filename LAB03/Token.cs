using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class Token
    {
        private String type;
        private String value;
        public Token(String type,String value)
        {
            this.type = type;
            this.value = value;
        }

        public String Type { get { return this.type; } set { this.type = value; } }
        public String Value { get { return this.value; } set { this.value = value; } }
    }
}
