namespace LAB03
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input = null;
            input = File.ReadAllText(args[0]).Replace("\n", "").Replace("\r", "");
            Lexer lexer = new Lexer(input);
            Parser parser = new Parser(lexer);
            var list = parser.ExpressionList();
            Interpreter interpreter = new Interpreter(list);
            interpreter.Interpret();
            



        }
    }
}
