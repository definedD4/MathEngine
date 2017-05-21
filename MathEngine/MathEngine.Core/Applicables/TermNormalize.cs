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
            var toAdd = new List<Term>();
            var toRemove = new List<Term>();
            bool applicationHappened = false;
            foreach (var operand in term.Operands)
            {
                if ((operand.Tag == TermClass.Add || operand.Tag == TermClass.Mul) && operand.Operands.Count == 1
                    || operand.Tag == term.Tag && (term.Tag == TermClass.Add || term.Tag == TermClass.Mul))
                {
                    toAdd.AddRange(operand.Operands);
                    toRemove.Add(operand);
                    applicationHappened = true;
                }
            }
            toRemove.ForEach(t => term.Operands.Remove(t));
            term.Operands.AddRange(toAdd);

            return applicationHappened;
        }
    }
}