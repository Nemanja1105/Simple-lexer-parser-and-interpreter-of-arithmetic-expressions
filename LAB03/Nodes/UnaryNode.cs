using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class UnaryNode:IExpressionNode
    {
        private INode value;
        private string operation;
        public UnaryNode(INode value,string operation)
        {
            this.value = value;
            this.operation = operation;
        }
        
        public INode Value { get { return this.value; } }
        public string Operation { get { return this.operation; } }
    }
}
