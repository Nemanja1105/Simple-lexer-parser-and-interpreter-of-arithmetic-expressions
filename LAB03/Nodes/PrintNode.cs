using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class PrintNode:INode
    {
        private INode value;
        public PrintNode(INode value)
        {
            this.value = value;
        }

        public INode Value { get { return this.value; } }
    }
}
