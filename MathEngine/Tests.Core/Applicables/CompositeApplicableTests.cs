using System;
using System.Linq;
using MathEngine.Core;
using MathEngine.Core.Applicables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core.Applicables
{
    [TestClass]
    public class CompositeApplicableTests
    {
        public class TestsApplicable : IApplicable
        {
            public TestsApplicable(bool applies = true)
            {
                Applies = applies;
            }

            public bool Applied { get; private set; }

            public bool Applies { get; }

            public bool Apply(Term term)
            {
                Applied = true;
                return Applies;
            }
        }

        [TestMethod]
        public void CallesApplicationOnEveryApplicable()
        {
            var applicables = new[]
            {
                new TestsApplicable(),
                new TestsApplicable(),
                new TestsApplicable()
            };

            var composite = new CompositeApplicable(applicables);

            var term = new Term("test");

            bool applyed = composite.Apply(term);

            Assert.IsTrue(applyed);
            Assert.IsTrue(applicables.All(a => a.Applied));
        }

        [TestMethod]
        public void ApplicationReturnsTrueIfAtLeastOneApplyed()
        {
            var applicables = new[]
            {
                new TestsApplicable(false),
                new TestsApplicable(true),
                new TestsApplicable(false)
            };

            var composite = new CompositeApplicable(applicables);

            var term = new Term("test");

            bool applyed = composite.Apply(term);

            Assert.IsTrue(applyed);
        }

        [TestMethod]
        public void ApplicationReturnsFalseIfNoOneApplyed()
        {
            var applicables = new[]
            {
                new TestsApplicable(false),
                new TestsApplicable(false),
                new TestsApplicable(false)
            };

            var composite = new CompositeApplicable(applicables);

            var term = new Term("test");

            bool applyed = composite.Apply(term);

            Assert.IsFalse(applyed);
        }
    }
}
