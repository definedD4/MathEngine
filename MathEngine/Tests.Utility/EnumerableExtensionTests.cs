using System;
using MathEngine.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Utility
{
    [TestClass]
    public class EnumerableExtensionTests
    {
        [TestMethod]
        public void ScrambledEquals()
        {
            var arr1 = new[] {1, 2, 2, 6, 3};
            var arr2 = new[] {2, 6, 1, 3, 2};

            Assert.IsTrue(arr1.ScrambledEquals(arr2));
            Assert.IsTrue(arr2.ScrambledEquals(arr1));

            var arr3 = new[] {1, 2, 3, 6};
            var arr4 = new[] {1, 2, 2, 3, 7, 2};

            Assert.IsFalse(arr2.ScrambledEquals(arr3));
            Assert.IsFalse(arr2.ScrambledEquals(arr4));
        }
    }
}
