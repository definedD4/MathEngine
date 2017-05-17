using System;
using MathEngine.Core;
using MathEngine.Core.Applicables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core.Applicables
{
    [TestClass]
    public class TermNormalizeTests
    {
        [TestMethod]
        public void NoApplication()
        {
            var term = new Term(Identifier.Add,
                new Term(new Identifier("x")),
                new Term(new Identifier("y")),
                new Integer(3));

            var applicable = new TermNormalize();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(false, applied);
            Assert.AreEqual(
                new Term(Identifier.Add,
                    new Term(new Identifier("x")),
                    new Term(new Identifier("y")),
                    new Integer(3)),
                term);
        }

        [TestMethod]
        public void AddApplication()
        {
            var term = new Term(Identifier.Add,
                new Term(new Identifier("x")),
                new Term(Identifier.Add,
                    new Term(new Identifier("z")),
                    new Integer(-2)),
                new Integer(3));

            var applicable = new TermNormalize();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(Identifier.Add,
                    new Term(new Identifier("x")),
                    new Integer(3),
                    new Term(new Identifier("z")),
                    new Integer(-2)),
                term);
        }

        [TestMethod]
        public void MulApplication()
        {
            var term = new Term(Identifier.Mul,
                new Term(Identifier.Add,
                    new Integer(2), 
                    new Term(new Identifier("a"))),
                new Term(Identifier.Mul,
                    new Term(new Identifier("z")),
                    new Integer(-5)),
                new Integer(3));

            var applicable = new TermNormalize();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(Identifier.Mul,
                    new Term(Identifier.Add,
                        new Integer(2),
                        new Term(new Identifier("a"))),
                    new Integer(3),
                    new Term(new Identifier("z")),
                    new Integer(-5)),
                term);
        }
    }
}
