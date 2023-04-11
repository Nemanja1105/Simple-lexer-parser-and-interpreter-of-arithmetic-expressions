using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class Interpreter
    {
        private List<INode> expressions;
        private Dictionary<String, int> variables = new Dictionary<string, int>();
        public Interpreter(List<INode> expressions)
        {
            this.expressions = expressions;
        }

        public void Interpret()
        {
            foreach(var el in this.expressions)
            {
               // if (el is IExpressionNode)
                   // Console.WriteLine(EvaluateExpression(el));
                if (el is IdentificatorNode)
                    this.InterpretIdentificator((IdentificatorNode)el);
                else if (el is PrintNode)
                    this.InterpretPrint((PrintNode)el);
            }

        }

        

        public int EvaluateExpression(INode head)
        {
            if (head.GetType() == typeof(BinaryOpNode))
                return this.EvaluateBinaryNode((BinaryOpNode)head);
            else if (head.GetType() == typeof(IdentificatorNode))
                return this.EvaluateIdentifierInExpression((IdentificatorNode)head);
            else if (head.GetType() == typeof(UnaryNode))
                return this.EvaluateUnaryNode((UnaryNode)head);

            else //if (head.GetType() == typeof(IntNode))
                return this.EvaluateIntNode((IntNode)head);
        }

        public void InterpretPrint(PrintNode node)
        {
            Console.WriteLine(this.EvaluateExpression(node.Value));
        }

        public void InterpretIdentificator(IdentificatorNode node)
        {
            int result = this.EvaluateExpression(node.Value);
            this.variables.Add(node.Id, result);
        }

        private int EvaluateUnaryNode(UnaryNode node)
        {
            int result = this.EvaluateExpression(node.Value);
            if (node.Operation == "-")
                result = -result;
            return result;
        }

        private int EvaluateIdentifierInExpression(IdentificatorNode node)
        {
            int result = 0;
            try
            {
                result=this.variables[node.Id];
            }
            catch(Exception e)
            {
                throw new Exception("Identifikator nije definisan!!");
            }
            return result;
        }

        private int EvaluateIntNode(IntNode node)
        {
            int result = Int32.Parse(node.Value);
            return result;
        }

        private int EvaluateBinaryNode(BinaryOpNode head)
        {
            int left = this.EvaluateExpression(head.Left);
            int right = this.EvaluateExpression(head.Right);
            int result = 0;
            switch(head.Operation)
            {
                case "+":
                    result= left + right;
                    break;
                case "-":
                    result= left - right;
                    break;
                case "*":
                    result=left * right;
                    break;
                case "/":
                    if (right == 0)
                        throw new DivideByZeroException("Dijeljenje sa nulom");
                    result= left / right;
                    break;
            }
            return result;
        }

    }
}
