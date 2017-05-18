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
            var term = new Term(TermClass.Add,
                new Term(new TermClass("x")),
                new Term(new TermClass("y")),
                new Integer(3));

            var applicable = new TermNormalize();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(false, applied);
            Assert.AreEqual(
                new Term(TermClass.Add,
                    new Term(new TermClass("x")),
                    new Term(new TermClass("y")),
                    new Integer(3)),
                term);
        }

        [TestMethod]
        public void AddApplication()
        {
            var term = new Term(TermClass.Add,
                new Term(new TermClass("x")),
                new Term(TermClass.Add,
                    new Term(new TermClass("z")),
                    new Integer(-2)),
                new Integer(3));

            var applicable = new TermNormalize();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(TermClass.Add,
                    new Term(new TermClass("x")),
                    new Integer(3),
                    new Term(new TermClass("z")),
                    new Integer(-2)),
                term);
        }

        [TestMethod]
        public void MulApplication()
        {
            var term = new Term(TermClass.Mul,
                new Term(TermClass.Add,
                    new Integer(2), 
                    new Term(new TermClass("a"))),
                new Term(TermClass.Mul,
                    new Term(new TermClass("z")),
                    new Integer(-5)),
                new Integer(3));

            var applicable = new TermNormalize();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(TermClass.Mul,
                    new Term(TermClass.Add,
                        new Integer(2),
                        new Term(new TermClass("a"))),
                    new Integer(3),
                    new Term(new TermClass("z")),
                    new Integer(-5)),
                term);
        }
    }
}
