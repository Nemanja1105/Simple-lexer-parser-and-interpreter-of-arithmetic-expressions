using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03
{
    public class Lexer
    {
        private string source;
        private int currentlyPosition = 0;
        public Lexer(string source)
        {
            this.source = source;
        }

        public Token Next()
        {
            if (this.currentlyPosition >= source.Length)
                return new Token("EOF", "EOF");

            while (this.currentlyPosition < this.source.Length && char.IsWhiteSpace(this.source[this.currentlyPosition]))
                this.currentlyPosition++;

            if (char.IsDigit(this.source[this.currentlyPosition]))
            {
                StringBuilder builder = new StringBuilder("");
                while (this.currentlyPosition < this.source.Length && char.IsDigit(this.source[this.currentlyPosition]))
                    builder.Append(this.source[this.currentlyPosition++]);
                return new Token("int", builder.ToString());
            }

            if(char.IsLetter(this.source[this.currentlyPosition]))
            {
                StringBuilder builder = new StringBuilder();
                while (this.currentlyPosition < this.source.Length && char.IsLetter(this.source[this.currentlyPosition]))
                    builder.Append(this.source[this.currentlyPosition++]);
                if (builder.ToString() == "print")
                    return new Token("keyword", builder.ToString());
                else
                    return new Token("identificator", builder.ToString());
            }

   
            switch(this.source[this.currentlyPosition])
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '(':
                case ')':
                case ';':
                case '=':
                    string temp= this.source[this.currentlyPosition].ToString();
                    this.currentlyPosition++;
                    return new Token(temp, temp);
            }

           /* if (this.source[this.currentlyPosition] == '-')
            {
                this.currentlyPosition++;
                if (char.IsDigit(this.source[this.currentlyPosition]))
                {
                    StringBuilder builder = new StringBuilder("-");
                    while (this.currentlyPosition < this.source.Length && char.IsDigit(this.source[this.currentlyPosition]))
                        builder.Append(this.source[this.currentlyPosition++]);
                    return new Token("int", builder.ToString());
                }
            }*/
            throw new LexicalErrorException();



        }

    }
}
