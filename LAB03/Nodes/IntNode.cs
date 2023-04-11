using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    internal class IntNode:IExpressionNode
    {
        private string value;
        public IntNode(string value)
        {
            this.value = value;
        }
        public string Value { get { return this.value; } }
    }
}
