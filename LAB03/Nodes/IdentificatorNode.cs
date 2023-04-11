using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class IdentificatorNode:INode
    {
        private string id;
        private INode value;
        public IdentificatorNode(String id,INode value)
        {
            this.id = id;
            this.value = value;
        }

        public String Id { get { return this.id; } }
        public INode Value { get { return this.value; } }
    }
}
