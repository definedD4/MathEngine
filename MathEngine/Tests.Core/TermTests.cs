using System;
using MathEngine.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decimal = MathEngine.Core.Decimal;

namespace Tests.Core
{
    [TestClass]
    public class TermTests
    {
        [TestMethod]
        public void TagProperty()
        {
            var termClass = new TermClass("test");
            var term = new Term(termClass);

            Assert.AreEqual(termClass, term.Tag);
        }

        [TestMethod]
        public void CompareWithOrder()
        {
            var term1 = new Term(new TermClass("test"), new Term(new TermClass("a")), new Term(new TermClass("b")), new Term(new TermClass("x")));
            var term2 = new Term(new TermClass("test"), new Term(new TermClass("a")), new Term(new TermClass("b")), new Term(new TermClass("x")));
            var term3 = new Term(new TermClass("test"), new Term(new TermClass("a")), new Term(new TermClass("c")), new Term(new TermClass("x")));
            var term4 = new Term(new TermClass("test"), new Term(new TermClass("a")), new Term(new TermClass("x")), new Term(new TermClass("b")));

            Assert.AreEqual(term1, term2);
            Assert.AreNotEqual(term1, term3);
            Assert.AreNotEqual(term1, term4);
        }

        [TestMethod]
        public void CompareWithourOrder()
        {
            var term1 = new Term(new TermClass("test", true), new Term(new TermClass("a")), new Term(new TermClass("b")), new Term(new TermClass("x")));
            var term2 = new Term(new TermClass("test", true), new Term(new TermClass("a")), new Term(new TermClass("b")), new Term(new TermClass("x")));
            var term3 = new Term(new TermClass("test", true), new Term(new TermClass("a")), new Term(new TermClass("c")), new Term(new TermClass("x")));
            var term4 = new Term(new TermClass("test", true), new Term(new TermClass("a")), new Term(new TermClass("x")), new Term(new TermClass("b")));

            Assert.AreEqual(term1, term2);
            Assert.AreNotEqual(term1, term3);
            Assert.AreEqual(term1, term4);
        }

        [TestMethod]
        public void CompareTags()
        {
            var term1 = new Term(new TermClass("a"));
            var term2 = new Term(new TermClass("a"));
            var term3 = new Term(TermClass.Add);

            Assert.AreEqual(term1, term2);
            Assert.AreNotEqual(term1, term3);
        }

        [TestMethod]
        public void CompareIntegers()
        {
            var term1 = new Integer(13);
            var term2 = new Integer(13);
            var term3 = new Integer(15);
            var term4 = new Term(new TermClass("x"));

            Assert.AreEqual(term1, term2);
            Assert.AreNotEqual(term1, term3);
            Assert.AreNotEqual(term1, term4);
        }

        [TestMethod]
        public void CompareDecimals()
        {
            var term1 = new Decimal((decimal) 13.5);
            var term2 = new Decimal((decimal) 13.5);
            var term3 = new Decimal(15);
            var term4 = new Term(new TermClass("x"));

            Assert.AreEqual(term1, term2);
            Assert.AreNotEqual(term1, term3);
            Assert.AreNotEqual(term1, term4);
        }
    }
}
