using System.Collections.Generic;
using System.Linq;

namespace MathEngine.Core.Applicables
{
    public class NumberMul : IApplicable
    {
        public bool Apply(Term term)
        {
            if (term.Tag != TermClass.Mul) return false;

            var integers = new List<Integer>();
            var decimals = new List<Decimal>();

            foreach (var operand in term.Operands)
            {
                if (operand.Tag == TermClass.Integer)
                {
                    integers.Add(operand as Integer);
                }
                else if (operand.Tag == TermClass.Decimal)
                {
                    decimals.Add(operand as Decimal);
                }
            }

            foreach (var t in integers) term.Operands.Remove(t);
            foreach (var t in decimals) term.Operands.Remove(t);

            int prod = integers.Aggregate(1, (acc, x) => acc * x.Value);

            int added = 0;

            if (decimals.Count == 0 && prod != 1)
            {
                term.Operands.Add(new Integer(prod));
                added = 1;
            }
            else
            {
                decimal dsum = decimals.Aggregate(1m, (acc, x) => acc * x.Value) * prod;

                if (dsum != 1)
                {
                    term.Operands.Add(new Decimal(dsum));
                    added = 1;
                }
            }

            return integers.Count + decimals.Count != added;
        }
    }
}