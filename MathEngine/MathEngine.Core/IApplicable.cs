namespace MathEngine.Core
{
    public interface IApplicable
    {
        /// <summary>
        /// Applies current applicable to given term.
        /// </summary>
        /// <param name="term">Term to apply to</param>
        /// <returns>Returns true if changes to term tree were made, false - otherwise</returns>
        bool Apply(Term term);
    }

    public static class ApplicableExtension
    {
        public static bool ApplyRecursive(this IApplicable applicable, Term term)
        {
            bool applyed = applicable.Apply(term);

            foreach (var operand in term.Operands)
            {
                if (applicable.ApplyRecursive(operand))
                {
                    applyed = true;
                }
            }

            return applyed;
        }
    }
}