using MathEngine.Core.StringFormat.Parse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core.StringFormat.Parse
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void IdentifierComparison()
        {
            var ident1 = new Identifier("x");
            var ident2 = new Identifier("x");
            var ident3 = new Identifier("a");
            var token = new OpenBrackets();

            Assert.AreEqual(ident1, ident2);
            Assert.AreNotEqual(ident1, ident3);
            Assert.AreNotEqual(ident1, token);
        }

        [TestMethod]
        public void IntegerComparison()
        {
            var int1 = new Integer(3);
            var int2 = new Integer(3);
            var int3 = new Integer(5);
            var token = new OpenBrackets();

            Assert.AreEqual(int1, int2);
            Assert.AreNotEqual(int1, int3);
            Assert.AreNotEqual(int1, token);
        }
    }
}
