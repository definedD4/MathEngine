using System.Collections.Generic;

namespace MathEngine.Core.Applicables
{
    public class CompositeApplicable : IApplicable
    {
        private readonly List<IApplicable> m_Applicables;

        public CompositeApplicable(IEnumerable<IApplicable> applicables)
        {
            m_Applicables = new List<IApplicable>(applicables);
        }

        public bool Apply(Term term)
        {
            bool applied = false;
            foreach (var applicable in m_Applicables)
            {
                applied |= applicable.Apply(term);
            }
            return applied;
        }
    }
}