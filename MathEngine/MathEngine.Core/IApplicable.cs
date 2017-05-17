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
}