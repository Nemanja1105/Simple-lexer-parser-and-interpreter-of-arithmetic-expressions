using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class Parser
    {
        private Lexer lexer;
        private Token currentlyToken;
        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            this.Next(); 
        }

        private void Next()
        {
            this.currentlyToken = lexer.Next();
        }

        public List<INode> ExpressionList()
        {
            List<INode> list = new List<INode>();
            while(this.currentlyToken.Type!="EOF")
            {
                INode temp = this.Parse();
                list.Add(temp);
                if (this.currentlyToken.Type != ";")
                    throw new SyntaxException();
                this.Next();
            }
            return list;
        }

        public INode Parse()
        {
            if (this.currentlyToken.Type == "keyword")
                return this.Keyword();
            else if (this.currentlyToken.Type == "identificator")
                return this.Identificator();
            else
                return this.Expression();
        }

        private INode Keyword()
        {
            INode result = null;
            if(this.currentlyToken.Value == "print")
            {
                Next();
                if (this.currentlyToken.Value != "(")
                    throw new SyntaxException();
                Next();
                INode temp = this.Expression();
                if (this.currentlyToken.Value != ")")
                    throw new SyntaxException();
                Next();
                result = new PrintNode(temp);
            }
            return result;
        }

        //id->\=Expression;
        private INode Identificator()
        {
            string id = this.currentlyToken.Value;
            this.Next();
            if (this.currentlyToken.Value != "=")
            {
                throw new SyntaxException();
            }    
            this.Next();
            INode left = this.Expression();
            return new IdentificatorNode(id, left);
        }

        //Expession->Term ((+|-)Term)*
        private INode Expression()
        {
            INode left = this.Term();
            while(this.currentlyToken.Type=="+"||this.currentlyToken.Type=="-")
            {
                string operation = this.currentlyToken.Value;
                Next();
                INode right = Term();
                left = new BinaryOpNode(left, right, operation);
            }
            return left;

        }

        //Term->Fact((*|/)Fact)*
        private INode Term()
        {
            INode left = Fact();
            while(this.currentlyToken.Type=="*"||this.currentlyToken.Type=="/")
            {
                string operation = this.currentlyToken.Value;
                Next();
                INode right = Fact();
                left = new BinaryOpNode(left, right, operation);
            }
            return left;
        }


        //Fact->(int)|(identificator)|(\(expresion\))
        private INode Fact()
        
        {
            INode fact = null;
            //lose
            if(this.currentlyToken.Type=="-")
            {
                string operation = this.currentlyToken.Value;
                Next();
                INode temp = this.Fact();
                return new UnaryNode(temp, operation);
            }
            else if (this.currentlyToken.Type == "int")
                fact = new IntNode(this.currentlyToken.Value);
            else if (this.currentlyToken.Type == "identificator")
                fact = new IdentificatorNode(this.currentlyToken.Value, null);
            else if (this.currentlyToken.Type == "(")
            {
                this.Next();
                INode expression = this.Expression();
                if (this.currentlyToken.Type == ")")
                    fact = expression;
                else
                    throw new SyntaxException();
            }
            else
                throw new SyntaxException();
            Next();
            return fact;
        }


    }
}
