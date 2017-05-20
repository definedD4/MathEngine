using System;
using MathEngine.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core
{
    [TestClass]
    public class TermClassTests
    {
        [TestMethod]
        public void NameSetsName()
        {
            var termClass = new TermClass("test");

            Assert.AreEqual("test", termClass.Name);
        }

        [TestMethod]
        public void IgnoreOperandOrderSetsProperty()
        {
            var termClass1 = new TermClass("test", true);
            var termClass2 = new TermClass("test", false);

            Assert.AreEqual(true, termClass1.IgnoreOperandOrder);
            Assert.AreEqual(false, termClass2.IgnoreOperandOrder);
        }

        [TestMethod]
        public void Comparison()
        {
            var termClass1 = new TermClass("test", true);
            var termClass2 = new TermClass("test", true);
            var termClass3 = new TermClass("test", false);
            var termClass4 = new TermClass("foo", true);

            Assert.AreEqual(termClass1, termClass2);
            Assert.AreNotEqual(termClass1, termClass3);
            Assert.AreNotEqual(termClass1, termClass4);
        }

        [TestMethod]
        public void Parse()
        {
            var termClass1 = TermClass.Parse("foo");
            var termClass2 = TermClass.Parse("Add");

            Assert.AreEqual("foo", termClass1.Name);
            Assert.AreEqual(TermClass.Add, termClass2);
            Assert.AreEqual(true, termClass2.IgnoreOperandOrder);
        }
    }
}
