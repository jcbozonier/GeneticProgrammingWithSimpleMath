using System.Collections.Generic;
using EvolvingPythagoreansTheorem.BreedingSelection;

namespace EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem
{
    public class ProblemConfiguration
    {
        public IEnumerable<string> GeneGrammar
        {
            get { return new[] { "+", "-", "/", "*", "r", "a", "b" }; }
        }

        public ICanScore GetProblemDescription()
        {
            return new PythagoreanProblemDescription();
        }
    }
}