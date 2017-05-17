using System.Collections.Generic;

namespace MathEngine.Core.Applicables
{
    public class TermNormalize : IApplicable
    {
        public TermNormalize()
        {
        }

        public bool Apply(Term term)
        {
            if (term.Tag != Identifier.Add && term.Tag != Identifier.Mul) return false;
            var toAdd = new List<Term>();
            var toRemove = new List<Term>();
            bool applicationHappened = false;
            foreach (var operand in term.Operands)
            {
                if (operand.Tag != term.Tag) continue;
                toAdd.AddRange(operand.Operands);
                toRemove.Add(operand);
                applicationHappened = true;
            }
            toRemove.ForEach(t => term.Operands.Remove(t));
            term.Operands.AddRange(toAdd);
            return applicationHappened;
        }
    }
}