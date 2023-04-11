using NUnit.Framework;
using LAB03;

namespace LAB03TEST
{
    public class ParserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParserTest_ParseVariableValueAssignment()
        {
            Lexer l = new Lexer("a=2+3;");
            Parser parser = new Parser(l);
            INode node = parser.Parse();
            Assert.AreEqual(typeof(IdentificatorNode), node.GetType());
        }

        [Test]
        public void ParserTest_ParsePrintStatement()
        {
            Lexer l = new Lexer("print(2+3);");
            Parser parser = new Parser(l);
            INode node = parser.Parse();
            Assert.AreEqual(typeof(PrintNode), node.GetType());
        }

        [Test]
        public void ParserTest_ParseExpression()
        {
            Lexer l = new Lexer("3+4+3*4;");
            Parser parser = new Parser(l);
            INode node = parser.Parse();
            Assert.AreEqual(typeof(BinaryOpNode), node.GetType());
        }

        [Test]
        public void ParserTest_SyntaxError()
        {
            Lexer l = new Lexer("2++a;");
            Parser parser = new Parser(l);
            Assert.Throws<SyntaxException>(() => { parser.Parse(); });
        }

        [Test]
        public void ParserTest_ExpressionNotEndWithSeparator()
        {
            Lexer l = new Lexer("2++a;");
            Parser parser = new Parser(l);
            Assert.Throws<SyntaxException>(() => { parser.Parse(); });
        }

    }
}
