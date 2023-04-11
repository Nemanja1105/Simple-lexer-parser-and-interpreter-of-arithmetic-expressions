using NUnit.Framework;
using LAB03;
using System.IO;
using System;

namespace LAB03TEST
{
    public class InterpreterTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void InterpreterTest_ExpressionEvaluation()
        {
            Lexer lexer = new Lexer("(3+2)*2-10/2;");
            Parser parser = new Parser(lexer);
            var list = parser.ExpressionList();
            Interpreter interpreter = new Interpreter(list);
            Assert.AreEqual(5, interpreter.EvaluateExpression(list[0]));
        }

        [Test]
        public void InterpreterTest_PrintStatementEvaluation()
        {
            Lexer lexer = new Lexer("print((3+2)*2-10/2);");
            Parser parser = new Parser(lexer);
            var list = parser.ExpressionList();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Interpreter interpreter = new Interpreter(list);
            interpreter.InterpretPrint((PrintNode)list[0]);
            Assert.AreEqual("5", stringWriter.ToString().Replace("\n","").Replace("\r",""));
        }

        [Test]
        public void InterpreterTest_VariableAssignmentValue()
        {
            Lexer lexer = new Lexer("a=3+4;" +
                "print(2*a+6);");
            Parser parser = new Parser(lexer);
            var list = parser.ExpressionList();
            Interpreter interpreter = new Interpreter(list);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            interpreter.Interpret();
            Assert.AreEqual("20", stringWriter.ToString().Replace("\n", "").Replace("\r", ""));
        }

        [Test]
        public void InterpreterTest_IdentificatorNotDeclared()
        {
            Lexer lexer = new Lexer("3+a*2;");
            Parser parser = new Parser(lexer);
            var list = parser.ExpressionList();
            Interpreter interpreter = new Interpreter(list);
            Assert.Throws<Exception>(() => { interpreter.EvaluateExpression(list[0]); });
        }

        [Test]
        public void InterpreterTest_SemanticErrorCheck()
        {
            Lexer lexer = new Lexer("3+4/0;");
            Parser parser = new Parser(lexer);
            var list = parser.ExpressionList();
            Interpreter interpreter = new Interpreter(list);
            Assert.Throws<DivideByZeroException>(() => { interpreter.EvaluateExpression(list[0]); });

        }


    }
}
