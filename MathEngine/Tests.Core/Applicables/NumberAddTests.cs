using System;
using MathEngine.Core;
using MathEngine.Core.Applicables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decimal = MathEngine.Core.Decimal;

namespace Tests.Core.Applicables
{
    [TestClass]
    public class NumberAddTests
    {
        [TestClass]
        public class TermNormalizeTests
        {
            [TestMethod]
            public void DoesntApplyOnNonAddTerms()
            {
                var term = new Term(TermClass.Mul,
                    new Term("x"),
                    new Integer(-5),
                    new Term("y"),
                    new Integer(3)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.IsFalse(applied);
                Assert.AreEqual(
                    new Term(TermClass.Mul,
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
                var term = new Term(TermClass.Add,
                    new Term("x"),
                    new Term("y"),
                    new Integer(3)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.AreEqual(false, applied);
                Assert.AreEqual(
                    new Term(TermClass.Add,
                        new Term("x"),
                        new Term("y"),
                        new Integer(3)
                    ),
                    term);
            }

            [TestMethod]
            public void IntegerAddition()
            {
                var term = new Term(TermClass.Add,
                    new Term("x"),
                    new Integer(-5),
                    new Term("y"),
                    new Integer(3)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.AreEqual(true, applied);
                Assert.AreEqual(
                    new Term(TermClass.Add,
                        new Term("x"),
                        new Term("y"),
                        new Integer(-2)
                    ),
                    term);
            }

            [TestMethod]
            public void IntegerToZero()
            {
                var term = new Term(TermClass.Add,
                    new Term("x"),
                    new Integer(-5),
                    new Term("y"),
                    new Integer(5)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.AreEqual(true, applied);
                Assert.AreEqual(
                    new Term(TermClass.Add,
                        new Term("x"),
                        new Term("y")
                    ),
                    term);
            }

            [TestMethod]
            public void DecimalAddition()
            {
                var term = new Term(TermClass.Add,
                    new Term("x"),
                    new Decimal(-5.3m),
                    new Term("y"),
                    new Decimal(2.6m)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.AreEqual(true, applied);
                Assert.AreEqual(
                    new Term(TermClass.Add,
                        new Term("x"),
                        new Term("y"),
                        new Decimal(-2.7m)
                    ),
                    term);
            }

            [TestMethod]
            public void DecimalToZero()
            {
                var term = new Term(TermClass.Add,
                    new Term("x"),
                    new Decimal(-5.3m),
                    new Term("y"),
                    new Decimal(2.6m),
                    new Decimal(2.7m)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.AreEqual(true, applied);
                Assert.AreEqual(
                    new Term(TermClass.Add,
                        new Term("x"),
                        new Term("y")
                    ),
                    term);
            }

            [TestMethod]
            public void MixedAddition()
            {
                var term = new Term(TermClass.Add,
                    new Term("x"),
                    new Decimal(-5.3m),
                    new Integer(5),
                    new Term("y"),
                    new Decimal(2.6m),
                    new Integer(3)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.AreEqual(true, applied);
                Assert.AreEqual(
                    new Term(TermClass.Add,
                        new Term("x"),
                        new Term("y"),
                        new Decimal(5.3m)
                    ),
                    term);
            }

            [TestMethod]
            public void MixedAdditionToZero()
            {
                var term = new Term(TermClass.Add,
                    new Term("x"),
                    new Decimal(-10.6m),
                    new Integer(5),
                    new Term("y"),
                    new Decimal(2.6m),
                    new Integer(3)
                );

                var applicable = new NumberAdd();

                bool applied = applicable.Apply(term);

                Assert.AreEqual(true, applied);
                Assert.AreEqual(
                    new Term(TermClass.Add,
                        new Term("x"),
                        new Term("y")
                    ),
                    term);
            }
        }
    }
}