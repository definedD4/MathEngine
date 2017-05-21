using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine.Core.Applicables
{
    public class SimularTermReduction : IApplicable
    {
        public bool Apply(Term term)
        {
            Predicate<Term> isNumber = x => x.Tag == TermClass.Integer || x.Tag == TermClass.Decimal;

            if (term.Tag != TermClass.Add) return false;
            if (term.Operands.Count == 0) return false;

            var exceptNumbers = term.Operands.Select(
                op => op.Tag == TermClass.Mul ? 
                op.Operands.Where(x => !isNumber(x)) :
                new [] { op }).ToArray();

            var equalities = exceptNumbers.Select(t => exceptNumbers.Count(x => x.SequenceEqual(t))).ToArray();

            int i = 0;
            foreach (var t in equalities)
            {
                if(t >= 2) break;
                i++;
            }
            if (i == equalities.Length) return false;

            var pick = exceptNumbers[i].ToArray();

            var toRemove = new List<Term>();
            var numbers = new List<Term>();
            foreach (var operand in term.Operands)
            {
                var ops = (operand.Tag == TermClass.Mul
                    ? operand.Operands.AsEnumerable()
                    : new[] {operand}).ToArray();
                
                if (ops.Where(x => !isNumber(x)).SequenceEqual(pick))
                {
                    toRemove.Add(operand);
                    numbers.Add(new Term(TermClass.Mul, ops.Where(x => isNumber(x))));
                }
            }

            foreach (var t in toRemove)
            {
                term.Operands.Remove(t);
            }

            term.Operands.Add(new Term(TermClass.Mul,
                    new Term(TermClass.Add, numbers),
                    new Term(TermClass.Mul, pick)
                ));

            return true;
        }
    }
}
