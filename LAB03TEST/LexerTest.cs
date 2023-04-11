using NUnit.Framework;
using LAB03;

namespace LAB03TEST
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LexerTest_AdditionAndSubtractionNumbersWithWhiteSpace()
        {
            Lexer lexer = new Lexer("5    +   4    -2");
            Token t1 = lexer.Next();
            Token t2 = lexer.Next();
            Token t3 = lexer.Next();
            Token t4 = lexer.Next();
            Token t5 = lexer.Next();
            Assert.AreEqual("int", t1.Type);
            Assert.AreEqual("+", t2.Type);
            Assert.AreEqual("int", t3.Type);
            Assert.AreEqual("-", t4.Type);
            Assert.AreEqual("int", t5.Type);
        }

        [Test]
        public void LexerTest_MultiplicationAndDividingNumbersWithWhiteSpace()
        {
            Lexer lexer = new Lexer("3 *    4/ 5");
            Token t1 = lexer.Next();
            Token t2 = lexer.Next();
            Token t3 = lexer.Next();
            Token t4 = lexer.Next();
            Token t5 = lexer.Next();
            Assert.AreEqual("int", t1.Type);
            Assert.AreEqual("*", t2.Type);
            Assert.AreEqual("int", t3.Type);
            Assert.AreEqual("/", t4.Type);
            Assert.AreEqual("int", t5.Type);
        }

        [Test]
        public void LexerTest_IdentificatorInExpression()
        {
            Lexer lexer = new Lexer("3 +a *  2");
            Token t1 = lexer.Next();
            Token t2 = lexer.Next();
            Token t3 = lexer.Next();
            Token t4 = lexer.Next();
            Token t5 = lexer.Next();
            Assert.AreEqual("int", t1.Type);
            Assert.AreEqual("+", t2.Type);
            Assert.AreEqual("identificator", t3.Type);
            Assert.AreEqual("*", t4.Type);
            Assert.AreEqual("int", t5.Type);
        }

        [Test]
        public void LexerTest_PrintKeywordAndIdentificatorInArgumentOfPrint()
        {
            Lexer lexer = new Lexer("print(a+2)");
            Token t1 = lexer.Next();
            Token t2 = lexer.Next();
            Token t3 = lexer.Next();
            Token t4 = lexer.Next();
            Token t5 = lexer.Next();
            Token t6 = lexer.Next();
            Assert.AreEqual("keyword", t1.Type);
            Assert.AreEqual("print", t1.Value);
            Assert.AreEqual("(", t2.Type);
            Assert.AreEqual("identificator", t3.Type);
            Assert.AreEqual("+", t4.Type);
            Assert.AreEqual("int", t5.Type);
            Assert.AreEqual(")", t6.Type);
        }

        [Test]
        public void LexerTest_LexicalError()
        {
            Lexer lexer = new Lexer("2|3*4");
            lexer.Next();
            Assert.Throws<LexicalErrorException>(() => { lexer.Next(); });
        }

    }
}