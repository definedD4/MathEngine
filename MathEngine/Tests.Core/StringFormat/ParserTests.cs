using MathEngine.Core;
using MathEngine.Core.StringFormat.Parse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decimal = MathEngine.Core.Decimal;
using Integer = MathEngine.Core.Integer;

namespace Tests.Core.StringFormat.Parse
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Parse()
        {
            string input = "Add[2, 3, x, Mul[3.5, y[3, x]], 55]";

            var parser = new Parser();

            var output = parser.Parse(input);

            Assert.AreEqual(
                new Term(TermClass.Add,
                    new Integer(2),
                    new Integer(3),
                    new Term("x"),
                    new Term(TermClass.Mul,
                        new Decimal(3.5m),
                        new Term("y",
                            new Integer(3),
                            new Term("x")
                        )
                    ),
                    new Integer(55)
                ), output);
        }
    }
}
