using System;
using MathEngine.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
