using System;
using System.Linq;
using MathEngine.Core.StringFormat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decimal = MathEngine.Core.StringFormat.Decimal;

namespace Tests.Core.StringFormat
{
    [TestClass]
    public class TokenizerTests
    {
        [TestMethod]
        public void Tokenize()
        {
            string input = "Add[2, 3, x, Mul[3.5, y[3, x]], 55]";

            var tokenizer = new Tokenizer();

            var output = tokenizer.Tokenize(input).ToArray();

            Assert.IsTrue(
                new Token[]
                {
                    new Identifier("Add"),
                    new OpenBrackets(),
                    new Integer(2),
                    new Integer(3),
                    new Identifier("x"),
                    new Identifier("Mul"),
                    new OpenBrackets(),
                    new Decimal(3.5m),
                    new Identifier("y"),
                    new OpenBrackets(),
                    new Integer(3),
                    new Identifier("x"),
                    new CloseBrackets(),
                    new CloseBrackets(),
                    new Integer(55),
                    new CloseBrackets()
                }.SequenceEqual(output));
        }
    }
}
