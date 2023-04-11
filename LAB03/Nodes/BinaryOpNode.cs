using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class BinaryOpNode : IExpressionNode
    {
        private INode left;
        private INode right;
        private string operation;
        public BinaryOpNode(INode left, INode right, string operation)
        {
            this.left = left;
            this.right = right;
            this.operation = operation;
        }

        public INode Left { get { return this.left; } }
        public INode Right { get { return this.right; } }

        public string Operation { get { return this.operation; } }

            
    }
}
