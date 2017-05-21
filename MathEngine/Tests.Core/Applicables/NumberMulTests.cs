using System;
using MathEngine.Core;
using MathEngine.Core.Applicables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decimal = MathEngine.Core.Decimal;

namespace Tests.Core.Applicables
{
    [TestClass]
    public class NumberMulTests
    {
        [TestMethod]
        public void DoesntApplyOnNonMulTerms()
        {
            var term = new Term(TermClass.Add,
                new Term("x"),
                new Integer(-5),
                new Term("y"),
                new Integer(3)
            );

            var applicable = new NumberMul();

            bool applied = applicable.Apply(term);

            Assert.IsFalse(applied);
            Assert.AreEqual(
                new Term(TermClass.Add,
                    new Term("x"),
                    new Term("y"),
                    new Integer(-5),
                    new Integer(3)
                ),
                term);
        }

        [TestMethod]
        public void NoApplication()
        {
            var term = new Term(TermClass.Mul,
                new Term("x"),
                new Term("y"),
                new Integer(3)
            );

            var applicable = new NumberMul();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(false, applied);
            Assert.AreEqual(
                new Term(TermClass.Mul,
                    new Term("x"),
                    new Term("y"),
                    new Integer(3)
                ),
                term);
        }

        [TestMethod]
        public void IntegerMultiplication()
        {
            var term = new Term(TermClass.Mul,
                new Term("x"),
                new Integer(-5),
                new Term("y"),
                new Integer(3)
            );

            var applicable = new NumberMul();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(TermClass.Mul,
                    new Term("x"),
                    new Term("y"),
                    new Integer(-15)
                ),
                term);
        }

        [TestMethod]
        public void RemoveIntegerOne()
        {
            var term = new Term(TermClass.Mul,
                new Term("x"),
                new Integer(1),
                new Term("y")
            );

            var applicable = new NumberMul();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(TermClass.Mul,
                    new Term("x"),
                    new Term("y")
                ),
                term);
        }

        [TestMethod]
        public void DecimalMultiplication()
        {
            var term = new Term(TermClass.Mul,
                new Term("x"),
                new Decimal(-5.3m),
                new Term("y"),
                new Decimal(2.6m)
            );

            var applicable = new NumberMul();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(TermClass.Mul,
                    new Term("x"),
                    new Term("y"),
                    new Decimal(-13.78m)
                ),
                term);
        }

        [TestMethod]
        public void DecimalToOne()
        {
            var term = new Term(TermClass.Mul,
                new Term("x"),
                new Decimal(-4m),
                new Term("y"),
                new Decimal(-0.5m),
                new Decimal(0.5m)
            );

            var applicable = new NumberMul();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(TermClass.Mul,
                    new Term("x"),
                    new Term("y")
                ),
                term);
        }

        [TestMethod]
        public void MixedMultiplication()
        {
            var term = new Term(TermClass.Mul,
                new Term("x"),
                new Decimal(-5.3m),
                new Integer(5),
                new Term("y"),
                new Decimal(2.6m),
                new Integer(3)
            );

            var applicable = new NumberMul();

            bool applied = applicable.Apply(term);

            Assert.AreEqual(true, applied);
            Assert.AreEqual(
                new Term(TermClass.Mul,
                    new Term("x"),
                    new Term("y"),
                    new Decimal(-206.7m)
                ),
                term);
        }
    }
}