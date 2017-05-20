using System;
using System.Collections.Generic;

namespace MathEngine.Core.StringFormat.Parse
{
    public class Parser
    {
        private readonly Tokenizer m_Tokenizer = new Tokenizer();

        public Parser()
        {
        }

        public Term ParseFromTokens(IEnumerable<Token> tokens)
        {
            // Stack of operand push targets
            var terms = new Stack<Term>();
            // Previous term to be parsed. If bracket is opened this term is pushed onto stack.
            Term lastTerm = null;
            foreach (var token in tokens)
            {            
                if (token is OpenBrackets)
                {
                    if (lastTerm == null) throw new ArgumentException();
                    terms.Push(lastTerm);
                    lastTerm = null;
                }
                else if (token is CloseBrackets)
                {
                    if (terms.Count == 0) throw new ArgumentException();
                    lastTerm = terms.Peek();
                    terms.Pop();
                }
                else
                {
                    Term newTerm;
                    if (token is Integer)
                    {
                        newTerm = ((Integer)token).IntoTerm();
                    }
                    else if (token is Decimal)
                    {
                        newTerm = ((Decimal)token).IntoTerm();
                    }
                    else if (token is Identifier)
                    {
                        newTerm = new Term(((Identifier) token).IntoTermClass());
                    }
                    else
                    {
                        throw new ArgumentException($"Token can't be of this type: {token.GetType().Name}");
                    }

                    if (terms.Count != 0)
                    {
                        terms.Peek().Operands.Add(newTerm);
                    }
                    else
                    {
                        if (lastTerm != null) throw new ArgumentException("Only one term can be root");
                    }
                    lastTerm = newTerm;
                }
            }
            return lastTerm;
        }

        public Term Parse(string input)
        {
            return ParseFromTokens(m_Tokenizer.Tokenize(input));
        }
    }
}
